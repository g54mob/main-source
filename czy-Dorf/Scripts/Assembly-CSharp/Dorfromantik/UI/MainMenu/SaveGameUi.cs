using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.UI.MainMenu
{
	public class SaveGameUi : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, ISubmitHandler
	{
		[SerializeField]
		private SaveFileUiMode mode = SaveFileUiMode.LoadGame;

		[SerializeField]
		internal UiSelectable uiSelectable;

		[SerializeField]
		private GameObject cardContainer;

		[SerializeField]
		private TextMeshProUGUI lastPlayedLabel;

		[SerializeField]
		private TextMeshProUGUI scoreLabel;

		[SerializeField]
		private Image screenshot;

		[SerializeField]
		private RawImage screenshotRaw;

		[SerializeField]
		private GameObject buttonContainer;

		[SerializeField]
		private GameObject gradientShadow;

		[SerializeField]
		private GameObject dropShadow;

		[SerializeField]
		private GameObject borderSelected;

		[SerializeField]
		private SaveGameLoadingInitiator saveGameLoadingInitiator;

		[SerializeField]
		private GameObject saveButton;

		[SerializeField]
		private GameObject deleteButton;

		[SerializeField]
		private SaveFileManager saveFileManager;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private UiVisualState uiVisualState;

		private DateTime _003CLastPlayedTime_003Ek__BackingField;

		private SaveGameData_003 savegameData;

		private SaveGameScreen saveGameScreen;

		private bool imageLoaded;

		private Sequence onInteractionSequence;

		private bool isAutosaveContainer;

		public Vector2Int cellPos;

		private RectTransform _003CRectTransform_003Ek__BackingField;

		public DateTime LastPlayedTime
		{
			get
			{
				return _003CLastPlayedTime_003Ek__BackingField;
			}
			private set
			{
				_003CLastPlayedTime_003Ek__BackingField = value;
			}
		}

		public RectTransform RectTransform
		{
			get
			{
				return _003CRectTransform_003Ek__BackingField;
			}
			private set
			{
				_003CRectTransform_003Ek__BackingField = value;
			}
		}

		protected void OnEnable()
		{
			LocalizationManager.Instance.OnLanguageChanged += UpdateLabel;
			UpdateLabel();
			if (!uiSelectable.IsSelected)
			{
				SetVisualState(UiVisualState.Default);
			}
		}

		protected void Awake()
		{
			RectTransform = GetComponent<RectTransform>();
			if (uiSelectable == null)
			{
				GetComponentInChildren<UiSelectable>();
			}
		}

		protected void Start()
		{
			if (!imageLoaded && savegameData?.screenshot != null)
			{
				Texture2D texture2D = new Texture2D(512, 512, TextureFormat.RGB24, mipChain: false);
				ImageConversion.LoadImage(texture2D, savegameData.screenshot);
				screenshotRaw.texture = texture2D;
				imageLoaded = true;
			}
		}

		public void Setup(SaveGameScreen screen, SaveGameData_003 loadedSaveGame, bool isAutosaveContainer, bool setupScreenshot)
		{
			savegameData = loadedSaveGame;
			saveGameScreen = screen;
			this.isAutosaveContainer = isAutosaveContainer;
			base.gameObject.SetActive(loadedSaveGame?.HasStarted ?? false);
			if (loadedSaveGame != null && loadedSaveGame.HasStarted)
			{
				SetMode(mode);
				if (setupScreenshot && savegameData?.screenshot != null)
				{
					Texture2D texture2D = new Texture2D(512, 512, TextureFormat.RGB24, mipChain: false);
					ImageConversion.LoadImage(texture2D, savegameData.screenshot);
					screenshotRaw.texture = texture2D;
					imageLoaded = true;
				}
				UpdateLabel();
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			OnPointerEnter(null);
			if ((bool)saveGameScreen)
			{
				saveGameScreen.OnSelectSaveGameUi(RectTransform, wasSelected: true);
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			OnPointerExit(null);
			if ((bool)saveGameScreen)
			{
				saveGameScreen.OnSelectSaveGameUi(RectTransform, wasSelected: false);
			}
		}

		private void UpdateLabel()
		{
			if (savegameData == null)
			{
				return;
			}
			int[] lastPlayed = savegameData.lastPlayed;
			if (lastPlayed != null && lastPlayed.Length == 6)
			{
				LastPlayedTime = new DateTime(savegameData.lastPlayed[0], savegameData.lastPlayed[1], savegameData.lastPlayed[2], savegameData.lastPlayed[3], savegameData.lastPlayed[4], savegameData.lastPlayed[5]);
				if (savegameData.gameMode == GameModeId.Monthly)
				{
					lastPlayedLabel.text = $"{savegameData.customModeData.month:00}/{savegameData.customModeData.year:0000}";
				}
				else
				{
					lastPlayedLabel.text = LastPlayedTime.ToString(LocalizationManager.Instance.CultureInfo.DateTimeFormat.ShortDatePattern);
				}
				if (settingsRouter.displaySaveFileNames)
				{
					lastPlayedLabel.text = savegameData.fileName + "\n" + lastPlayedLabel.text;
				}
			}
			scoreLabel.text = savegameData.score.ToString();
			scoreLabel.enabled = savegameData.gameMode != GameModeId.Creative;
		}

		public void Save()
		{
			Debug.Log("Save AutoSave");
			saveGameLoadingInitiator.InitiateCreateNewSaveFileForAutosaveInSelectedGameMode(0);
		}

		public void InitiateDelete()
		{
			saveGameLoadingInitiator.SetSelectedSaveGame(savegameData);
			Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.DeleteSaveGame);
		}

		protected void OnDisable()
		{
			if ((bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged -= UpdateLabel;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (mode != SaveFileUiMode.NonInteractable)
			{
				SetVisualState(UiVisualState.Highlighted);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (mode != SaveFileUiMode.NonInteractable)
			{
				SetVisualState(UiVisualState.Default);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			switch (mode)
			{
			case SaveFileUiMode.LoadGame:
				if (isAutosaveContainer)
				{
					saveGameLoadingInitiator.LoadAutosaveInSelectedGameMode();
				}
				else
				{
					saveGameLoadingInitiator.InitiateLoadGame(savegameData);
				}
				break;
			case SaveFileUiMode.OverwriteGame:
				saveGameLoadingInitiator.InitiateOverwriteSaveGame(savegameData);
				break;
			}
		}

		private void SetVisualState(UiVisualState uiVisualState)
		{
			Sequence sequence = onInteractionSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onInteractionSequence = DOTween.Sequence();
			RectTransform component = gradientShadow.GetComponent<RectTransform>();
			Image component2 = gradientShadow.GetComponent<Image>();
			switch (uiVisualState)
			{
			case UiVisualState.Default:
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(lastPlayedLabel.gameObject.GetComponent<CanvasGroup>(), 0f, 0.4f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(buttonContainer.GetComponent<CanvasGroup>(), 0f, 0.4f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(borderSelected.GetComponent<CanvasGroup>(), 0f, 0.4f));
				TweenSettingsExtensions.Insert(t: DOTweenModuleUI.DOSizeDelta(component, new Vector2(component.sizeDelta.x, 75f), 0.75f), s: onInteractionSequence, atPosition: 0f);
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(component2, 0.6f, 0.75f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOLocalMoveY(cardContainer.transform, 0f, 0.2f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOScale(dropShadow.transform, 1f, 0.2f));
				break;
			case UiVisualState.Highlighted:
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(lastPlayedLabel.gameObject.GetComponent<CanvasGroup>(), 1f, 0.3f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0.2f, DOTweenModuleUI.DOFade(buttonContainer.GetComponent<CanvasGroup>(), 1f, 0.3f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(borderSelected.GetComponent<CanvasGroup>(), 1f, 0.4f));
				TweenSettingsExtensions.Insert(t: DOTweenModuleUI.DOSizeDelta(component, new Vector2(component.sizeDelta.x, 250f), 0.5f), s: onInteractionSequence, atPosition: 0f);
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(component2, 0.7f, 0.5f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOLocalMoveY(cardContainer.transform, 15f, 0.3f));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, ShortcutExtensions.DOScale(dropShadow.transform, 0.8f, 0.3f));
				break;
			default:
				throw new ArgumentOutOfRangeException("uiVisualState", uiVisualState, null);
			case UiVisualState.Active:
				break;
			}
			this.uiVisualState = uiVisualState;
		}

		public void OnSubmit(BaseEventData eventData)
		{
			OnPointerClick(null);
		}

		public void SetMode(SaveFileUiMode uiMode)
		{
			mode = uiMode;
			saveButton.SetActive(mode == SaveFileUiMode.LoadGame && !savegameData.HasSaveFile);
			deleteButton.SetActive(mode == SaveFileUiMode.LoadGame);
		}
	}
}
