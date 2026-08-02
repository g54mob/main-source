using UnityEngine;

namespace HQFPSTemplate
{
	public class GenericVitals : EntityComponent
	{
		[BHeader("Health & Damage", true)]
		[SerializeField]
		[Group]
		private GenericStatData m_HealthStat;

		[Space]
		[SerializeField]
		[Group]
		private DamageResistance m_DamageResistance;

		protected virtual void Awake()
		{
			base.Entity.ChangeHealth.SetTryer(Try_ChangeHealth);
			SetOriginalMaxHealth();
		}

		protected virtual void Update()
		{
			if (m_HealthStat.CanRegenerate && base.Entity.Health.Get() < 100f && base.Entity.Health.Get() > 0f)
			{
				DamageInfo arg = new DamageInfo(m_HealthStat.RegenDelta);
				base.Entity.ChangeHealth.Try(arg);
			}
		}

		protected virtual bool Try_ChangeHealth(DamageInfo healthEventData)
		{
			if (base.Entity.Health.Get() == 0f)
			{
				return false;
			}
			if (healthEventData.Delta > 0f && base.Entity.Health.Get() == 100f)
			{
				return false;
			}
			float num = healthEventData.Delta;
			if (num < 0f)
			{
				num *= 1f - m_DamageResistance.GetDamageResistance(healthEventData);
			}
			float value = Mathf.Clamp(base.Entity.Health.Get() + num, 0f, 100f);
			base.Entity.Health.Set(value);
			if (num < 0f)
			{
				m_HealthStat.Pause();
			}
			return true;
		}

		private void SetOriginalMaxHealth()
		{
			base.Entity.Health.Set(m_HealthStat.InitialValue);
		}
	}
}
