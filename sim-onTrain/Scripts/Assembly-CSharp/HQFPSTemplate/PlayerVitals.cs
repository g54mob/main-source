using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerVitals : EntityVitals
	{
		[BHeader("Stamina", true)]
		[SerializeField]
		[Group]
		private StaminaSettings m_StaminaStat;

		private float m_NextAllowedStaminaRegen;

		private Player m_Player;

		private TSPlayerStatusHolder m_StatusHolder;

		protected override void Update()
		{
			base.Update();
			UpdateStats();
		}

		protected override void Awake()
		{
			base.Awake();
			m_Player = GetComponentInParent<Player>();
			m_StatusHolder = GetComponentInParent<TSPlayerStatusHolder>();
			m_Player.Stamina.Set(m_StaminaStat.InitialValue);
			m_Player.Stamina.AddChangeListener(On_StaminaChange);
			m_Player.Jump.AddStartListener(On_PlayerJump);
		}

		private void UpdateStats()
		{
			bool flag = m_StatusHolder != null && m_StatusHolder.HasActivePowerUp(PlayerPowerUpType.UnlimitedSprintBoost);
			if (m_Player.Run.Active)
			{
				if (!flag)
				{
					float num = m_StaminaStat.DepletionSpeed * Time.deltaTime;
					float value = Mathf.Clamp(m_Player.Stamina.Get() - num, 0f, 100f);
					m_Player.Stamina.Set(value);
				}
			}
			else if (Time.time > m_NextAllowedStaminaRegen)
			{
				float num2 = m_StaminaStat.RegenSpeed * Time.deltaTime;
				float value2 = Mathf.Clamp(m_Player.Stamina.Get() + num2, 0f, 100f);
				m_Player.Stamina.Set(value2);
			}
		}

		private void On_StaminaChange(float change)
		{
			if (change < m_Player.Stamina.GetPreviousValue())
			{
				m_NextAllowedStaminaRegen = Time.time + m_StaminaStat.RegenPause;
			}
		}

		private void On_PlayerJump()
		{
			float value = Mathf.Clamp(m_Player.Stamina.Get() - m_StaminaStat.JumpStaminaTake, 0f, 100f);
			m_Player.Stamina.Set(value);
		}
	}
}
