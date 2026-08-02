using System;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(Collider))]
	public class TriggerHitbox : MonoBehaviour, IDamageable
	{
		[Serializable]
		public class DamageEvent : UnityEvent<DamageInfo>
		{
		}

		[Serializable]
		public class DamageEventSimple : UnityEvent<float>
		{
		}

		[SerializeField]
		private DamageEvent m_OnDamageEvent;

		[SerializeField]
		private DamageEventSimple m_OnSimpleDamageEvent;

		public void TakeDamage(DamageInfo damageData)
		{
			m_OnDamageEvent.Invoke(damageData);
			m_OnSimpleDamageEvent.Invoke(damageData.Delta);
		}
	}
}
