package es.devhero.androidunitycommtest;

import android.util.Log;
import android.widget.Toast;
import android.os.Bundle;

import com.unity3d.player.UnityPlayer;

public class ExtendedActivity extends com.unity3d.player.UnityPlayerActivity {
    public static final String TAG = "ExtendedActivity";

    private static ExtendedActivity instance;
    public static ExtendedActivity getInstance() {
        return instance;
    }


    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        instance = this;

        Log.d(TAG, "STARTED UNITY!");
    }
    
   public String testAndroidCall(String incoming) {
        Toast.makeText(this, "FROM UNITY: " + incoming, Toast.LENGTH_LONG).show();
        return new String("return from android");
   }
   
   public void testUnityCall() {
        String message = "Example message";
        Log.d(TAG, "Sending message to unity!");
        UnityPlayer.UnitySendMessage("CommObject", "receiveFromAndroid", message);
   }
}