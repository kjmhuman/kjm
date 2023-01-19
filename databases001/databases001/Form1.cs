
using Npgsql;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities.Collections;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace databases001
{
    public partial class Form1 : Form
    {

        Boolean Success = false; // 테이블 접속 여부
        Boolean isconnection = false; // 다른 서버에 연결 되오 있는지
        String commandText = "";//select문 저장 
        String rearPrimary = "";//primary key 값 저장
        int connMode=1;//1은 book이며 2은 car
        string connStart = "Host=192.168.201.151;Username=postgres;Password=12345678;Database=book_car"; //데이터 베이스 주소
        string str_serverURL = "127.0.0.1";//사설 주소
        string str_serverPort = "5555";//사설 포트 번호

        private int sortColumn = -1;

        String str_primary = "";
        String str_name = "";
        String str_infor = "";
        String str_date = "";

        StreamReader streamReader;   // 데이타 읽기 위한 스트림리더
        StreamWriter streamWriter; // 데이타 쓰기 위한 스트림라이터

        public Form1()//
        {
            InitializeComponent();

            using (var conn = new NpgsqlConnection(connStart))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "select * from book order by name asc";

                        using (var reader = cmd.ExecuteReader())
                        {
                            ListViewItem item;

                            while (reader.Read())
                            {
                                DateTime date = (DateTime)reader["date"];
                                if (connMode == 1)
                                {
                                    string[] row = { reader["isbn"].ToString(),
                                                      reader["name"].ToString(),
                                                      reader["author"].ToString(),
                                                      date.ToString("yyyy-MM-dd")};
                                    item = new ListViewItem(row);

                                    if (listView1.InvokeRequired)
                                    {
                                        listView1.Invoke(new MethodInvoker(delegate
                                        {
                                            listView1.Items.Add(item);
                                            listView1.EnsureVisible(listView1.Items.Count - 1);
                                        }));
                                    }
                                    else
                                    {
                                        listView1.Items.Add(item);
                                        listView1.EnsureVisible(listView1.Items.Count - 1);
                                    }
                                }   
                                init_Column_Size();
                                DB_Connection_Reading();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    print_error(e);
                }
            }
        }

        private void start()//쓰레드를 실행시키는 작업
        {
            Thread thread = new Thread(connect);
            thread.IsBackground = true;
            thread.Start();
        }


        private void writeRichTextbox(string str)//상태 텍스트 표시  
          {
            server_txt.Invoke((MethodInvoker)delegate 
            {
                server_txt.AppendText(str + "\r\n"); 
            });
            server_txt.Invoke((MethodInvoker)delegate 
            {
                server_txt.ScrollToCaret(); 
            });
        }

        void print_error(Exception e)
        {
            Console.WriteLine("============== Error ==============");
            Console.WriteLine(e.Message);
            MessageBox.Show("에러가 발생했습니다.\n\n============== Error ==============\n\n" + e.Message, "Error");
        }

        private void connect()//다른 클라이언트랑 연동
        {
            if (ip_txt.Text.Equals(""))
            {
                return;
            }

            string str_ip = ip_txt.Text;
            string str_port = "5555";

            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Parse(str_ip), int.Parse(str_port));
                tcpListener.Start(); // 서버 시작
                writeRichTextbox(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,")+"서버 준비..."+"");

                while (true)
                {
                    isconnection = true;
                    TcpClient tcpClient1 = tcpListener.AcceptTcpClient();
                    writeRichTextbox(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, ")+ "클라이언트 연결됨"+"");
                    
                

                    streamReader = new StreamReader(tcpClient1.GetStream());
                    streamWriter = new StreamWriter(tcpClient1.GetStream());
                    streamWriter.AutoFlush = true;
                    if (ip_txt.InvokeRequired)
                    {
                        ip_txt.Invoke(new MethodInvoker(delegate { ip_txt.ReadOnly =true; }));
                    }
                    else
                        ip_txt.ReadOnly = true;
                    
                    while (isconnection==true)
                    {
                        string receiveData1 = streamReader.ReadLine();
                        if (receiveData1 == null || receiveData1.Equals("exit"))
                        {
                            isconnection = false;
                            writeRichTextbox(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, ") + "클라이언트 종료됨... "+" ");
                            streamReader.Close();
                            streamWriter.Close();
                            tcpClient1.Close();
                            break;
                        }
                        writeRichTextbox(receiveData1);
                    }

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        void init_txt()//텍스트 내용 비우기
        {
            primary_txt.Text = string.Empty;
            name_txt.Text = string.Empty;
            Author_txt.Text = string.Empty;
            date_txt.Text = string.Empty;
        }

        void init_Column_Size()//텍스트 뷰 사이즈 조절
        {
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = -2;
            }
        }

        void init_Column()//무언가를 시도 했을 시 텍스트 초기화 및 다시 불러오기
        {
            if (connMode == 1)
            {
                this.primary_co.Text = string.Format("ISBN");
                this.humen_co.Text = string.Format("Author");

                this.primary_la.Text = string.Format("ISBN");
                this.humen_la.Text = string.Format("Author");

            }
            else if (connMode == 2)
            {
                this.primary_co.Text = string.Format("number");
                this.humen_co.Text = string.Format("Company");

                this.primary_la.Text = string.Format("number");
                this.humen_la.Text = string.Format("Company");
            }
            this.name_co.Text = string.Format("Name");
            this.date_co.Text = string.Format("Date");
            this.name_la.Text = string.Format("Name");
            this.date_la.Text = string.Format("Date");
            using (var conn = new NpgsqlConnection(connStart))
            {
                try
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        if (connMode == 1)
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "select * from Book order by name ASC";

                            Reading_date(cmd);
                        }
                        else if (connMode == 2)
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "select * from car order by name ASC";

                            Reading_date(cmd);
                        }
                    }
                }
                catch (Exception e)
                {
                    print_error(e);
                }
            }
        }
        void Reading_date(NpgsqlCommand cmd)//데이터를 읽어오는
        {
            listView1.Items.Clear();
            using (var reader = cmd.ExecuteReader())
            {
                ListViewItem item;

                while (reader.Read())
                {
                    DateTime date = (DateTime)reader["date"];
                    if (connMode == 1)
                    {
                        string[] row = { reader["isbn"].ToString(),
                                                      reader["name"].ToString(),
                                                      reader["author"].ToString(),
                                                      date.ToString("yyyy-MM-dd")};
                        item = new ListViewItem(row);
                        listView1.Items.Add(item);
                    }
                    else if (connMode == 2)
                    {
                        string[] row = { reader["number"].ToString(),
                                                      reader["name"].ToString(),
                                                      reader["company"].ToString(),
                                                      date.ToString("yyyy-MM-dd")};
                        item = new ListViewItem(row);
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        void DB_Connection_Reading()//DB 읽기
        {
            using (var conn = new NpgsqlConnection(connStart))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        if (connMode == 1)
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "select * from book order by name ASC";

                            Reading_date(cmd); //
                            Success = true; // 접속 완료 체크
                            init_Column_Size(); // 컬럼 사이즈 자동 조절
                        }
                        else if (connMode == 2)
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "select * from car order by name ASC";

                            Reading_date(cmd); 
                            Success = true; 
                            init_Column_Size();
                        }
                    }

                }
                catch (Exception e)
                {
                    print_error(e);
                }
            }
        }

        void DB_In(string str_primary, string str_name, string str_infor, string str_date)//데이터 베이스 삽입
        {
            using (var conn = new NpgsqlConnection(connStart))
            {
                try
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = commandText;

                        Reading_date(cmd);
                        if (isconnection)
                        {
                            if (connMode == 1)
                            {
                                commandText = "select * from book";
                                streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, Book: ") + str_primary +
                                       ", " + str_name + " 의 정보가 추가되었습니다.");
                            }
                            else if (connMode == 2)
                            {
                                commandText = "select * from car";
                                streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, Car: ") + str_primary +
                        ", " + str_name + "  의 정보가 추가되었습니다.");
                            }
                        }
                        else if(!isconnection)
                        {
                            if (connMode == 1)
                            {
                                commandText = "select * from book";
                            }
                            else if (connMode == 2)
                            {
                                commandText = "select * from car";
                            }
                        }
                        DB_Connection_Reading();
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                        init_txt();
                    }
                }
                catch (Exception e)
                {
                    print_error(e);
                    init_txt();
                }
            }
        }

        void DB_UP(string str_primary, string str_name, string str_infor, string str_date)//데이터 베이스 삽입
        {
            using (var conn = new NpgsqlConnection(connStart))
            {
                try
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = commandText;

                        Reading_date(cmd);
                        if (isconnection)
                        {
                            if (connMode == 1)
                            {
                                commandText = "select * from book";
                                streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, Book: ") + str_primary +
                        ", " + str_name + "  의 정보가 변경되었습니다.");
                            }
                            else if (connMode == 2)
                            {
                                commandText = "select * from car";
                                streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, Car: ") + str_primary +
                        ", " + str_name + " 의 정보가 변경되었습니다.");
                            }
                            DB_Connection_Reading();
                            listView1.EnsureVisible(listView1.Items.Count - 1);
                            init_txt();
                        }
                        else if(!isconnection)
                        {
                            if (connMode == 1)
                            {
                                commandText = "select * from book";
                            }
                            else if (connMode == 2)
                            {
                                commandText = "select * from car";
                            }
                            DB_Connection_Reading();
                            listView1.EnsureVisible(listView1.Items.Count - 1);
                            init_txt();
                        }

                    }

                }
                catch (Exception e)
                {
                    print_error(e);
                    init_txt();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//Book car 바꾸는 버튼
        {
            if (connMode == 1)
            {
                connMode = 2;
                init_Column();
                init_txt();
                commandText = "select * from car order by name ASC ";
                DB_Connection_Reading();
            }
            else if(connMode ==2)
            {
                connMode = 1;
                init_Column();
                init_txt();
                commandText = "select * from book order by name ASC ";
                DB_Connection_Reading();
            }
        }


        private void insert_bt_Click(object sender, EventArgs e)//입력 버튼
        {
            if (Success == false)
            {
                return;
            }

            str_primary = primary_txt.Text;
            str_name = name_txt.Text;
            str_infor = Author_txt.Text;
            str_date = date_txt.Text;

            if (primary_txt.Text.Equals("") || name_txt.Text.Equals("") || Author_txt.Text.Equals("") || date_txt.Text.Equals(""))
            {
                MessageBox.Show("빈 항목 없이 작성해주세요.");
                return;
            }

            // 쿼리문 작성
            if (connMode == 1)
            {
                commandText = "insert into book values(" + str_primary +
                                ", '" + str_name +
                                "', '" + str_infor +
                                "', '" + str_date + "')";
                Console.WriteLine(commandText);
                DB_In(str_primary, str_name, str_infor, str_date);   
            }
            else if (connMode == 2)
            {
                commandText = "insert into car values('" + str_primary +
                                "', '" + str_name +
                                "', '" + str_infor +
                                "', '" + str_date + "')";
                Console.WriteLine(commandText);
                DB_In(str_primary, str_name, str_infor, str_date);
            }
        }


        private void update_bt_Click(object sender, EventArgs e)//수정 버튼
        {
            if (Success == false)
            {
                return;
            }

            str_primary = primary_txt.Text;
            str_name = name_txt.Text;
            str_infor = Author_txt.Text;
            str_date = date_txt.Text;

           
            if (primary_txt.Text.Equals("") || name_txt.Text.Equals("") || Author_txt.Text.Equals("") || date_txt.Text.Equals(""))
            {
                MessageBox.Show("빈 항목 없이 작성해주세요.");
                return;
            }

            if (connMode == 1)
            {
                commandText = "update book set isbn = " + str_primary +
                                ", name = '" + str_name +
                                "', author = '" + str_infor +
                                "', date = '" + str_date + "' where isbn = " + rearPrimary;
                Console.WriteLine(commandText);
                DB_UP(str_primary, str_name, str_infor, str_date);
            }
            else if (connMode == 2)
            {
                commandText = "update car set number = '" + str_primary +
                                "', name = '" + str_name +
                                "', company = '" + str_infor +
                                "', date = '" + str_date + "' where number = '" + rearPrimary + "'";
                Console.WriteLine(commandText);
                DB_UP(str_primary, str_name, str_infor, str_date);
            }

        }

        private void con_bt_Click(object sender, EventArgs e)//연결 버튼
        {
            start();
        }

        private void list_MouseClick(object sender, EventArgs e)//뷰 클릭 버튼
        {

            bool selected = listView1.SelectedItems.Count > 0;
            if (selected)
            {
                ListViewItem item = listView1.SelectedItems[0];
                String str_primary = item.SubItems[0].Text;
                String str_name = item.SubItems[1].Text;
                String str_infor = item.SubItems[2].Text;
                String str_date = item.SubItems[3].Text;

                primary_txt.Text = str_primary;
                name_txt.Text = str_name;
                Author_txt.Text = str_infor;
                date_txt.Text = str_date;

                rearPrimary = str_primary;
                Console.WriteLine(rearPrimary);
            }

        }  
        private void button1_Click(object sender, EventArgs e)//재시작 버튼
        {
            init_Column();
            init_txt();
            writeRichTextbox(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss, ") + "새로고침 했습니다. " + " ");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//닫기 버튼
        {
            if (isconnection == true)
            {
                streamWriter.WriteLine("exit");
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)//리스트 뷰 클릭 버튼
        {
            if (listView1.Sorting == SortOrder.Ascending)
                listView1.Sorting = SortOrder.Descending;
            else
                listView1.Sorting = SortOrder.Ascending;

            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);

        }
    }

    class ListViewItemComparer : IComparer// 리스트 뷰 정렬
    {
        private int col=0;
        private SortOrder order;
        public ListViewItemComparer()
        {

            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }

    }
}