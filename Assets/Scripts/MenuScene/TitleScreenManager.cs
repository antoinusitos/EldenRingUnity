using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

namespace AG
{
    public class TitleScreenManager : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField]
        private GameObject titleScreenMainMenu = null;
        [SerializeField]
        private GameObject titleScreenLoadMenu = null;

        [Header("Buttons")]
        [SerializeField]
        private Button loadMenuReturnButton = null;
        [SerializeField]
        private Button mainMenuLoadGameButton = null;

        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            WorldSaveGameManager.instance.CreateNewGame();
            StartCoroutine(WorldSaveGameManager.instance.LoadWorldScene());
        }

        public void OpenLoadGameMenu()
        {
            titleScreenMainMenu.SetActive(false);
            titleScreenLoadMenu.SetActive(true);

            loadMenuReturnButton.Select();
        }

        public void CloseLoadGameMenu()
        {
            titleScreenLoadMenu.SetActive(false);
            titleScreenMainMenu.SetActive(true);

            mainMenuLoadGameButton.Select();
        }
    }
}