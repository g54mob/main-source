using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class HealingItem : EquipmentItem
	{
		private readonly int animHash_Use = Animator.StringToHash("Use");

		private readonly int animHash_UseSpeed = Animator.StringToHash("Use Speed");

		private HealingItemInfo m_H;

		private bool m_IsHealing;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_H = base.EInfo as HealingItemInfo;
		}

		public override void Unequip()
		{
			m_IsHealing = false;
			base.Player.Healing.ForceStop();
			m_GeneralEvents.OnEquipped.Invoke(arg0: false);
		}

		public override void Equip(Item item)
		{
			base.EAnimation.AssignArmAnimations(base.EHandler.FPArmsHandler.Animator);
			m_GeneralInfo.EquipmentModel.UpdateSkinIDProperty(item);
			m_GeneralInfo.EquipmentModel.UpdateMaterialsFov();
			m_GeneralEvents.OnEquipped.Invoke(arg0: true);
			m_IsHealing = false;
		}

		public void StartSyringeAnimation()
		{
			if (!m_IsHealing)
			{
				m_IsHealing = true;
				base.EHandler.Animator_SetFloat(animHash_UseSpeed, m_H.HealingSettings.HealAnimSpeed);
				base.EHandler.Animator_SetTrigger(animHash_Use);
				base.Player.Camera.Physics.PlayDelayedCameraForces(m_H.HealingSettings.HealingCameraForces);
				base.EHandler.PlayDelayedSounds(m_H.HealingSettings.HealingAudio);
			}
		}

		public void CancelSyringeAnimation()
		{
			m_IsHealing = false;
			base.Player.Healing.ForceStop();
		}
	}
}
