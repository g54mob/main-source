using System;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(Collider))]
	public class Hitbox : MonoBehaviour, IDamageable
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
		[Range(0f, 100f)]
		private float m_DamageMultiplier = 1f;

		[Space]
		[SerializeField]
		private DamageEvent m_OnDamageEvent;

		[SerializeField]
		private DamageEventSimple m_OnDamageEventSimple;

		[SerializeField]
		[Group]
		private SoundPlayer m_GroundImpactSound;

		private Collider m_Collider;

		private Rigidbody m_Rigidbody;

		private Entity m_ParentEntity;

		private bool m_HitboxImpact;

		public Collider Collider => m_Collider;

		public Rigidbody Rigidbody => m_Rigidbody;

		public void TakeDamage(DamageInfo damageData)
		{
			if (!base.enabled)
			{
				return;
			}
			m_OnDamageEvent.Invoke(damageData);
			m_OnDamageEventSimple.Invoke(damageData.Delta);
			if (m_ParentEntity != null)
			{
				if (m_ParentEntity.Health.Get() > 0f)
				{
					damageData.Delta *= m_DamageMultiplier;
					m_ParentEntity.ChangeHealth.Try(damageData);
				}
				if (m_Rigidbody != null && m_ParentEntity.Health.Get() == 0f)
				{
					m_Rigidbody.AddForceAtPosition(damageData.HitDirection * damageData.HitImpulse, damageData.HitPoint, ForceMode.Impulse);
				}
			}
		}

		private void Awake()
		{
			m_ParentEntity = GetComponentInParent<Entity>();
			m_Collider = GetComponent<Collider>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_ParentEntity.Respawn.AddListener(Respawn);
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (m_Rigidbody != null && collision.relativeVelocity.sqrMagnitude > 5f && !m_Rigidbody.isKinematic && !m_HitboxImpact)
			{
				m_GroundImpactSound.PlayAtPosition(ItemSelection.Method.RandomExcludeLast, base.transform.position);
				m_HitboxImpact = true;
			}
		}

		private void Respawn()
		{
			m_HitboxImpact = false;
		}
	}
}
