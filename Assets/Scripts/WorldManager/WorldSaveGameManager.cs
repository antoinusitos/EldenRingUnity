using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AG
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager instance = null;

        [SerializeField]
        private PlayerManager player = null;

        [Header("Save/Load")]
        [SerializeField]
        private bool saveGame = false;
        [SerializeField]
        private bool loadGame = false;

        [Header("World Scene Index")]
        [SerializeField]
        private readonly int worldSceneIndex = 1;

        [Header("Save Data Writer")]
        private SaveFileDataWriter saveFileDataWriter = null;

        [Header("Current Character Data")]
        public CharacterSlot currentCharacterSlotBeingUsed;
        public CharacterSaveData currentCharacterData = null;
        private string saveFileName = "";

        [Header("Character Slots")]
        public CharacterSaveData characterSlot01 = null;
        //public CharacterSaveData characterSlot02 = null;
        //public CharacterSaveData characterSlot03 = null;
        //public CharacterSaveData characterSlot04 = null;
        //public CharacterSaveData characterSlot05 = null;
        //public CharacterSaveData characterSlot06 = null;
        //public CharacterSaveData characterSlot07 = null;
        //public CharacterSaveData characterSlot08 = null;
        //public CharacterSaveData characterSlot09 = null;
        //public CharacterSaveData characterSlot10 = null;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if(saveGame)
            {
                saveGame = false;
                SaveGame();
            }

            if(loadGame)
            {
                loadGame = false;
                LoadGame();
            }
        }

        private void DecideCharacterFileNameBasedOnCharacterSlotBeinUsed()
        {
            switch(currentCharacterSlotBeingUsed) 
            {
                case CharacterSlot.CharacterSlot_01:
                    saveFileName = "CharacterSlot_01";
                    break;
                case CharacterSlot.CharacterSlot_02:
                    saveFileName = "CharacterSlot_02";
                    break;
                case CharacterSlot.CharacterSlot_03:
                    saveFileName = "CharacterSlot_03";
                    break;
                case CharacterSlot.CharacterSlot_04:
                    saveFileName = "CharacterSlot_04";
                    break;
                case CharacterSlot.CharacterSlot_05:
                    saveFileName = "CharacterSlot_05";
                    break;
                case CharacterSlot.CharacterSlot_06:
                    saveFileName = "CharacterSlot_06";
                    break;
                case CharacterSlot.CharacterSlot_07:
                    saveFileName = "CharacterSlot_07";
                    break;
                case CharacterSlot.CharacterSlot_08:
                    saveFileName = "CharacterSlot_08";
                    break;
                case CharacterSlot.CharacterSlot_09:
                    saveFileName = "CharacterSlot_09";
                    break;
                case CharacterSlot.CharacterSlot_10:
                    saveFileName = "CharacterSlot_10";
                    break;
            }
        }

        public void CreateNewGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeinUsed();

            currentCharacterData = new CharacterSaveData();
        }

        public void LoadGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeinUsed();

            saveFileDataWriter = new SaveFileDataWriter
            {
                saveDataDirectoryPath = Application.persistentDataPath,
                saveFileName = saveFileName
            };

            currentCharacterData = saveFileDataWriter.LoadSaveFile();

            StartCoroutine(LoadWorldScene());
        }

        public void SaveGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeinUsed();

            saveFileDataWriter = new SaveFileDataWriter()
            {
                saveDataDirectoryPath = Application.persistentDataPath,
                saveFileName = saveFileName
            };

            player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

            saveFileDataWriter.CreateNewCharacterSaveFile(currentCharacterData);
        }

        public IEnumerator LoadWorldScene()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);

            yield return null;
        }

        public int GetWorldSceneIndex()
        {
            return worldSceneIndex;
        }
    }
}