using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerInventoryView : SelectionExtraWindowView
	{
		[SerializeField]
		private LayoutGroupView itemSlotsGroup;

		private List<ButtonLayoutItemView> slotsObjects = new List<ButtonLayoutItemView>();

		private HumanoidInstance humanoid;

		public void SetupTabPanel(HumanoidInstance humanoid)
		{
			this.humanoid = humanoid;
			foreach (ButtonLayoutItemView slotsObject in slotsObjects)
			{
				slotsObject.gameObject.SetActive(value: false);
			}
			foreach (EquipmentSlotType availableSlot in humanoid.Inventory.AvailableSlots)
			{
				if (availableSlot != EquipmentSlotType.None)
				{
					EquipmentInstance item = this.humanoid.Inventory.GetItem(availableSlot);
					ButtonLayoutItemView buttonLayoutItemView = CreateItemSlot();
					Image component = buttonLayoutItemView.GroupItems[3].GetComponent<Image>();
					buttonLayoutItemView.SetImageData(availableSlot.ToString().ToLower(), availableSlot.ToString().ToLower());
					string text;
					if (this.humanoid.Inventory.IsSlotBlocked(availableSlot) || item == null)
					{
						text = ((item == null) ? "empty" : "blocked");
						buttonLayoutItemView.SetText(buttonLayoutItemView.TextIndex, MonoSingleton<LocalizationController>.Instance.GetText("general_" + text));
						SetupInteractions(humanoid, buttonLayoutItemView, null);
					}
					else
					{
						buttonLayoutItemView.SetTextData(item.Id, ResourceUtils.GetLocalizedResourceName(item.Blueprint.Resource));
						buttonLayoutItemView.GroupItems[buttonLayoutItemView.TextIndex].GetComponent<EquipmentTooltipView>().SetupData(item, this.humanoid);
						SetupInteractions(humanoid, buttonLayoutItemView, item);
						text = item.Id;
					}
					component.sprite = AssetUtils.GetSprite(ResourceUtils.GetIconPath(text));
					component.gameObject.SetActive(text != "empty");
					buttonLayoutItemView.gameObject.SetActive(value: true);
				}
			}
		}

		private void SetupInteractions(HumanoidInstance humanoid, ButtonLayoutItemView slotObject, EquipmentInstance item)
		{
			slotObject.Button.onClick.RemoveAllListeners();
			bool flag = false;
			bool flag2 = humanoid.WorkerBehaviour != null && humanoid.WorkerBehaviour.IsBanished;
			if (item != null && !flag2)
			{
				flag = true;
				slotObject.Button.onClick.AddListener(delegate
				{
					DropItem(item);
				});
			}
			slotObject.Button.interactable = flag;
			slotObject.TextObject.raycastTarget = flag;
			slotObject.ButtonIcon.raycastTarget = flag;
		}

		private ButtonLayoutItemView CreateItemSlot()
		{
			ButtonLayoutItemView buttonLayoutItemView = slotsObjects.FirstOrDefault((ButtonLayoutItemView itemSlot) => !itemSlot.gameObject.activeSelf);
			if (buttonLayoutItemView == null)
			{
				buttonLayoutItemView = Object.Instantiate(itemSlotsGroup.Prefab, Vector3.zero, Quaternion.identity, itemSlotsGroup.gameObject.transform) as ButtonLayoutItemView;
				slotsObjects.Add(buttonLayoutItemView);
			}
			return buttonLayoutItemView;
		}

		private void DropItem(EquipmentInstance item)
		{
			MonoSingleton<WorkerController>.Instance.DropItem(item, humanoid.Inventory);
		}
	}
}
