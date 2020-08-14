using Photon.Pun;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace com.compA.gameA
{
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        // Store the PlayerPref Key to avoid typos
        private const string playerNamePrefKey = "PlayerName";

        public bool hasPlayerName = false;

        public Button playButton;

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        private void Start()
        {
            Debug.Log("== Entering PlyrNameIF/Start");
            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();
            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
            Debug.Log("== Exiting PlyrNameIF/Start");
        }


        /// <summary>
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// </summary>
        /// <param name="value">The name of the Player</param>
        public void SetPlayerName(string value)
        {
            // TODO: validate input field
            // UNDONE: validate
            // HACK: validate

            bool validStr1 = Regex.IsMatch(value, @"^\w*$");
            bool validStr2 = !string.IsNullOrEmpty(value);
            bool validStr3 = !string.IsNullOrWhiteSpace(value);
            bool validStr4 = value.Length > 3 && value.Length <= 10;
            bool validStr5 = validStr1 && validStr2 && validStr3 && validStr4;

            //if (string.IsNullOrWhiteSpace(value))
            if (validStr5)
            {
                playButton.interactable = true;
                PhotonNetwork.NickName = value;
                PlayerPrefs.SetString(playerNamePrefKey, value);
            }
            else
            {
                playButton.interactable = false;
            }







        }
    }
}