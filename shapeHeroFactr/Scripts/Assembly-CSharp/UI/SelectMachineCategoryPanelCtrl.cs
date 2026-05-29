using System.Collections.Generic;
using Factory.UI;
using InputControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class SelectMachineCategoryPanelCtrl : MonoBehaviour
	{
		[Header("Prefab")]
		[SerializeField]
		private PaletteItemCtrl itemPrefab;

		[Header("Other")]
		[SerializeField]
		private RectTransform contentsParent;

		[SerializeField]
		private Image categoryIcon;

		[Header("Cursor")]
		[SerializeField]
		private Image selectCursorBG;

		private ArtifactPaletteCtrl.PaletteData paletteData;

		private List<PaletteItemCtrl> itemList;

		private UnityAction<SelectMachineCategoryPanelCtrl, PaletteItemCtrl, PointerEventData> onClickAction;

		private UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnterAction;

		private UnityAction onPointerExitAction;

		private UnityAction<GameObject> onCursorEnterAction;

		private UnityAction onCursorExitAction;

		public ArtifactPaletteCtrl.PaletteCategoryData categoryData => null;

		public IEnumerable<CursorUIBase> CursorUIList => null;

		public IEnumerable<PaletteItemCtrl> ItemList => null;

		public void Init(ArtifactPaletteCtrl.PaletteData paletteData, List<eMachine> favoriteList, ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo, ToggleGroup toggleGroup, UnityAction<SelectMachineCategoryPanelCtrl, PaletteItemCtrl, PointerEventData> onClickAction, UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnterAction, UnityAction onPointerExitAction)
		{
		}

		public void SetCursorMethod(UnityAction<GameObject> onCursorEnterAction, UnityAction onCursorExitAction)
		{
		}

		private void SetCategoryIcon()
		{
		}

		private void CreateItems(List<eMachine> favoriteList, ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo, ToggleGroup toggleGroup)
		{
		}

		private void ClearItems()
		{
		}

		public void UpdateFavorite(List<eMachine> favoriteList)
		{
		}

		public void UpdateSelectedItem(ArtifactPaletteCtrl.SelectedItemInfo selectedItemInfo)
		{
		}

		public void OnClickItem(ArtifactPaletteCtrl.PaletteItemData itemData, PointerEventData pointerEventData, PaletteItemCtrl itemCtrl)
		{
		}

		public void OnPointerEnterItem(ArtifactPaletteCtrl.PaletteItemData itemData)
		{
		}

		public void OnPointerExitItem()
		{
		}

		public void OnPointerEnterPanel()
		{
		}

		public void OnPointerExitPanel()
		{
		}

		public void SetCursor(bool isOn)
		{
		}
	}
}
