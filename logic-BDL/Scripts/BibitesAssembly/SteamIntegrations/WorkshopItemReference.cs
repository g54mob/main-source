using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace SteamIntegrations
{
	public class WorkshopItemReference : PoolableDictItem<WorkshopItem, WorkshopItemReference>, IPointerClickHandler, IEventSystemHandler
	{
		[Header("Component Ref")]
		public Image typeIcon;

		public TextMeshProUGUI title;

		public TextMeshProUGUI creatorName;

		public GameObject creatorSection;

		public GameObject updateNeeded;

		private WorkshopItem workshopItem;

		private bool selected;

		public WorkshopItem item => workshopItem;

		public override void AssignKey(WorkshopItem key)
		{
			workshopItem = key;
			workshopItem.onInfoUpdate.AddListener(UpdateInfo);
			UpdateInfo();
		}

		public override void Retire()
		{
			base.Retire();
			workshopItem?.onInfoUpdate.RemoveListener(UpdateInfo);
		}

		public void UpdateInfo()
		{
			typeIcon.sprite = SteamWorkshopManager.instance.GetSpriteOfType(workshopItem.type);
			title.text = workshopItem.title;
			updateNeeded.SetActive(SteamWorkshopManager.instance.CheckItemNeedUpdate(workshopItem.id));
			if (workshopItem.canBeModified)
			{
				creatorSection.SetActive(value: false);
				updateNeeded.SetActive(value: false);
			}
			else
			{
				creatorSection.SetActive(value: true);
				updateNeeded.SetActive(item.needUpdate);
				creatorName.text = workshopItem.creatorName;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				WorkshopItemsPanel.instance.Select(this);
			}
		}

		public void Select(bool select)
		{
		}
	}
}
