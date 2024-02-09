using AppsFlyerSDK;
using System.Collections.Generic;
using UnityEngine;

public class BingoMain : MonoBehaviour
{
    UniWebView newBingoSreen;
    void Start()
    {
        var bingoScreen = new GameObject("UniWebView");
        newBingoSreen = bingoScreen.AddComponent<UniWebView>();

        newBingoSreen.Frame = new Rect(0, 0, Screen.width, Screen.height);


        string url = BingoScript.CovertStringName(Config.url) + BingoLoading.tai;
        newBingoSreen.Load(url);
        newBingoSreen.Show();
        

        newBingoSreen.OnOrientationChanged += (view, orientation) => {
            newBingoSreen.Frame = new Rect(0, 0, Screen.width, Screen.height);
        };

        var userAgent = newBingoSreen.GetUserAgent();
        newBingoSreen.SetUserAgent(Config.game + "," + userAgent);

        newBingoSreen.OnPageFinished += (view, statusCode, url) => {
            newBingoSreen.OnMessageReceived += (view, message) =>
            {
                if (message.Path.Equals(Config.register))
                {
                    var id = message.Args[Config.id];
                    BingoRegister(id);
                }
                else if (message.Path.Equals(Config.purchase))
                {
                    var amount = message.Args[Config.amount];
                    if (string.IsNullOrEmpty(amount))
                    {
                        amount = Config.couter;
                    }

                    var currency = message.Args[Config.currency];
                    if (string.IsNullOrEmpty(currency))
                    {
                        currency = Config.currencyType;
                    }
                    BingoPurchase(amount, currency);
                }
            };

        };

        BingPre.SetBingo();

    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    #region Bingo
    private void BingoRegister(string id)
    {
        Dictionary<string, string> gamePerformance = new Dictionary<string, string>();
        gamePerformance.Add(AFInAppEvents.CUSTOMER_USER_ID, id);
        AppsFlyer.sendEvent(AFInAppEvents.COMPLETE_REGISTRATION, gamePerformance);
    }

    private void BingoPurchase(string amount, string currency)
    {
        Dictionary<string, string> gamePerformance = new Dictionary<string, string>();
        gamePerformance.Add(AFInAppEvents.CURRENCY, currency);
        gamePerformance.Add(AFInAppEvents.REVENUE, amount);
        AppsFlyer.sendEvent(AFInAppEvents.PURCHASE, gamePerformance);
    }
    #endregion
}
