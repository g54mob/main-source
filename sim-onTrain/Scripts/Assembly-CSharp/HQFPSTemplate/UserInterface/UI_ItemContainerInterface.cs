using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	public class UI_ItemContainerInterface : UI_ContainerInterface<UI_ItemSlotInterface>
	{
		[Header("Item Container")]
		[SerializeField]
		private bool m_IsPlayerContainer = true;

		[SerializeField]
		[PlayerItemContainer]
		private string m_ContainerName = string.Empty;

		private ItemContainer m_ItemContainer;

		public ItemContainer ItemContainer
		{
			get
			{
				if (m_ItemContainer != null)
				{
					return m_ItemContainer;
				}
				Debug.LogError("There's no item container linked. Can't retrieve any!");
				return null;
			}
		}

		public void AttachToContainer(ItemContainer container)
		{
			if (GenerateSlots(container.Count))
			{
				m_ItemContainer = container;
				for (int i = 0; i < m_ItemContainer.Count; i++)
				{
					m_SlotInterfaces[i].LinkToSlot(m_ItemContainer.Slots[i]);
				}
			}
		}

		public void DetachFromContainer()
		{
			if (m_ItemContainer != null)
			{
				for (int i = 0; i < m_SlotInterfaces.Length; i++)
				{
					m_SlotInterfaces[i].UnlinkFromSlot();
				}
			}
		}

		public override void OnAttachment()
		{
			if (m_IsPlayerContainer)
			{
				ItemContainer containerWithName = base.Player.Inventory.GetContainerWithName(m_ContainerName);
				if (containerWithName != null)
				{
					AttachToContainer(containerWithName);
				}
			}
		}
	}
}
