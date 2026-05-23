using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Factory.UI
{
	public class SelectItemPaletteCtrl : MonoBehaviour
	{
		private const int paletteItemWidth = 90;

		private const float palettePaddingLR = 20f;

		[SerializeField]
		private PaletteItemCtrl paletteItemPrefab;

		private List<ArtifactPaletteCtrl.PaletteItemData> itemDataList;

		private List<PaletteItemCtrl> paletteItemList;

		private int selectedItemNumber;

		private UnityAction<ArtifactPaletteCtrl.PaletteItemData, PointerEventData, PaletteItemCtrl> onClickItemAction;

		private UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnterItemAction;

		private UnityAction onPointerExitItemAction;

		private ePaletteCategory category;

		public void Init(ePaletteCategory category, List<ArtifactPaletteCtrl.PaletteItemData> itemList, List<eMachine> favoriteList, UnityAction<ArtifactPaletteCtrl.PaletteItemData, PointerEventData, PaletteItemCtrl> onClick, UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnter, UnityAction onPointerExit)
		{
		}

		public void SetItems(ePaletteCategory category, List<ArtifactPaletteCtrl.PaletteItemData> itemList, List<eMachine> favoriteList, int selectedNumber = -1)
		{
		}

		private void Start()
		{
		}

		private void CreatePaletteItems(List<eMachine> favoriteList)
		{
		}

		private void UpdatePaletteItems(List<eMachine> favoriteList)
		{
		}

		private void OnClickItemButton(ArtifactPaletteCtrl.PaletteItemData itemData, PointerEventData pointerEventData, PaletteItemCtrl itemCtrl)
		{
		}

		private void OnPointerEnterItemButton(ArtifactPaletteCtrl.PaletteItemData itemData)
		{
		}

		private void OnPointerExitItemButton()
		{
		}

		public void UpdateItemUI(List<eMachine> favoriteList, int selectedItemNumber, bool showShortcut)
		{
		}

		public PaletteItemCtrl GetPaletteItemCtrlByItemData(ArtifactPaletteCtrl.PaletteItemData itemData)
		{
			return null;
		}
	}
}
