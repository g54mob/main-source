using System.Collections.Generic;
using Factory.UI;
using InputControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
	public class SelectMachineDialog : BaseDialog
	{
		[Header("Prefab")]
		[SerializeField]
		private SelectMachineCategoryPanelCtrl categoryPanelPrefab;

		[Header("Other")]
		[SerializeField]
		private RectTransform contentsParent;

		[SerializeField]
		private ToggleGroup toggleGroup;

		[SerializeField]
		private GameObject removeFavoriteConfirmWindow;

		[SerializeField]
		private GameObject unmaskObj;

		[SerializeField]
		private PadInputConfigure _padInputConfigure;

		[SerializeField]
		private InputActionReference _inputAction;

		[SerializeField]
		private CursorUIGroup _dummyGroup;

		[SerializeField]
		private CursorUIGroup _mainGroup;

		[SerializeField]
		private CursorUIGroup _favoriteGroup;

		[Header("Favorite")]
		[SerializeField]
		private SelectMachineCategoryPanelCtrl favoritePanelCtrl;

		[Header("Cursor")]
		[SerializeField]
		private RectTransform cursor;

		private List<ArtifactPaletteCtrl.PaletteData> paletteDataList;

		private List<eMachine> favoriteList;

		private ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo;

		private int diffIndex;

		private List<SelectMachineCategoryPanelCtrl> categoryPanelList;

		private eMachine removeFavoriteMachineId;

		private CursorUIBase _currentCursorUI;

		private InputAction _action;

		private SelectMachineCategoryPanelCtrl currentCategoryCtrl;

		private PaletteItemCtrl currentItemCtrl;

		private bool openPadMode;

		private bool isFavoriteAfter;

		private int _lastPlayedFrame;

		private const int PlayInterval = 3;

		private List<CursorUIBase> AllMainCursorUIItems => null;

		private List<CursorUIBase> AllFavoriteCursorUIItems => null;

		private List<PaletteItemCtrl> AllPaletteItemCtrls => null;

		private List<SelectMachineCategoryPanelCtrl> AllCategoryPanelCtrls => null;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		private void UpdateContents(bool initialize = false)
		{
		}

		public void UpdateUI()
		{
		}

		private void CopySelectedItemInfo(ArtifactPaletteCtrl.SelectedItemInfo newInfo)
		{
		}

		private bool IsSameData(List<ArtifactPaletteCtrl.PaletteData> newList)
		{
			return false;
		}

		private bool IsChangeSelectedItem(ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo)
		{
			return false;
		}

		private void UpdateSelectedItem()
		{
		}

		private void UpdatePanels(ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo)
		{
		}

		public void UpdateCursor()
		{
		}

		private void UpdateFavorite()
		{
		}

		public void SelectMachine(SelectMachineCategoryPanelCtrl categoryCtrl, PaletteItemCtrl itemCtrl, PointerEventData pointerEventData)
		{
		}

		public void SwitchFavorite(SelectMachineCategoryPanelCtrl categoryCtrl, PaletteItemCtrl itemCtrl)
		{
		}

		private void OpenRemoveFavoriteConfirmWindow(SelectMachineCategoryPanelCtrl categoryCtrl, PaletteItemCtrl itemCtrl)
		{
		}

		private void CloseRemoveFavoriteConfirmWindow()
		{
		}

		public void OnOkRemoveFavorite()
		{
		}

		public void OnCancelRemoveFavorite()
		{
		}

		public void OnPointerEnterItem(ArtifactPaletteCtrl.PaletteItemData itemData)
		{
		}

		public void OnPointerExitItem()
		{
		}

		public override void Back()
		{
		}

		private void Update()
		{
		}

		private bool GetHoldButtonPressed()
		{
			return false;
		}

		private void SetInitialCursor(CursorUIBase cursor = null, bool isInit = false)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnInputActionPerformed(InputAction.CallbackContext context)
		{
		}

		public void SetCursor(GameObject targetObj)
		{
		}

		public void DisableCursor()
		{
		}

		private void PlaySelectSE()
		{
		}

		private void CloseItemDecide()
		{
		}
	}
}
