using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
using System.Text;
using System;

public class BingoScript : MonoBehaviour
{
   
    
    public static void BingoConfig(MonoBehaviour config)
    {
        AppsFlyer.initSDK(Config.devkey, null, config);
        AppsFlyer.startSDK();
        AppsFlyer.setIsDebug(false);
    }

    public static string CovertStringName(string name)
    {
        var name1 = "";
        var mainName = "";
        var temp = name;
        foreach(var t in temp.Split("$"))
        {
            name1 += t.Replace("$", "");
        }
        foreach(var t in name1.Split("#"))
        {
            mainName += t.Replace("#", "");
        }
        return mainName;
    }


}
