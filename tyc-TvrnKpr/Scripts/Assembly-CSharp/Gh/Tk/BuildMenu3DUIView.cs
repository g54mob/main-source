using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class BuildMenu3DUIView : ShowHideAnimation3DUIView
	{
		private UIController _uc;

		public Button3DUIView previousPageButton;

		public Button3DUIView nextPageButton;

		public Button3DUIView chooseSortingButton;

		public GameObject sortIconDefault;

		public GameObject sortIconName;

		public GameObject sortIconStar;

		public GameObject sortIconCost;

		public Button3DUIView cancelZoningButton;

		public BuyButton3DUIView confirmZoningButton;

		public Button3DUIView zoningModeButton;

		public Button3DUIView propModeButton;

		public Button3DUIView decorationModeButton;

		public Button3DUIView demolishModeButton;

		[FormerlySerializedAs("buildPickerButton")]
		public Button3DUIView cloneToolButton;

		public ShowHideAnimation3DUIView selectionButtons;

		public GameObject selectionButtonsParent;

		public GameObject sortingPanel;

		public ShowHideAnimation3DUIView filterButtonArea;

		[SerializeField]
		private GameObject[] _subCategoryButtonVisuals;

		public GameObject subCategoryButtonsParent;

		public GameObject cycleVariantsButtons;

		public GameObject confirmDialog;

		public Button3DUIView textCreatorButton;

		public int maxSelectionButtons;

		public int decorationCategoryPanels;

		public BuildablePanel3DUIView variantPanel;

		public Transform[] propAlignmentSockets;

		[SerializeField]
		private Button3DUIView _wallToggleButton;

		[SerializeField]
		private GameObject _wallGo;

		[SerializeField]
		private GameObject _noWallGo;

		[SerializeField]
		private Transform _selectionButtonsParent;

		[SerializeField]
		private Button3DUIView _selectionButtonsBackground;

		[SerializeField]
		private GameObject _propHotkeysHelper;

		private Sequence _propHotkeyShowSequence;

		private Sequence _propHotkeyHideSequence;

		[SerializeField]
		private GameObject _decorationsHotkeysHelper;

		private Sequence _decorationsHotkeyShowSequence;

		private Sequence _decorationsHotkeyHideSequence;

		private float _selectionButtonsShowY;

		private float _selectionButtonsHideY;

		private float _hotkeysShowY;

		private float _hotkeysHideY;

		[SerializeField]
		private float _hotkeyShowDuration;

		[SerializeField]
		private Ease _hotkeyShowEase;

		[SerializeField]
		private float _hotkeyHideDuration;

		[SerializeField]
		private Ease _hotkeyHideEase;

		private TextSizeGroup _buildPropButtonTextSizeGroup;

		[SerializeField]
		private GameObject _noSearchMatchesVisual;

		public void Start()
		{
		}

		private void UpdateWallToggleButtonVisual()
		{
		}

		protected void InitSortingButton()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		private void OnCostChanged(object sender, EventArgs e)
		{
		}

		private void SetParentSlot(Transform button, Transform transform, string slotName)
		{
		}

		public void UpdateSortingButton()
		{
		}

		private void Update()
		{
		}

		private void UpdateHotkeys()
		{
		}

		public void ShowHotkeys()
		{
		}

		private void ShowHotkeys(GameObject currentHotKeysHelper, ref Sequence currentShowSequence, ref Sequence currentHideSequence)
		{
		}

		public void HideHotkeys(bool isClosing = false)
		{
		}

		private void HideHotkeys(bool isClosing, GameObject currentHotKeysHelper, ref Sequence currentShowSequence, ref Sequence currentHideSequence)
		{
		}

		public void SetSubCategoryButtons(bool isVisible)
		{
		}

		public void UpdateBuildPropTextSizes()
		{
		}

		public void SetNoSearchMatchesVisual(bool isVisible)
		{
		}
	}
}
