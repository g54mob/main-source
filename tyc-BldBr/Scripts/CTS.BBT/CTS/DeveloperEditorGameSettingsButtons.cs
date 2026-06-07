using System;
using System.Text.RegularExpressions;
using CTS.Core;
using CTS.DevConsole;
using CTS.DevConsole.Commands;
using CTS.ScriptableSettings;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CTS
{
	public class DeveloperEditorGameSettingsButtons : MonoBehaviour
	{
		[SerializeField]
		[Scene]
		private int _mainMenuScene;

		[SerializeField]
		[Scene]
		private int _selectionLevelScene;

		[SerializeField]
		private SettingObject<bool> _freeModeBoolSetting;

		[SerializeField]
		private TextMeshProUGUI _moneyAmountTextField;

		[SerializeField]
		private TextMeshProUGUI _vigilanceAmountTextField;

		[SerializeField]
		private GameObject _mainMenuContent;

		[SerializeField]
		private GameObject _gameContent;

		private CameraMouseControls _cameraMouseControls;

		[SerializeField]
		private Canvas _uiBuildVersion;

		private Canvas _uiMenuButton;

		private LockToggle _mainCanvasToggle;

		private string _tmpValue;

		private void OnEnable()
		{
			ReloadUI(SceneManager.GetActiveScene(), LoadSceneMode.Single);
			SceneManager.sceneLoaded += ReloadUI;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded += ReloadUI;
		}

		private void ReloadUI(Scene scene, LoadSceneMode loadSceneMode)
		{
			if (scene.buildIndex == _mainMenuScene)
			{
				_mainMenuContent.SetActive(value: true);
				_gameContent.SetActive(value: false);
			}
			else if (scene.buildIndex != _selectionLevelScene)
			{
				_mainMenuContent.SetActive(value: false);
				_gameContent.SetActive(value: true);
				FindRef();
			}
		}

		private void FindRef()
		{
			if (_mainCanvasToggle == null)
			{
				_mainCanvasToggle = new LockToggle(MonoSingleton<UIMainCanvas>.Instance);
			}
			if ((object)_cameraMouseControls == null)
			{
				_cameraMouseControls = MonoSingleton<MainCamera>.Instance.GetComponent<CameraMouseControls>();
			}
			if ((object)_uiBuildVersion == null)
			{
				_uiBuildVersion = GameObject.Find("[VERSION]").GetComponent<Canvas>();
			}
			if ((object)_uiMenuButton == null)
			{
				_uiMenuButton = GameObject.Find("[UI_MenuButton]").GetComponent<Canvas>();
			}
		}

		public void DisplayOrHideUI(Toggle _value)
		{
			_mainCanvasToggle.SetLock(!_value.isOn);
			_uiMenuButton.enabled = _value.isOn;
		}

		public void DisplayOrHideVersion(Toggle _value)
		{
			_uiBuildVersion.enabled = _value.isOn;
		}

		public void CameraFollowMouse(Toggle _value)
		{
			if (_value.isOn)
			{
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Soft);
				_cameraMouseControls.enabled = true;
			}
			else
			{
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Tutorial);
				_cameraMouseControls.enabled = false;
			}
		}

		public void UnlockFreeMode()
		{
			_freeModeBoolSetting.SetValue(value: true);
		}

		public void ChangeMoneyAmount()
		{
			if (_moneyAmountTextField.text != "0")
			{
				_tmpValue = Regex.Replace(_moneyAmountTextField.text, "[^0-9/-]", "");
				DeveloperConsole.ExecuteCommand<CommandMoneySet>(new string[1] { _tmpValue });
			}
		}

		public void ChangeVigilance()
		{
			_tmpValue = Regex.Replace(_vigilanceAmountTextField.text, "[^0-9/-]", "");
			DeveloperConsole.ExecuteCommand<CommandVigilanceSet>(new string[1] { _tmpValue });
		}

		public void FillFullStock()
		{
			DeveloperConsole.ExecuteCommand<CommandImpulse>(Array.Empty<string>());
		}
	}
}
