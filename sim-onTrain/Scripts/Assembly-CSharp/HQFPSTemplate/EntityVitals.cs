using System;
using UnityEngine;

namespace HQFPSTemplate
{
	public class EntityVitals : GenericVitals
	{
		[Serializable]
		private class FallImpactModule
		{
			public bool Enabled = true;

			[Range(1f, 30f)]
			[Tooltip("At which landing speed, the entity will start taking damage.")]
			public float MinFallSpeed = 10f;

			[Range(1f, 50f)]
			[Tooltip("At which landing speed, the entity will die, if it has no defense.")]
			public float FatalFallSpeed = 25f;

			[Range(1f, 100f)]
			[Tooltip("Minimum damage at MinFallSpeed.")]
			public float MinDamage = 25f;

			[Range(1f, 5f)]
			[Tooltip("Damage curve power (higher = more damage at high speeds). 1=linear, 2=quadratic, 3=cubic")]
			public float DamageCurvePower = 2f;
		}

		[SerializeField]
		[Group]
		private FallImpactModule m_FallDamage = new FallImpactModule();

		protected override void Awake()
		{
			base.Awake();
			base.Entity.FallImpact.AddListener(On_FallImpact);
		}

		private void On_FallImpact(float impactSpeed)
		{
			if (m_FallDamage.Enabled && impactSpeed >= m_FallDamage.MinFallSpeed)
			{
				float num = m_FallDamage.FatalFallSpeed - m_FallDamage.MinFallSpeed;
				float num2 = Mathf.Clamp01((impactSpeed - m_FallDamage.MinFallSpeed) / num);
				float num3 = Mathf.Pow(num2, m_FallDamage.DamageCurvePower);
				float num4 = m_FallDamage.MinDamage + (100f - m_FallDamage.MinDamage) * num3;
				Debug.Log($"[Fall Damage Calculation] Speed: {impactSpeed}, Normalized: {num2:F3}, Curve: {num3:F3}, Damage: {num4:F1}");
				base.Entity.ChangeHealth.Try(new DamageInfo(0f - num4));
			}
		}
	}
}
