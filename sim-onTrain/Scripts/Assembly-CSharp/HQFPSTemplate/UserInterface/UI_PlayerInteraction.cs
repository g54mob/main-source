using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_PlayerInteraction : UserInterfaceBehaviour
	{
		private readonly int animHash_Show = Animator.StringToHash("Show");

		[BHeader("Generic Interaction", true)]
		[SerializeField]
		private Animator m_GenericInteractionAnimator;

		[SerializeField]
		private Text m_GenericText;

		[BHeader("Equipment Specific Interaction", true)]
		[SerializeField]
		[PlayerItemContainer]
		private string m_HolsterContainerName = "Holster";

		[SerializeField]
		private Animator m_EquipmentInteractionAnimator;

		[Space]
		[SerializeField]
		private Image m_SwapIcon;

		[SerializeField]
		private Image m_EquippedItemImg;

		[SerializeField]
		private Image m_GroundItemImg;

		private ItemContainer m_HolsterContainer;

		private RaycastInfo m_RaycastData;

		private bool m_SwapUIEnabled;

		public override void OnPostAttachment()
		{
			base.Player.RaycastInfo.AddChangeListener(OnPlayerRaycastChanged);
			base.Player.EquippedItem.AddChangeListener(delegate
			{
				OnPlayerRaycastChanged(base.Player.RaycastInfo.Val);
			});
			m_HolsterContainer = base.Player.Inventory.GetContainerWithName(m_HolsterContainerName);
		}

		private void OnPlayerRaycastChanged(RaycastInfo raycastData)
		{
			bool num = raycastData?.IsInteractive ?? false;
			if (m_RaycastData != null)
			{
				m_RaycastData.InteractiveObject.InteractionText.RemoveChangeListener(UpdateInteractText);
			}
			m_RaycastData = raycastData;
			if (num)
			{
				ItemPickup itemPickup = m_RaycastData.InteractiveObject as ItemPickup;
				if (itemPickup != null && IsSwappable(itemPickup.ItemInstance))
				{
					UpdateSwapUI(itemPickup, enable: true);
					return;
				}
				if (m_SwapUIEnabled)
				{
					UpdateSwapUI(null, enable: false);
				}
				m_GenericInteractionAnimator.SetBool(animHash_Show, value: true);
				UpdateInteractText(m_RaycastData.InteractiveObject.InteractionText.Val);
				m_RaycastData.InteractiveObject.InteractionText.AddChangeListener(UpdateInteractText);
			}
			else
			{
				m_GenericInteractionAnimator.SetBool(animHash_Show, value: false);
				m_EquipmentInteractionAnimator.SetBool(animHash_Show, value: false);
			}
		}

		private void UpdateSwapUI(ItemPickup pickup, bool enable)
		{
			if (pickup != null)
			{
				if (enable)
				{
					pickup.InteractionProgress.AddChangeListener(UpdateInteractProgressIMG);
				}
				UpdateInteractProgressIMG(0f);
				m_EquippedItemImg.sprite = base.Player.EquippedItem.Val.Info.Icon;
				m_GroundItemImg.sprite = pickup.ItemInstance.Info.Icon;
				m_GenericInteractionAnimator.SetBool(animHash_Show, value: false);
				m_EquipmentInteractionAnimator.SetBool(animHash_Show, enable);
				m_SwapUIEnabled = true;
			}
			else
			{
				m_EquipmentInteractionAnimator.SetBool(animHash_Show, value: false);
				m_SwapUIEnabled = false;
			}
		}

		private void UpdateInteractText(string text)
		{
			m_GenericText.text = text;
		}

		private void UpdateInteractProgressIMG(float amount)
		{
			if (amount < 0.1f)
			{
				amount = 0f;
			}
			m_SwapIcon.fillAmount = Mathf.Min(amount * 2f, 1f);
		}

		private bool IsSwappable(Item item)
		{
			if (base.Player.EquippedItem.Get() != null)
			{
				return m_HolsterContainer.AllowsItem(item);
			}
			return false;
		}
	}
}
