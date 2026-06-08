using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI.Components;
using Dorfromantik.UI.MainMenu;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameScreen : MonoBehaviour
{
	private sealed class _003CUpdateNavigationNextFrame_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveGameScreen _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CUpdateNavigationNextFrame_003Ed__29(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SaveGameScreen saveGameScreen = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (saveGameScreen.pendingNavigationUpdate)
				{
					return false;
				}
				saveGameScreen.pendingNavigationUpdate = true;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				saveGameScreen.UpdateNavigation();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<SaveGameUi, DateTime> _003C_003E9__34_0;

		internal DateTime _003CUpdateSaveGameOrder_003Eb__34_0(SaveGameUi x)
		{
			return x.LastPlayedTime;
		}
	}

	[SerializeField]
	private GameMode gameMode;

	[SerializeField]
	private bool hasSaveGames;

	[SerializeField]
	private SaveGameUi autoSaveUi;

	[SerializeField]
	private RectTransform saveGameContainer;

	[SerializeField]
	private MainMenuScreen navigationBar;

	[SerializeField]
	private GameObject newGameButton;

	[SerializeField]
	private SaveGameScreenToolbar saveGameScreenToolbar;

	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private SaveGameUi saveGameUiPrefab;

	[SerializeField]
	private SaveGameLoadingInitiator saveGameLoadingInitiator;

	[SerializeField]
	private CustomModePresetManager presetManager;

	private List<SaveGameUi> visibleSaveGameUis = new List<SaveGameUi>();

	private List<Selectable> allSelectables = new List<Selectable>();

	private GridLayoutGroup saveGameGridLayout;

	private ScrollRect scrollView;

	private Tween scrollTween;

	private bool initialized;

	private UiButton newGameUiButton;

	private bool pendingNavigationUpdate;

	private RectTransform currentSelectedChild;

	private SaveGameUi currentSelectedSaveGameUi;

	private MainMenuScreen mainMenuScreen;

	public event Action OnSaveFilesUpdated;

	private void OnEnable()
	{
		saveGameLoadingInitiator.SetSelectedGameMode(gameMode);
	}

	private void Awake()
	{
		saveFileManager.OnSaveGamesChanged += UpdateSaveFilesUi;
		saveFileManager.OnAutoSaveChanged += UpdateAutoSaveUi;
		mainMenuScreen = GetComponent<MainMenuScreen>();
		if (hasSaveGames)
		{
			saveGameGridLayout = saveGameContainer.GetComponent<GridLayoutGroup>();
			scrollView = GetComponentInChildren<ScrollRect>();
			newGameUiButton = newGameButton.GetComponentInChildren<UiButton>();
			newGameUiButton.OnSelected += delegate
			{
				OnSelectSaveGameUi(newGameUiButton.RectTransform, wasSelected: true);
			};
			newGameUiButton.OnDeselected += delegate
			{
				OnSelectSaveGameUi(newGameUiButton.RectTransform, wasSelected: false);
			};
		}
		if (saveFileManager.autoSaveGames != null)
		{
			UpdateAutoSaveUi(gameMode, saveFileManager.SetupSaveGameScreenshotsOnAwake);
			UpdateSaveFilesUi(gameMode, saveFileManager.SetupSaveGameScreenshotsOnAwake);
		}
	}

	private void UpdateSaveFilesUi(GameMode updatedGameMode)
	{
		UpdateSaveFilesUi(updatedGameMode, setupScreenshots: true);
	}

	private void UpdateSaveFilesUi(GameMode updatedGameMode, bool setupScreenshots)
	{
		if (gameMode != updatedGameMode || !hasSaveGames)
		{
			return;
		}
		foreach (SaveGameUi visibleSaveGameUi in visibleSaveGameUis)
		{
			UnityEngine.Object.Destroy(visibleSaveGameUi.gameObject);
		}
		visibleSaveGameUis = new List<SaveGameUi>();
		foreach (KeyValuePair<string, SaveGameData_003> item in saveFileManager.loadedSaveGames[gameMode])
		{
			CreateSaveGameUi(item.Value, setupScreenshots);
		}
		UpdateSaveGameOrder();
		LayoutRebuilder.MarkLayoutForRebuild(saveGameContainer);
		if (base.gameObject.activeInHierarchy)
		{
			mainMenuScreen.UpdateAndSelectDefaultSelectable();
			StartCoroutine(UpdateNavigationNextFrame());
		}
		else
		{
			UpdateNavigation();
		}
		this.OnSaveFilesUpdated?.Invoke();
	}

	private IEnumerator UpdateNavigationNextFrame()
	{
		return new _003CUpdateNavigationNextFrame_003Ed__29(0)
		{
			_003C_003E4__this = this
		};
	}

	private void UpdateNavigation()
	{
		Vector2 sizeDelta = saveGameGridLayout.GetComponent<RectTransform>().sizeDelta;
		Vector2 vector = saveGameGridLayout.cellSize + saveGameGridLayout.spacing;
		int num = Mathf.FloorToInt((sizeDelta.x - (float)saveGameGridLayout.padding.horizontal + saveGameGridLayout.spacing.x) / vector.x);
		allSelectables.Clear();
		if (saveFileManager.autoSaveGames[gameMode] != null && saveFileManager.autoSaveGames[gameMode].HasStarted && !saveFileManager.autoSaveGames[gameMode].HasSaveFile)
		{
			allSelectables.Add(autoSaveUi.uiSelectable);
		}
		allSelectables.Add(newGameUiButton);
		foreach (SaveGameUi visibleSaveGameUi in visibleSaveGameUis)
		{
			allSelectables.Add(visibleSaveGameUi.uiSelectable);
		}
		for (int i = 0; i < allSelectables.Count; i++)
		{
			Navigation navigation = allSelectables[i].navigation;
			navigation.mode = Navigation.Mode.Explicit;
			navigation.selectOnLeft = ((i % num == 0) ? navigationBar.defaultSelectable : allSelectables[i - 1]);
			navigation.selectOnRight = ((i % num != num - 1 && allSelectables.Count > i + 1) ? allSelectables[i + 1] : null);
			navigation.selectOnUp = ((i - num >= 0) ? allSelectables[i - num] : null);
			navigation.selectOnDown = ((allSelectables.Count > i + num) ? allSelectables[i + num] : null);
			allSelectables[i].navigation = navigation;
		}
		initialized = true;
		pendingNavigationUpdate = false;
	}

	private void UpdateAutoSaveUi(GameMode updatedGameMode)
	{
		UpdateAutoSaveUi(updatedGameMode, setupScreenshots: true);
	}

	private void UpdateAutoSaveUi(GameMode updatedGameMode, bool setupScreenshots)
	{
		if (!(gameMode != updatedGameMode) && hasSaveGames)
		{
			SaveGameData_003 saveGameData_ = saveFileManager.autoSaveGames[gameMode];
			autoSaveUi.Setup(this, (saveGameData_ == null || saveGameData_.HasSaveFile) ? null : saveGameData_, isAutosaveContainer: true, setupScreenshots);
			UpdateNavigation();
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(UpdateNavigationNextFrame());
			}
			else
			{
				UpdateNavigation();
			}
			this.OnSaveFilesUpdated?.Invoke();
		}
	}

	private void CreateSaveGameUi(SaveGameData_003 saveGameData, bool setupScreenshot)
	{
		SaveGameUi saveGameUi = UnityEngine.Object.Instantiate(saveGameUiPrefab, saveGameContainer);
		saveGameUi.Setup(this, saveGameData, isAutosaveContainer: false, setupScreenshot);
		saveGameUi.transform.SetAsLastSibling();
		visibleSaveGameUis.Add(saveGameUi);
	}

	private void UpdateSaveGameOrder()
	{
		int num = GetComponentsInChildren<SaveGameUi>().Length - visibleSaveGameUis.Count;
		visibleSaveGameUis = Enumerable.ToList(Enumerable.OrderByDescending(visibleSaveGameUis, (SaveGameUi x) => x.LastPlayedTime));
		for (int num2 = 0; num2 < visibleSaveGameUis.Count; num2++)
		{
			visibleSaveGameUis[num2].transform.SetSiblingIndex(num2 + num + 2);
		}
	}

	private void OnDestroy()
	{
		saveFileManager.OnSaveGamesChanged -= UpdateSaveFilesUi;
		saveFileManager.OnAutoSaveChanged -= UpdateAutoSaveUi;
	}

	public void RemoveUi(SaveGameUi saveGameUi)
	{
		visibleSaveGameUis.Remove(saveGameUi);
		UnityEngine.Object.Destroy(saveGameUi.gameObject);
		LayoutRebuilder.ForceRebuildLayoutImmediate(saveGameContainer);
	}

	public void OnSelectSaveGameUi(RectTransform targetSaveGameUi, bool wasSelected)
	{
		if (currentSelectedChild == targetSaveGameUi && !wasSelected)
		{
			currentSelectedChild = null;
			saveGameScreenToolbar.SetInfoState(TooltipBarInfoState.None);
		}
		else if (currentSelectedChild != targetSaveGameUi && wasSelected)
		{
			currentSelectedChild = targetSaveGameUi;
			currentSelectedSaveGameUi = currentSelectedChild.GetComponent<SaveGameUi>();
			if ((bool)currentSelectedSaveGameUi)
			{
				saveGameScreenToolbar.SetInfoState((currentSelectedSaveGameUi == autoSaveUi) ? TooltipBarInfoState.AutoSaveGameUi : TooltipBarInfoState.SaveGameUi);
			}
			else if ((bool)currentSelectedChild.GetComponent<UiButton>())
			{
				saveGameScreenToolbar.SetInfoState(TooltipBarInfoState.NewSaveGameButton);
			}
		}
	}

	public void InitiateDeleteCurrentSelectedSaveGame()
	{
		if ((bool)currentSelectedSaveGameUi)
		{
			currentSelectedSaveGameUi.InitiateDelete();
		}
	}

	public void InitiateSaveCurrentSelectedSaveGame()
	{
		if ((bool)currentSelectedSaveGameUi)
		{
			currentSelectedSaveGameUi.Save();
		}
	}

	private void _003CAwake_003Eb__26_0()
	{
		OnSelectSaveGameUi(newGameUiButton.RectTransform, wasSelected: true);
	}

	private void _003CAwake_003Eb__26_1()
	{
		OnSelectSaveGameUi(newGameUiButton.RectTransform, wasSelected: false);
	}
}
