using Photon.Pun;
using UnityEngine;

public class TestB : MonoBehaviourPunCallbacks
{
    public bool playerIsConnected;

    private void Awake()
    {
        if (PhotonNetwork.IsConnected) playerIsConnected = true;
    }



    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom called");

        Debug.Log(" On Left Room. Player is connected?: " + PhotonNetwork.IsConnected);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        // Operation LeaveRoom (254) not allowed on current server (MasterServer)
    }

    //TODO: checkout PhotonNetwork.Disconnect();
    //TODO: checkout room's name
}
