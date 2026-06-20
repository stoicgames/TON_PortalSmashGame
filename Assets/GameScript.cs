using UnityEngine;
using YesTMABridge;

public class GameScript : MonoBehaviour
{
    [Header("Payment Settings")]
    public string recipientAddress = "UQXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    public float amountTon = 0.01f;
    public string comment = "Unity Telegram Bridge Test";

    // Ask user to connect TON wallet


    public void Start()
    {
        Debug.Log("new version X");
    }


    public void CheckVersion()
    {
        Debug.Log("Checking version...version 10");
    }

    public void ConnectWallet()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Debug.Log("Requesting wallet connection...");
        TGMiniAppGameSDKProvider.connectWallet();
#else
        Debug.Log("connect wallet click");
#endif
    }

    // Check whether wallet is connected
    public void CheckWallet()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        bool connected = TGMiniAppGameSDKProvider.getWalletConnected();
        string address = TGMiniAppGameSDKProvider.getWalletAddress();

        Debug.Log($"Connected: {connected}");
        Debug.Log($"Address: {address}");
#endif
    }

    // Ask user to approve a payment
    public void SendTestPayment()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (!TGMiniAppGameSDKProvider.getWalletConnected())
        {
            Debug.LogWarning("Wallet not connected.");
            return;
        }

        Debug.Log($"Requesting payment of {amountTon} TON");
        TGMiniAppGameSDKProvider.payWithTon(
            recipientAddress,
            amountTon,
            comment
        );
#else
        Debug.Log("Payments only work in WebGL.");
#endif
    }
}