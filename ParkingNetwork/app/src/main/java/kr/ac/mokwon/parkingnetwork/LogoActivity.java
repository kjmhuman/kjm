package kr.ac.mokwon.parkingnetwork;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;

public class LogoActivity extends AppCompatActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_logo);

        getSupportActionBar().hide();
    }
}