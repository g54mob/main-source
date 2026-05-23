using System.Collections.Generic;
using DG.Tweening;
using Factory.FieldData;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Factory.UI
{
	public class ArtifactPaletteCtrl : SingletonMonoBehaviour<ArtifactPaletteCtrl>
	{
		public class PaletteData
		{
			public PaletteCategoryData categoryData;

			public List<PaletteItemData> itemDataList;
		}

		public class PaletteCategoryData
		{
			public int categoryNumber;

			public ePaletteCategory paletteCategory;
		}

		public class PaletteItemData
		{
			public int itemNumber;

			public MstMachineDataEntities machineData;

			public ExtMachineData extMachineData;
		}

		public class SelectedItemInfo
		{
			public PaletteCategoryData categoryData;

			public PaletteItemData itemData;
		}

		[SerializeField]
		private SelectCategoryPaletteCtrl categoryPaletteCtrl;

		[SerializeField]
		private SelectItemPaletteCtrl itemPaletteCtrl;

		[SerializeField]
		private ArtifactDescriptionCtrl descCtrl;

		[SerializeField]
		private ArtifactDescriptionCtrl inventoryDescCtrl;

		[SerializeField]
		private TMP_Text nameText;

		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private AnimatedImage gifPlayer;

		[SerializeField]
		private GameObject removeFavoriteConfirmWindow;

		[SerializeField]
		private RectTransform padGuide;

		[SerializeField]
		private RectTransform tutorialPadGuide;

		[SerializeField]
		private RectTransform tutorialPadGuideCursor;

		private Sequence _descSequence;

		private List<PaletteData> paletteDataList;

		private int selectedCategoryNumber;

		private Dictionary<ePaletteCategory, Dir.Rot> paletteRot;

		private List<eMachine> paletteItemFavorite;

		private const int paletteFavoriteIndex = 0;

		private List<eMachine> paletteItemHistory;

		private const int paletteHistoryIndex = 0;

		private List<SelectedItemInfo> selectedItemInfoList;

		private InputActionController input;

		private int removeFavoriteItemIndex;

		private eMachine currentMachine;

		public bool EnableShortcut => false;

		private SelectedItemInfo selectedItemInfo => null;

		private static Dir.Rot DefaultRot => default(Dir.Rot);

		public (List<PaletteData>, List<eMachine>, SelectedItemInfo) GetData()
		{
			return default((List<PaletteData>, List<eMachine>, SelectedItemInfo));
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Init(FactoryContext fc)
		{
		}

		public void UpdatePaletteData()
		{
		}

		private bool IsDebugmode()
		{
			return false;
		}

		private List<PaletteCategoryData> CreateDataList()
		{
			return null;
		}

		public virtual void SortPaletteItems()
		{
		}

		public void UpdateItems(int categoryNumber)
		{
		}

		public void UpdateItemUI()
		{
		}

		private void InitializeHistoryData()
		{
		}

		private bool IsTemporaryAndEmpty(eMachine id)
		{
			return false;
		}

		private void InitializeFavoriteData()
		{
		}

		private void CheckFavoritePalette()
		{
		}

		public void SaveFavoritePalette()
		{
		}

		public void UpdateHistory()
		{
		}

		public void SwitchFavorite(eMachine machine, PaletteItemCtrl itemCtrl, bool removeConfirm = true)
		{
		}

		public void SwitchFavorite(eMachine machine)
		{
		}

		public void SetFavorite(eMachine machine)
		{
		}

		public bool IsFavorite(eMachine machine)
		{
			return false;
		}

		private void ClearFavorite(int itemIndex)
		{
		}

		public void ClearFavorite(eMachine machine)
		{
		}

		private void OpenRemoveFavoriteConfirmWindow(int itemIndex, PaletteItemCtrl itemCtrl)
		{
		}

		public void OnOkRemoveFavorite()
		{
		}

		public void OnCancelRemoveFavorite()
		{
		}

		private void CloseRemoveFavoriteConfirmWindow()
		{
		}

		public void OnChangeCategory(int categoryNumber)
		{
		}

		public void OnClickItem(PaletteItemData itemData, PointerEventData pointerEventData, PaletteItemCtrl itemCtrl)
		{
		}

		public void OnPointerEnterItem(PaletteItemData itemData)
		{
		}

		public void OnPointerExitItem()
		{
		}

		public void ShowMachineDescription(eMachine machine)
		{
		}

		public void HideMachineDescription(eMachine hideMachine = eMachine.None)
		{
		}

		private void ShowMachineDescriptionSequence(eMachine machine)
		{
		}

		public (MstMachineDataEntities, ExtMachineData, Dir.Rot) GetCurrentData()
		{
			return default((MstMachineDataEntities, ExtMachineData, Dir.Rot));
		}

		public eMachine GetCurrentMachineID()
		{
			return default(eMachine);
		}

		private ePaletteCategory GetCurrentPaletteCategory()
		{
			return default(ePaletteCategory);
		}

		public void SetPaletteRot(Dir.Rot rot)
		{
		}

		private (bool, int, PaletteItemData) SearchMachineId(eMachine spuitId, ePaletteCategory category = ePaletteCategory.None, int categoryNumber = -1)
		{
			return default((bool, int, PaletteItemData));
		}

		public PaletteItemCtrl SearchPalettleItemCtrlByMachineId(eMachine spuitId)
		{
			return null;
		}

		public (eMachine, Dir.Rot?) SetCurrentMachineID(eMachine spuitId, Dir.Rot? spuitRot = null)
		{
			return default((eMachine, Dir.Rot?));
		}

		public void NextItem()
		{
		}

		public void PrevItem()
		{
		}

		public void SetCurrentMachineID(int categoryNumber, ePaletteCategory category, eMachine machine)
		{
		}

		public void OpenInventory()
		{
		}

		private void MoveGuide()
		{
		}

		public void SetTutorialPadGuide(bool isOn)
		{
		}

		public GameObject GetCategoryTabObj(eMachine machine)
		{
			return null;
		}
	}
}
