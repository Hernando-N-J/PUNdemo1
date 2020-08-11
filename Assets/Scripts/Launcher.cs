using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace com.compA.gameA
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [Tooltip("The Ui Panel to let the user enter name, connect and play")]
        [SerializeField] GameObject controlPanel;

        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField] GameObject progressLabel;

        string gameVersion = "1.0";

        bool isPlayerConnected;

        /// <summary>
        /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
        /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
        /// Typically this is used for the OnConnectedToMaster() callback.
        /// </summary>

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        public void Connect()
        {
            Debug.Log("++ Connect()");
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            if (PhotonNetwork.IsConnected) 
            {
                Debug.Log("** Launcher/Connect PlayBtn PN.IsConnected/PN.JRandRoom()");
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isPlayerConnected = PhotonNetwork.ConnectUsingSettings();

                // keep track of when to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
                //PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("-- OCTMaster()");
            Debug.Log("-- OCTMaster is client Master Client? " + PhotonNetwork.IsMasterClient);
            Debug.Log("Client is just connected to Master Server so, he is not Master Client yet until he becomes the first one to create and join a room");
             if (isPlayerConnected)
            {
                PhotonNetwork.JoinRandomRoom();
                Debug.Log("-- OCTMaster called PN.JoinRandomRoom ");
                isPlayerConnected = false;
            }
           
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);

            Debug.LogWarningFormat("-- OnDisconnected called by PUN reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("-- OnJoinRandomFailed called by PUN \n--------- Next line: CreateRoom()");
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("-- POV OnJoinedRoom called ");
            Debug.Log("-- Is client in a room? " + PhotonNetwork.InRoom);
            Debug.Log("-- OnJoinedRoom called by PUN");
            Debug.Log("-- POV OJR -- Client is in a room? " + PhotonNetwork.InRoom);
            Debug.Log("-- POV OJR -- Client MasterClient? " + PhotonNetwork.IsMasterClient);

            //We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

            Debug.Log("-- POV OJRoom -- *** Loading Scene Room for: " + playerCount);
            PhotonNetwork.LoadLevel("Room for " + playerCount);


            string theRoomName = PhotonNetwork.CurrentRoom.Name;
            Debug.Log("-- POV OJRoom -- Room name: " + theRoomName);
            Debug.Log("-- POV OJRrom -- Number of players: " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

    }
}
