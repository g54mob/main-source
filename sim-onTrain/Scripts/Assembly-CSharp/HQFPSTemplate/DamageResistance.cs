using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class DamageResistance
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_GenericResistance = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_CutResistance = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_HitResistance = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_StabResistance = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_BulletResistance = 0.1f;

		public float GetDamageResistance(DamageInfo damageData)
		{
			if (damageData.DamageType == DamageType.Generic)
			{
				return m_GenericResistance;
			}
			if (damageData.DamageType == DamageType.Cut)
			{
				return m_CutResistance;
			}
			if (damageData.DamageType == DamageType.Hit)
			{
				return m_HitResistance;
			}
			if (damageData.DamageType == DamageType.Stab)
			{
				return m_StabResistance;
			}
			if (damageData.DamageType == DamageType.Bullet)
			{
				return m_BulletResistance;
			}
			return 0f;
		}
	}
}
