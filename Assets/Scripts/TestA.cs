using Photon.Pun;
using UnityEngine;

public class TestA : MonoBehaviourPunCallbacks
{
    public bool playerIsConnected;


    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings();
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Awake: Player is connected");
            playerIsConnected = true;
        }
        else
        {
            Debug.Log("Awake: Player is not connected");
            playerIsConnected = false;

        }
    }


    private void Start()
    {
        Debug.Log("Using connectUsingSettings");
        PhotonNetwork.ConnectUsingSettings();

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Start: Player is connected");
            playerIsConnected = true;
        }
        else
        {
            Debug.Log("Start: Player is not connected");
            playerIsConnected = false;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player is connected to master");
        PhotonNetwork.LoadLevel("TestSceneB");
        Debug.Log("SceneB loaded");

        //Debug.Log("Leaving room");
        //LeaveRoom();

    }
}
