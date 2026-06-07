using System;
using System.Collections.Generic;
using System.Diagnostics;
using Placemaker.SceneProcessing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class SaveMenu : UIBehaviour, UiMaster.IUiSetup, IOnScenePostProcess
	{
		public enum StatusUIState : byte
		{
			Closed = 0,
			Open = 1,
			Focus = 2
		}

		private enum MenuInitState : byte
		{
			Begin = 0,
			RefreshFiles = 1,
			SaveCards = 2,
			Done = 3
		}

		private enum OpenSaveMenuState : byte
		{
			Begin = 0,
			StartSavingGame = 1,
			SavingGame = 2,
			SetLastCard = 3,
			SortCards = 4,
			OpenUI = 5,
			Done = 6
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private BetterScrollRect cardsListScrollRect;

		[SerializeField]
		private Transform scaleAnim;

		[SerializeField]
		private RectTransform gridSizeScaling;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[Space]
		private RawImage tallFocusedImage;

		[SerializeField]
		private RawImage wideFocusedImage;

		[SerializeField]
		private CanvasGroup focusCanvasGroup;

		[SerializeField]
		private RectTransform focusFrame;

		[SerializeField]
		private Transform focusScaleAnim;

		[SerializeField]
		private RectTransform saveCardContainer;

		[SerializeField]
		private RectTransform focusPlacement;

		[SerializeField]
		private RectTransform tallFocusFrame;

		[SerializeField]
		private RectTransform wideFocusFrame;

		[SerializeField]
		private RectTransform tallFocusButtonContainer;

		[SerializeField]
		private RectTransform wideFocusButtonContainer;

		[SerializeField]
		private RectTransform focusCopy;

		[SerializeField]
		private SaveCard focusedCard;

		[SerializeField]
		private Graphic focusGamepadCursor0;

		[SerializeField]
		private Graphic focusGamepadCursor1;

		[SerializeField]
		private BaseButton selectedFocusButton;

		[SerializeField]
		private RectTransform focusButtonContainer;

		private List<BaseButton> focusButtons;

		[Space]
		[SerializeField]
		private SaveCard srcSaveCard;

		[SerializeField]
		private SaveCard gamepadCard;

		[SerializeField]
		private CanvasGroup gamepadCursor;

		[SerializeField]
		public MenuMusic menuMusic;

		private RapidButton rapidGamepadButton;

		[SerializeField]
		private GridLayoutGroup grid;

		[SerializeField]
		private List<SaveCard> saveCards;

		public UpdateState visibleState;

		public UpdateState openState;

		public UpdateState focusCardState;

		public UpdateState menuScaleState;

		public UpdateState gamepadState;

		public UpdateState focusGamepadState;

		private bool snapFocusGamepad;

		private bool gridSizeDirty;

		[SerializeField]
		private MenuInitState menuInitState;

		[SerializeField]
		private SimpleMessage focusedCardDuplicateMessage;

		private const float focusedCardHeldTime = 0.2f;

		private Stopwatch stopwatch;

		[SerializeField]
		private MaxSavesCounter maxSavesCounter;

		public Action<int> onTotalSaveGameCountUpdate;

		private int index;

		private int count;

		public void Toggle()
		{
		}

		public void SnapScrolls()
		{
		}

		public void SetUIState(StatusUIState state)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		private void OnDimensionsChange()
		{
		}

		private void SetGridRect()
		{
		}

		public void SetGridRectSizeDirty()
		{
		}

		private void MaybeUpdateGridRectSize()
		{
		}

		private void SetFocusFrameScale()
		{
		}

		public void OpenWithoutRefresh()
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void Button_SideCancel(BaseButton button)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private bool KeepGoing()
		{
			return false;
		}

		private bool MenuInit(Func<bool> keepGoing)
		{
			return false;
		}

		private void GamepadUpdate()
		{
		}

		private void FocusGamepadUpdate()
		{
		}

		public void Clicked(SaveCard card)
		{
		}

		public void CancelFocusClicked()
		{
		}

		private void ExecuteIfSaveSystemAllows(Action methodToExecute, SimpleMessage infoMessageElement)
		{
		}

		public void NewButton(BaseButton button)
		{
		}

		public void Button_Focus_Load()
		{
		}

		public void Button_Focus_CopyToClipboard()
		{
		}

		public void Button_Focus_Duplicate()
		{
		}

		public void Button_Focus_Delete_Down()
		{
		}

		public void Button_Focus_Delete_Full(BaseButton button)
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}

		private void SortAllCards()
		{
		}

		public void ResetNavigation()
		{
		}

		public void ResetSaveCardOrder()
		{
		}
	}
}
