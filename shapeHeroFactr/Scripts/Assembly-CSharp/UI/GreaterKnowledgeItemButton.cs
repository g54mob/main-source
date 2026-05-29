using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class GreaterKnowledgeItemButton : MonoBehaviour
	{
		public GameObject priceObj;

		public TMP_Text price;

		public Image itemIcon;

		public GameObject soldOut;

		public Button buttonComponent;

		[SerializeField]
		private Transform counterParent;

		[SerializeField]
		private Image counterPrefab;

		[SerializeField]
		private Image selectedCursor;

		[SerializeField]
		private CursorUIItem cursorUIItem;

		public GameObject enableSwitchToggleObj;

		public Toggle enableSwitchToggle;

		public GameObject offImageObj;

		public GameObject padGuide;

		public GameObject padToggleGuide;

		public Color disabledColor;

		private UnityAction<GreaterKnowledgeItemButton> OnClickAction;

		private UnityAction<GreaterKnowledgeItemButton> OnPointerOverAction;

		private UnityAction<GreaterKnowledgeItemButton> OnPointerExitAction;

		private List<OutGameShopData> dataList;

		private List<Image> counterList;

		public bool HaveParent(eOutGameShopId id)
		{
			return false;
		}

		public OutGameShopData FindParentData(eOutGameShopId updateId)
		{
			return null;
		}

		public OutGameShopData FindData(eOutGameShopId targetId)
		{
			return null;
		}

		public OutGameShopData GetCurrentData()
		{
			return null;
		}

		public void InitComponent(OutGameShopData data, UnityAction<GreaterKnowledgeItemButton> OnClickAction, UnityAction<GreaterKnowledgeItemButton> OnPointerOverAction, UnityAction<GreaterKnowledgeItemButton> OnPointerExitAction)
		{
		}

		public void AddItemData(OutGameShopData data)
		{
		}

		public void UpdateUI()
		{
		}

		public void ResetEvent()
		{
		}

		public void OnClick()
		{
		}

		public void OnPointerOver()
		{
		}

		public void OnPointerExit()
		{
		}

		public void ApplySwitchToggle(bool isOn)
		{
		}
	}
}
