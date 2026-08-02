using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public class Fire : DamageDealerObject
	{
		[SerializeField]
		private LightEffect m_LightEffect;

		[SerializeField]
		private ParticleSystem m_FireParticles;

		[SerializeField]
		private AudioSource m_AudioSource;

		[Space]
		[SerializeField]
		private LayerMask m_LayerMask;

		[SerializeField]
		[Range(0.01f, 1000f)]
		private float m_Lifetime = 5f;

		[SerializeField]
		[Range(0.01f, 5f)]
		private float m_TickDuration = 0.25f;

		[SerializeField]
		[Range(0f, 1000f)]
		private float m_DamagePerTick = 10f;

		[SerializeField]
		[Range(0f, 10f)]
		private float m_StopDuration = 1f;

		private Dictionary<Transform, IDamageable> m_AffectedDamageables = new Dictionary<Transform, IDamageable>();

		private Entity m_DamageDealer;

		private bool m_CanDamage = true;

		private float m_DamageMod = 1f;

		public override void ActivateDamage(Entity damageDealer)
		{
			base.transform.parent = null;
			m_DamageDealer = damageDealer;
			StartCoroutine(C_StartFire());
			StartCoroutine(C_DealFireDamage());
		}

		private void OnTriggerEnter(Collider col)
		{
			if ((int)m_LayerMask == ((int)m_LayerMask | (1 << col.gameObject.layer)))
			{
				IDamageable component = col.GetComponent<IDamageable>();
				if (!m_AffectedDamageables.ContainsKey(col.transform))
				{
					m_AffectedDamageables.Add(col.transform, component);
				}
			}
		}

		private void OnTriggerExit(Collider col)
		{
			if ((int)m_LayerMask == ((int)m_LayerMask | (1 << col.gameObject.layer)))
			{
				m_AffectedDamageables.Remove(col.transform);
			}
		}

		private IEnumerator C_StartFire()
		{
			m_FireParticles.Stop();
			ParticleSystem.MainModule main = m_FireParticles.main;
			main.duration = m_Lifetime;
			m_FireParticles.Play();
			m_LightEffect.Play(fadeIn: true);
			if (Physics.Raycast(base.transform.position, Vector3.down, out var hitInfo, 10f))
			{
				base.transform.position = hitInfo.point;
				base.transform.rotation = Quaternion.Euler(hitInfo.normal);
			}
			yield return new WaitForSeconds(m_Lifetime);
			float stopDuration = Time.time + m_StopDuration;
			while (stopDuration > Time.time)
			{
				m_AudioSource.volume -= Time.deltaTime * (1f / m_StopDuration);
				m_DamageMod -= Time.deltaTime * (1f / m_StopDuration);
				yield return null;
			}
			m_FireParticles.Stop();
			m_LightEffect.Stop(fadeOut: true);
			m_CanDamage = false;
		}

		private IEnumerator C_DealFireDamage()
		{
			WaitForSeconds pauseBetweenDamageTick = new WaitForSeconds(m_TickDuration);
			while (m_CanDamage)
			{
				if (m_DamageDealer != null && m_AffectedDamageables != null)
				{
					foreach (KeyValuePair<Transform, IDamageable> affectedDamageable in m_AffectedDamageables)
					{
						m_DamageDealer.DealDamage.Try(new DamageInfo((0f - m_DamagePerTick) * m_DamageMod, DamageType.Fire, base.transform.position, (affectedDamageable.Key.position - base.transform.position).normalized, 0f, m_DamageDealer, affectedDamageable.Key), affectedDamageable.Value);
					}
				}
				yield return pauseBetweenDamageTick;
			}
		}
	}
}
