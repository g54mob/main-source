using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
	public class SettingDialog : BaseDialog
	{
		private enum eOptionCategory
		{
			General = 0,
			KeyConfig = 1,
			GamePadConfig = 2
		}

		[Serializable]
		public struct TempKeyBindData
		{
			public eGameAction gameAction;

			public string key;

			public string mouse;
		}

		public enum eOption
		{
			CursorSpeed = 1,
			CameraDistance = 2,
			CameraSpeed = 3,
			VisibleDamage = 4,
			InheritFavoritePalette = 5,
			EnableRemoveTimer = 6,
			EnableRemoveFavoriteConfirm = 7,
			ForceSetDefaultSpeedInBattleStart = 8,
			EnablePortPrioArrow = 9,
			UIScale = 10,
			Resolution = 100,
			Fps = 101,
			FullScreen = 102,
			LowLoad = 103,
			Vsync = 104,
			CameraShake = 105,
			MasterVolume = 200,
			BgmVolume = 201,
			SeVolume = 202
		}

		[Serializable]
		public struct OptionItem
		{
			public eOption option;

			public OptionItemBase optionItem;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDelayOneFrameAndCall_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SettingDialog _003C_003E4__this;

			private Cysharp.Threading.Tasks.YieldAwaitable.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private CategoryPageController categoryCtrl;

		[SerializeField]
		private GameObject backTitleButton;

		[SerializeField]
		private GameObject discardButton;

		[SerializeField]
		private GameObject tutorialSkipButton;

		[SerializeField]
		private GameObject tutorialRetryButton;

		[SerializeField]
		private GameObject keyConfigTab;

		[SerializeField]
		private List<CursorUIGroup> headGroup;

		[SerializeField]
		private CursorUIGroup gameSettingGroup;

		[SerializeField]
		private CursorUIGroup graphicSettingGroup;

		[SerializeField]
		private CursorUIGroup soundSettingGroup;

		[SerializeField]
		private CursorUIGroup underButtonGroup;

		[SerializeField]
		private List<CursorUIBase> gameSettingItems;

		[SerializeField]
		private List<CursorUIBase> onlyPcItems;

		private List<Resolution> resolutionList;

		private string[] preparedResolutions;

		[SerializeField]
		private List<int> targetFpsList;

		[SerializeField]
		private KeyConfigCell keyConfigCellPrefab;

		[SerializeField]
		private RectTransform keyConfigCellParent;

		[SerializeField]
		private RectTransform controllerConfigCellParent;

		[SerializeField]
		private GameObject keyBindBlindObj;

		[SerializeField]
		private GameObject keyBindEscExitText;

		[SerializeField]
		private GameObject keyBindExitButton;

		[SerializeField]
		private RectTransform keyBindDeleteDescription;

		[SerializeField]
		private CursorUIGroup _cellCursorUIGroup;

		[SerializeField]
		private CursorUIGroup _padCellCursorUIGroup;

		public TMP_Text title;

		public CanvasGroup background;

		private Sequence _sequence;

		private List<KeyConfigCell> keyConfigCells;

		private List<KeyConfigCell> padConfigCells;

		[SerializeField]
		private InputActionReference palletNext;

		[SerializeField]
		private InputActionReference palletPrev;

		[SerializeField]
		private InputActionReference holdMenu;

		[SerializeField]
		private InputActionReference openInventory;

		private InputAction palletNextAction;

		private InputAction palletPrevAction;

		private InputAction holdMenuAction;

		private InputAction openInventoryAction;

		private bool isInitialized;

		private int oldLocaleValue;

		[SerializeField]
		private List<TempKeyBindData> tempKeyBindDatas;

		private Dictionary<eGameAction, TempKeyBindData> tempKeyBindDatasDic;

		[SerializeField]
		private List<OptionItem> optionItems;

		private Dictionary<eOption, OptionItemBase> optionItemDic;

		private bool rebinding;

		private T GetOptionItem<T>(eOption op) where T : OptionItemBase
		{
			return null;
		}

		public override void Init()
		{
		}

		private void GetTargetInputAction()
		{
		}

		private void CreateKeyconfigContents()
		{
		}

		private void OnChangedValueKeyBindCell(InputAction inputAction, int bindingIndex, int selectedValue)
		{
		}

		private void OnMouseOverKeyBindCell(RectTransform rectTransform, bool isEnter)
		{
		}

		private void OnClickKeyBindDeleteCell(InputAction inputAction, int bindingIndex)
		{
		}

		private void OnClickKeyBindCell(InputAction inputAction, int bindingIndex)
		{
		}

		private void ChangeBinding(InputAction inputAction, int bindingIndex)
		{
		}

		private void SetRebindCategory()
		{
		}

		private void OnFinishRebindAction(InputManager.RebindOperationResult result, InputManager.RebindOperationErrorCode errorCode)
		{
		}

		public void CancelRebinding()
		{
		}

		public void ResetAllBinding()
		{
		}

		private List<(InputAction, int)> GetInputActionsForCurrentPage()
		{
			return null;
		}

		private List<KeyConfigCell> GetCurrentPageCells()
		{
			return null;
		}

		private void RefleshDisplay()
		{
		}

		[AsyncStateMachine(typeof(_003CDelayOneFrameAndCall_003Ed__64))]
		private UniTask DelayOneFrameAndCall()
		{
			return default(UniTask);
		}

		public void ShowErrorAnnounce(eErrorId errorId)
		{
		}

		public override void Open()
		{
		}

		private void SwitchButtons()
		{
		}

		public void OnSelectTutorialRetry()
		{
		}

		private void Update()
		{
		}

		private bool CanBeClosed()
		{
			return false;
		}

		public void BackTitleConfirm()
		{
		}

		public void DiscardPlay()
		{
		}

		public override void Back()
		{
		}

		private void BackTitle()
		{
		}

		private void QuitApplication()
		{
		}

		public void TutorialSkip()
		{
		}

		public void OnChangeCursorSpeed(OptionItemBase optionItem)
		{
		}

		public void OnChangeCameraDistance(OptionItemBase optionItem)
		{
		}

		public void OnChangeCameraSpeed(OptionItemBase optionItem)
		{
		}

		public void OnChangeVisibleDamageToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeInheritFavoritePaletteToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeEnableRemoveTimerToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeEnableRemoveFavoriteConfirmToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeForceSetDefaultSpeedInBattleStartToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeEnablePortPrioArrowToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeEnableUIScaleToggle(OptionItemBase optionItem)
		{
		}

		private void InitAudioSettings()
		{
		}

		public void OnChangeMasterVolume(OptionItemBase optionItem)
		{
		}

		public void OnChangeBGMVolume(OptionItemBase optionItem)
		{
		}

		public void OnChangeSEVolume(OptionItemBase optionItem)
		{
		}

		public void OnChangeFullScreenToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeLowLoadToggle(OptionItemBase optionItem)
		{
		}

		private void ChangeLowLoadMode(bool isLowLoadMode, bool immediately = true)
		{
		}

		public void OnChangeCameraShakeToggle(OptionItemBase optionItem)
		{
		}

		private void CreateResolutionDropdownItems()
		{
		}

		private Resolution[] GetResolutions()
		{
			return null;
		}

		public void OnChangeResolution(OptionItemBase optionItem)
		{
		}

		public void OnChangeVSyncToggle(OptionItemBase optionItem)
		{
		}

		public void OnChangeFPS(OptionItemBase optionItem)
		{
		}

		public override void SetInFront()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}

		public void OnDefaultGroupSelect()
		{
		}

		public void OnDefaultGroupSelectUp()
		{
		}

		public void NextCategory()
		{
		}

		public void PrevCategory()
		{
		}

		public void SelectGameSettingRight()
		{
		}

		public void SelectGameSettingGroup()
		{
		}

		public void SelectSoundGroupUp()
		{
		}
	}
}
