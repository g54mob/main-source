using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_HealsInfo : UserInterfaceBehaviour
	{
		[BHeader("General")]
		[SerializeField]
		private Text m_HealsAmountText;

		[SerializeField]
		[PlayerItemContainer]
		private string m_HealsContainerName = "Heals Pouch";

		[BHeader("Low Health Image")]
		[SerializeField]
		private float m_LowHealthThreshold;

		[SerializeField]
		private CanvasGroup m_HealCanvas;

		private ItemContainer m_HealsContainer;

		public override void OnPostAttachment()
		{
			m_HealsContainer = base.Player.Inventory.GetContainerWithName(m_HealsContainerName);
			OnContainerChanged(null);
			m_HealsContainer.Changed.AddListener(OnContainerChanged);
			base.Player.Healing.AddStopListener(OnEndHealing);
			base.Player.Health.AddChangeListener(OnPlayerChangeHealth);
			OnPlayerChangeHealth(base.Player.Health.Val);
		}

		private void OnEndHealing()
		{
			OnContainerChanged(null);
		}

		private void OnPlayerChangeHealth(float healthAmount)
		{
			if (base.Player.Health.Val == 0f)
			{
				m_HealCanvas.alpha = 0f;
			}
			else if (healthAmount < m_LowHealthThreshold)
			{
				m_HealCanvas.alpha = 1f;
			}
			else if (m_HealCanvas.gameObject.activeSelf)
			{
				m_HealCanvas.alpha = 0f;
			}
		}

		private void OnContainerChanged(ItemSlot itemSlot)
		{
			int num = 0;
			if (m_HealsContainer == null)
			{
				return;
			}
			ItemSlot[] slots = m_HealsContainer.Slots;
			foreach (ItemSlot itemSlot2 in slots)
			{
				if (itemSlot2.HasItem)
				{
					num += itemSlot2.Item.CurrentStackSize;
				}
			}
			m_HealsAmountText.text = $"x {num.ToString()}";
		}
	}
}
