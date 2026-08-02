using System;
using System.Collections;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class Flashlight : EquipmentItem
	{
		[Serializable]
		public class FlashlightSettings
		{
			public LightEffect Light;

			public bool LightFadeIn;
		}

		private readonly int animHash_Use = Animator.StringToHash("Use");

		private readonly int animHash_UseSpeed = Animator.StringToHash("Use Speed");

		[SerializeField]
		[Group]
		private FlashlightSettings m_FlashlightSettings;

		private FlashlightInfo m_F;

		private bool m_LastSwitchState;

		private WaitForSeconds m_SwitchDuration;

		public override void Initialize(EquipmentHandler eHandler)
		{
			base.Initialize(eHandler);
			m_F = base.EInfo as FlashlightInfo;
			m_SwitchDuration = new WaitForSeconds(m_F.FlashlightSettings.SwitchDuration);
			m_UseThreshold = m_F.FlashlightSettings.SwitchDuration;
		}

		public override void Equip(Item item)
		{
			base.Equip(item);
			base.EHandler.Animator_SetFloat(animHash_UseSpeed, m_F.FlashlightSettings.AnimSwitchSpeed);
		}

		public override bool TryUseOnce(Ray[] itemUseRays, int useType)
		{
			if (m_NextTimeCanUse > Time.time)
			{
				return false;
			}
			base.EHandler.PlayDelayedSound(m_LastSwitchState ? m_F.FlashlightSettings.SwitchOffClip : m_F.FlashlightSettings.SwitchOnClip);
			base.EHandler.Animator_SetTrigger(animHash_Use);
			base.Player.Camera.Physics.PlayDelayedCameraForce(m_F.FlashlightSettings.SwitchPressCamForce);
			m_LastSwitchState = !m_LastSwitchState;
			if (m_FlashlightSettings.Light != null)
			{
				StartCoroutine(C_EnableLight());
			}
			m_NextTimeCanUse = Time.time + m_UseThreshold;
			return true;
		}

		private IEnumerator C_EnableLight()
		{
			yield return m_SwitchDuration;
			m_GeneralEvents.OnUse.Invoke();
			if (m_LastSwitchState)
			{
				m_FlashlightSettings.Light.Play(m_FlashlightSettings.LightFadeIn);
			}
			else
			{
				m_FlashlightSettings.Light.Stop(m_FlashlightSettings.LightFadeIn);
			}
		}
	}
}
