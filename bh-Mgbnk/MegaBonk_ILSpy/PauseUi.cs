using System;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class PauseUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__12_0;

		public static Action _003C_003E9__17_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CExit_003Eb__12_0()
		{
			TransitionUI.Instance.LoadMenu();
		}

		internal void _003CRestart_003Eb__17_0()
		{
			MapController.RestartRun();
		}
	}

	public GameObject main;

	public GameObject options;

	public GameObject map;

	private GameObject current;

	public Window mainWindow;

	public Window mapWindow;

	public UpgradeInventoryUI inventory;

	private bool wasGamePaused;

	private void Awake()
	{
		GoToWindow(main);
	}

	private void Update()
	{
		GameObject gameObject = base.gameObject;
		if (!gameObject.activeInHierarchy || (!main.activeSelf && !map.activeSelf))
		{
			return;
		}
		AlwaysUi instance = AlwaysUi.Instance;
		if (!instance.dynamicWindows.HasWindows() && !PlayerInput.IsConsoleOpen())
		{
			if (MyInputManager.GetButtonDown(MyInputManager.MapOverlay))
			{
				GoToWindow(map);
			}
			if (MyInputManager.GetButtonUp(MyInputManager.MapOverlay))
			{
				GoToWindow(main);
			}
		}
	}

	public void Pause()
	{
		if (!(GameManager.Instance != null))
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if (instance.cutscene)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			return;
		}
		GameManager instance2 = GameManager.Instance;
		if (!instance2.isPlaying)
		{
			return;
		}
		UiManager instance3 = UiManager.Instance;
		if (!instance3.encounterWindows.HasEncounter())
		{
			GameObject gameObject2 = base.gameObject;
			if (!gameObject2.activeInHierarchy)
			{
				GameObject gameObject3 = base.gameObject;
				gameObject3.SetActive(value: true);
				inventory.Refresh();
				Transform transform = inventory.transform;
				Transform parent = transform.parent;
				UiUtility.RebuildUi(parent);
			}
		}
	}

	public void Resume()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public bool CanPause()
	{
		//IL_017c: Expected I4, but got O
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance == null)
			{
				goto IL_016e;
			}
			if (!instance.cutscene)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject == null)
				{
					goto IL_016e;
				}
				if (!gameObject.activeInHierarchy)
				{
					GameManager instance2 = GameManager.Instance;
					if ((object)GameManager.Instance == null)
					{
						goto IL_016e;
					}
					if (instance2.isPlaying)
					{
						UiManager instance3 = UiManager.Instance;
						if ((object)UiManager.Instance == null || (object)instance3.encounterWindows == null)
						{
							goto IL_016e;
						}
						if (!instance3.encounterWindows.HasEncounter())
						{
							return true;
						}
					}
				}
			}
		}
		return false;
		IL_016e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void Exit()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("Main Menu", "MENU_BUTTON_EXIT_GAME");
		string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "EXIT_RUN");
		Action a_Accept = _003C_003Ec._003C_003E9__12_0;
		if (_003C_003Ec._003C_003E9__12_0 == null)
		{
			a_Accept = (_003C_003Ec._003C_003E9__12_0 = delegate
			{
				TransitionUI.Instance.LoadMenu();
			});
		}
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	public void GoToMain()
	{
		GoToWindow(main);
	}

	public void GoToOptions()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180556B40\"");
	}

	public void GoToMap()
	{
		GoToWindow(map);
	}

	private void GoToWindow(GameObject window)
	{
		if (current != null)
		{
			current.SetActive(value: false);
		}
		current = window;
		current.SetActive(value: true);
	}

	public void Restart()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_PauseUi", "RESTART");
		string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "RESTART");
		Action a_Accept = _003C_003Ec._003C_003E9__17_0;
		if (_003C_003Ec._003C_003E9__17_0 == null)
		{
			a_Accept = (_003C_003Ec._003C_003E9__17_0 = delegate
			{
				MapController.RestartRun();
			});
		}
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	public void Toggle()
	{
		GameObject gameObject = main.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			Pause();
			return;
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (!wasGamePaused)
		{
			MyTime.Unpause();
		}
	}

	private void OnEnable()
	{
		wasGamePaused = MyTime.paused;
		MyTime.Pause();
	}

	public bool IsPaused()
	{
		//IL_0047: Expected I4, but got O
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			return gameObject.activeInHierarchy;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
