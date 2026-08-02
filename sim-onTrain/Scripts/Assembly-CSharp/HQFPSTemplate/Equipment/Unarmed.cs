using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class Unarmed : MeleeWeapon
	{
		private readonly int animHash_Hide = Animator.StringToHash("Hide");

		private readonly int animHash_Airborne = Animator.StringToHash("Airborne");

		private readonly int animHash_RunSpeed = Animator.StringToHash("Run Speed");

		private readonly int animHash_ArmsAreVisible = Animator.StringToHash("Arms Are Visible");

		private readonly int animHash_Jumping = Animator.StringToHash("Jumping");

		private readonly int animHash_Falling = Animator.StringToHash("Falling");

		private readonly int animHash_Running = Animator.StringToHash("Running");

		private UnarmedInfo m_U;

		private float m_NextTimeToHideArms = 1f;

		private bool m_ArmsAreVisible;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_U = base.EInfo as UnarmedInfo;
		}

		public override void Equip(Item item)
		{
			base.EAnimation.AssignArmAnimations(base.EHandler.FPArmsHandler.Animator);
			if (m_U.UnarmedSettings.AlwaysShowArms || base.Player.Run.Active)
			{
				ChangeArmsVisibility(show: true);
			}
			m_NextTimeCanUse = Time.time + m_U.MeleeSettings.Swings[0].Cooldown;
			base.Player.Run.AddStartListener(OnStartRunning);
			base.Player.Run.AddStopListener(OnStopRunning);
			base.Player.Jump.AddStartListener(OnStartJumping);
			base.Player.IsGrounded.AddChangeListener(OnStartFalling);
			if (m_U.UnarmedSettings.AlwaysShowArms)
			{
				base.EHandler.Animator_SetBool(animHash_ArmsAreVisible, _bool: true);
				m_ArmsAreVisible = true;
			}
			m_GeneralEvents.OnEquipped.Invoke(arg0: true);
			base.EHandler.Animator_SetFloat(animHash_RunSpeed, m_U.UnarmedSettings.RunAnimSpeed);
		}

		public override void Unequip()
		{
			base.Player.Run.RemoveStartListener(OnStartRunning);
			base.Player.Run.RemoveStopListener(OnStopRunning);
			base.Player.Jump.RemoveStartListener(OnStartJumping);
			base.Player.IsGrounded.RemoveChangeListener(OnStartFalling);
			base.EHandler.Animator_SetBool(animHash_Airborne, _bool: false);
			ChangeArmsVisibility(show: false);
			m_GeneralEvents.OnEquipped.Invoke(arg0: false);
		}

		public override bool TryUseOnce(Ray[] itemUseRays, int useType)
		{
			if (base.Player.IsGrounded.Val)
			{
				EastUpPlayerItemManager component = base.Player.GetComponent<EastUpPlayerItemManager>();
				if (component != null && (component.activeUnarmedItem != null || component.activeUnarmedItemLeft != null))
				{
					return false;
				}
				m_NextTimeToHideArms = Time.time + m_U.UnarmedSettings.ArmsShowDuration;
				if (m_ArmsAreVisible)
				{
					return base.TryUseOnce(itemUseRays, useType);
				}
				base.EHandler.PlayDelayedSound(m_U.UnarmedSettings.ShowArmsAudio);
				ChangeArmsVisibility(show: true);
			}
			return false;
		}

		protected virtual void OnStartFalling(bool isGrounded)
		{
			if (isGrounded)
			{
				base.EHandler.Animator_SetBool(animHash_Airborne, _bool: false);
				base.EHandler.Animator_SetBool(animHash_Jumping, _bool: false);
				m_NextTimeCanUse = Time.time + m_U.MeleeSettings.Swings[0].Cooldown;
			}
			else
			{
				base.EHandler.Animator_SetTrigger(animHash_Falling);
				base.EHandler.Animator_SetBool(animHash_Airborne, _bool: true);
			}
		}

		protected virtual void OnStartRunning()
		{
			base.EHandler.Animator_SetBool(animHash_Running, _bool: true);
		}

		protected virtual void OnStopRunning()
		{
			base.EHandler.Animator_SetBool(animHash_Running, _bool: false);
			m_NextTimeCanUse = Time.time + m_U.MeleeSettings.Swings[0].Cooldown;
			ChangeArmsVisibility(show: false);
		}

		protected virtual void OnStartJumping()
		{
			base.EHandler.Animator_SetBool(animHash_Airborne, _bool: true);
			base.EHandler.Animator_SetBool(animHash_Jumping, _bool: true);
		}

		protected virtual void Update()
		{
			EastUpPlayerItemManager component = base.Player.GetComponent<EastUpPlayerItemManager>();
			bool flag = component != null && component.activeUnarmedItem != null;
			if (!m_U.UnarmedSettings.AlwaysShowArms && m_NextTimeToHideArms < Time.time && m_ArmsAreVisible && !flag)
			{
				ChangeArmsVisibility(show: false);
				base.EHandler.Animator_SetTrigger(animHash_Hide);
			}
		}

		private void ChangeArmsVisibility(bool show)
		{
			m_ArmsAreVisible = show;
			base.EHandler.Animator_SetBool(animHash_ArmsAreVisible, show);
		}
	}
}
