using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class HealsManager : PlayerComponent
	{
		[SerializeField]
		[PlayerItemContainer]
		private string m_HealsContainerName = "Backpack";

		[SerializeField]
		private bool m_HealWhileRunning;

		[SerializeField]
		private bool m_HealWithMaxHealth;

		private ItemContainer m_HealsContainer;

		private void Start()
		{
			base.Player.Healing.SetStartTryer(TryStart_Healing);
			base.Player.Healing.AddStopListener(OnStop_Healing);
			m_HealsContainer = base.Player.Inventory.GetContainerWithName(m_HealsContainerName);
		}

		private bool TryStart_Healing()
		{
			if ((base.Player.Run.Active && !m_HealWhileRunning) || (base.Player.Health.Get() >= 100f && !m_HealWithMaxHealth) || base.Player.Healing.Active)
			{
				return false;
			}
			bool result = false;
			Item item = TryGetHealingItem();
			if (item != null)
			{
				result = true;
				if (base.Player.Reload.Active)
				{
					base.Player.Reload.ForceStop();
				}
				if (base.Player.Aim.Active)
				{
					base.Player.Aim.ForceStop();
				}
				base.Player.EquipItem.Try(item, arg2: false);
			}
			return result;
		}

		private void OnStop_Healing()
		{
			base.Player.Inventory.RemoveItemsWithName(base.Player.EquippedItem.Val.Info.Name, 1, ItemContainerFlags.Storage);
			base.Player.EquipItem.Try(base.Player.EquippedItem.GetPreviousValue(), arg2: false);
		}

		private Item TryGetHealingItem()
		{
			ItemSlot[] slots = m_HealsContainer.Slots;
			foreach (ItemSlot itemSlot in slots)
			{
				if (itemSlot.HasItem)
				{
					return itemSlot.Item;
				}
			}
			return null;
		}
	}
}
