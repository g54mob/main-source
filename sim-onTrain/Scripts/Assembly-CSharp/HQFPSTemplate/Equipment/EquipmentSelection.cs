using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class EquipmentSelection : PlayerComponent
	{
		[BHeader("General")]
		[SerializeField]
		[PlayerItemContainer]
		private string m_HolsterContainerName;

		[SerializeField]
		[Range(1f, 8f)]
		private int m_FirstSelected = 1;

		[BHeader("Navigation")]
		[SerializeField]
		private bool m_EnableScrolling = true;

		[SerializeField]
		[ShowIf("m_EnableScrolling", true, 10f)]
		private bool m_InvertScrollDirection;

		[SerializeField]
		[ShowIf("m_EnableScrolling", true, 10f)]
		[Clamp(0f, 1f)]
		private float m_ScrollThreshold = 0.3f;

		[SerializeField]
		[ShowIf("m_EnableScrolling", true, 10f)]
		[Clamp(0f, 1f)]
		private float m_ScrollPause = 0.3f;

		[SerializeField]
		[ShowIf("m_EnableScrolling", true, 10f)]
		private bool m_ScrollThroughEmptySlots;

		[SerializeField]
		private bool m_SelectByDigits = true;

		[SerializeField]
		[ShowIf("m_SelectByDigits", true, 10f)]
		[Clamp(0f, 1f)]
		private float m_SelectThreshold = 0.3f;

		private ItemContainer m_HolsterContainer;

		private int m_CurrentScrollIndex;

		private float m_CurScrollValue;

		private float m_NextTimeCanSelect;

		private float m_CanSelectTime;

		private void Start()
		{
			m_HolsterContainer = base.Player.Inventory.GetContainerWithName(m_HolsterContainerName);
			base.Player.DropItem.AddListener(OnPlayerDropItem);
			base.Player.Respawn.AddListener(OnPlayerRespawn);
			if (m_HolsterContainer != null)
			{
				m_HolsterContainer.SelectedSlot.AddChangeListener(TrySelectSlot);
				int andForceUpdate = m_FirstSelected - 1;
				if (base.Player.EquippedItem.Get() != null)
				{
					andForceUpdate = m_HolsterContainer.GetPositionOfItem(base.Player.EquippedItem.Get());
				}
				m_HolsterContainer.SelectedSlot.SetAndForceUpdate(andForceUpdate);
				m_HolsterContainer.Changed.AddListener(OnHolsterContainerUpdate);
			}
			m_CanSelectTime = Time.time + 0.3f;
		}

		private void OnPlayerRespawn()
		{
			TrySelectSlot(m_FirstSelected);
		}

		private void OnPlayerDropItem(Item droppedItem)
		{
			base.Player.EquipItem.Try(null, arg2: true);
		}

		private void OnHolsterContainerUpdate(ItemSlot slot)
		{
			if (m_CanSelectTime < Time.time && slot.Item != null)
			{
				int positionOfItem = m_HolsterContainer.GetPositionOfItem(slot.Item);
				m_HolsterContainer.SelectedSlot.SetAndForceUpdate(positionOfItem);
			}
		}

		private void Update()
		{
		}

		private void TrySelectSlot(int index)
		{
			ItemSlot itemSlot = m_HolsterContainer.Slots[Mathf.Clamp(index, 0, m_HolsterContainer.Slots.Length - 1)];
			base.Player.EquipItem.Try(itemSlot.Item, arg2: false);
		}
	}
}
