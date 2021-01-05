using UnityEngine;
using UnityEngine.UI;

public class AndroidComm : MonoBehaviour {
    public Text unityText;


    public void sendToAndroid() {
        string testString = "example text";
#if UNITY_EDITOR
        Debug.Log($"Simulate android communication: {testString}");
#elif PLATFORM_ANDROID
        using (AndroidJavaClass jc = new AndroidJavaClass("es.devhero.androidunitycommtest.ExtendedActivity")) {
            using (AndroidJavaObject jo = jc.CallStatic<AndroidJavaObject>("getInstance")) {
                // check if object was returned, otherwise ignore
                if (jo.GetRawObject().ToInt32() == 0) {
                    Debug.LogError("Instance not retrieved! Probably missing AndroidManifest entry");
                    return;
                }
                string response = jo.Call<string>("testAndroidCall", testString);
                if (!string.IsNullOrEmpty(response)) {
                    Debug.Log($"From android: {response}");
                } 

            }
        }
#endif

    }
    
    public void sendToUnity() {
#if PLATFORM_ANDROID
        using (AndroidJavaClass jc = new AndroidJavaClass("es.devhero.androidunitycommtest.ExtendedActivity")) {
            using (AndroidJavaObject jo = jc.CallStatic<AndroidJavaObject>("getInstance")) {
                // check if object was returned, otherwise ignore
                if (jo.GetRawObject().ToInt32() == 0) {
                    Debug.LogError("Instance not retrieved! Probably missing AndroidManifest entry");
                    return;
                }
                jo.Call("testUnityCall");
            }
        }
#endif
    }    
    
    public void receiveFromAndroid(string text) {
        unityText.text = text;
    }
}
