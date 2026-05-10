using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CTS
{
	public class DeveloperEditorCanvasManager : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		[Space(10f)]
		private GameObject _submenuGameObject;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Scene]
		private int _mainMenuScene;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Scene]
		private int _selectionLevelScene;

		[SerializeField]
		[BoxGroup("Button")]
		[Space(10f)]
		public Button _gameSettingsButtons;

		[SerializeField]
		[BoxGroup("Button")]
		private Button _levelSettingsButtons;

		[SerializeField]
		[BoxGroup("Button")]
		private Button _techTreeEditorButtons;

		[SerializeField]
		[BoxGroup("Button")]
		private Button _characterEditorButtons;

		[SerializeField]
		[BoxGroup("Button")]
		private Button _questsSettingsButtons;

		[SerializeField]
		[BoxGroup("ButtonContents")]
		[Space(10f)]
		private GameObject _gameSettings;

		[SerializeField]
		[BoxGroup("ButtonContents")]
		private GameObject _levelSettings;

		[SerializeField]
		[BoxGroup("ButtonContents")]
		private GameObject _techTreeEditor;

		[SerializeField]
		[BoxGroup("ButtonContents")]
		private GameObject _characterEditor;

		[SerializeField]
		[BoxGroup("ButtonContents")]
		private GameObject _questsSettings;

		private Canvas _mainCanvas;

		private Scene _currentScene;

		private Dictionary<string, Button> _contentButtons;

		private void Awake()
		{
			_mainCanvas = GetComponent<Canvas>();
			_contentButtons = new Dictionary<string, Button>
			{
				{ "gameSettings", _gameSettingsButtons },
				{ "levelSettings", _levelSettingsButtons },
				{ "techTreeEditor", _techTreeEditorButtons },
				{ "characterEditor", _characterEditorButtons },
				{ "questsSettings", _questsSettingsButtons }
			};
		}

		private void OnEnable()
		{
			MenusManager.OnLoadAdditiveScene += OnLoadAdditiveScene;
			SceneManager.sceneLoaded += OnSceneLoaded;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			DevEditorIsOpen(value: true);
			ReloadUI(SceneManager.GetActiveScene());
		}

		private void OnDisable()
		{
			MenusManager.OnLoadAdditiveScene -= OnLoadAdditiveScene;
			SceneManager.sceneLoaded -= OnSceneLoaded;
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			DevEditorIsOpen(value: false);
		}

		private void OnLoadAdditiveScene()
		{
			ReloadUI(SceneManager.GetActiveScene());
		}

		private void OnSceneLoaded(Scene sceneValue, LoadSceneMode loadSceneMode)
		{
			ReloadUI(sceneValue);
		}

		private void OnSceneUnloaded(Scene sceneValue)
		{
			ReloadUI(SceneManager.GetActiveScene());
		}

		private void ReloadUI(Scene sceneValue)
		{
			if (_currentScene == sceneValue)
			{
				return;
			}
			_currentScene = sceneValue;
			int buildIndex = sceneValue.buildIndex;
			if (_mainMenuScene == buildIndex)
			{
				SetSpecificButtonsEnabled(new Dictionary<string, bool>
				{
					{ "gameSettings", true },
					{ "levelSettings", false },
					{ "techTreeEditor", false },
					{ "characterEditor", false },
					{ "questsSettings", false }
				});
				if (_mainCanvas.enabled)
				{
					_mainCanvas.enabled = false;
					_mainCanvas.enabled = true;
				}
			}
			else if (_selectionLevelScene == buildIndex)
			{
				SetButtonsEnabled(isEnabled: false);
			}
			else
			{
				SetButtonsEnabled(isEnabled: true);
			}
			ResetDisplayedContent();
		}

		private void DevEditorIsOpen(bool value)
		{
			_mainCanvas.enabled = value;
			_submenuGameObject.SetActive(value);
		}

		private void SetButtonsEnabled(bool isEnabled)
		{
			foreach (Button value in _contentButtons.Values)
			{
				value.interactable = isEnabled;
			}
		}

		private void SetSpecificButtonsEnabled(Dictionary<string, bool> buttonStates)
		{
			foreach (KeyValuePair<string, bool> buttonState in buttonStates)
			{
				if (_contentButtons.TryGetValue(buttonState.Key, out var value))
				{
					value.interactable = buttonState.Value;
				}
			}
		}

		private void ResetDisplayedContent()
		{
			_gameSettings.SetActive(value: false);
			_levelSettings.SetActive(value: false);
			_techTreeEditor.SetActive(value: false);
			_characterEditor.SetActive(value: false);
			_questsSettings.SetActive(value: false);
		}

		public void ChangeStateGameSettings()
		{
			_gameSettings.SetActive(!_gameSettings.activeSelf);
		}

		public void ChangeStateLevelSettings()
		{
			_levelSettings.SetActive(!_levelSettings.activeSelf);
		}

		public void ChangeStateTechTreeEditor()
		{
			_techTreeEditor.SetActive(!_techTreeEditor.activeSelf);
		}

		public void ChangeStateCharacterEditor()
		{
			_characterEditor.SetActive(!_characterEditor.activeSelf);
		}

		public void ChangeStateQuestsSettings()
		{
			_questsSettings.SetActive(!_questsSettings.activeSelf);
		}
	}
}
