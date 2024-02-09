using AppsFlyerSDK;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BingoLoading : MonoBehaviour,IAppsFlyerConversionData
{

    public static string tai ;
    private void Start()
    {
        BingoScript.BingoConfig(this);
        tai = AppsFlyer.getAppsFlyerId();
    }






    public void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        // add deferred deeplink logic here
        var stack = false;
        if (BingPre.isBingoClick())
        {
            stack = true;
        }
        else
        {
            if (conversionDataDictionary.ContainsKey("af_status"))
            {
                if (string.Equals(conversionDataDictionary["af_status"].ToString(), "Organic", System.StringComparison.OrdinalIgnoreCase))
                {
                    stack = false;
                }
                else
                {
                    stack = false;
                    if (Application.systemLanguage == SystemLanguage.Vietnamese)
                    {
                        stack = true;
                    }
                }
            }

        }
        UserType(stack);
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("onConversionDataFail", error);
        var temp = false;
        if (BingPre.isBingoClick())
        {
            temp = true;
        }
        else
        {
            temp = false;
        }
        UserType(temp);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }

    public void UserType(bool state)
    {

        if (state)
        {
            SceneManager.LoadSceneAsync(2);
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
        }
    }



   

}//end of Class
