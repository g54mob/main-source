using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate
{
	public class EquipmentPickup : ItemPickup
	{
		protected override void TryPickUp(Humanoid humanoid, float interactProgress)
		{
			if (m_ItemInstance != null)
			{
				if (interactProgress > 0.45f && humanoid.SwapItem.Try(m_ItemInstance))
				{
					Object.Destroy(base.gameObject);
					return;
				}
				bool flag;
				if (humanoid.EquippedItem.Get() == null)
				{
					ItemContainer containerWithFlags = humanoid.Inventory.GetContainerWithFlags(m_TargetContainers);
					ItemSlot itemSlot = containerWithFlags.Slots[containerWithFlags.SelectedSlot.Get()];
					if (itemSlot.Item == null)
					{
						itemSlot.SetItem(m_ItemInstance);
					}
					flag = true;
				}
				else
				{
					flag = humanoid.Inventory.AddItem(m_ItemInstance, m_TargetContainers);
				}
				if (flag)
				{
					if (m_ItemInstance.Info.StackSize > 1)
					{
						Singleton<UI_MessageDisplayer>.Instance.PushMessage($"Picked up <color={ColorUtils.ColorToHex(m_ItemCountColor)}>{m_ItemInstance.Name}</color> x {m_ItemInstance.CurrentStackSize}", m_BaseMessageColor);
					}
					else
					{
						Singleton<UI_MessageDisplayer>.Instance.PushMessage($"Picked up <color={ColorUtils.ColorToHex(m_ItemCountColor)}>{m_ItemInstance.Name}</color>", m_BaseMessageColor);
					}
					Object.Destroy(base.gameObject);
				}
				else
				{
					Singleton<UI_MessageDisplayer>.Instance.PushMessage($"<color={ColorUtils.ColorToHex(m_InventoryFullColor)}>Inventory Full</color>", m_BaseMessageColor);
				}
			}
			else
			{
				Debug.LogError("Item Instance is null, can't pick up anything.");
			}
		}
	}
}
