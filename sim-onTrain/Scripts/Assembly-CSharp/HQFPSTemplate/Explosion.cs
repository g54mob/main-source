using UnityEngine;

namespace HQFPSTemplate
{
	public class Explosion : DamageDealerObject
	{
		[SerializeField]
		private bool m_DetonateOnStart;

		[SerializeField]
		private float m_Force = 105f;

		[SerializeField]
		[Range(0f, 1000f)]
		private float m_Damage = 100f;

		[SerializeField]
		private float m_Radius = 15f;

		[SerializeField]
		[Range(0f, 10f)]
		private float m_Scale = 1f;

		[SerializeField]
		private LayerMask m_AffectedLayers;

		[Space]
		[SerializeField]
		private AudioSource m_AudioSource;

		[SerializeField]
		private ParticleSystem m_ParticleSystem;

		[Space]
		[SerializeField]
		private bool m_DrawRadiusGizmo = true;

		public override void ActivateDamage(Entity source)
		{
			base.transform.parent = null;
			Explode(source);
		}

		private void Explode(Entity detonator)
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, m_Radius, m_AffectedLayers, QueryTriggerInteraction.Collide);
			foreach (Collider collider in array)
			{
				if (collider.TryGetComponent<IDamageable>(out var component))
				{
					_ = (base.transform.position - collider.transform.position).sqrMagnitude;
					_ = m_Radius;
					_ = m_Radius;
					DamageInfo damageInfo = CreateDamageBasedOnDistance(collider.transform, detonator);
					if (detonator != null)
					{
						detonator.DealDamage.Try(damageInfo, component);
					}
					else
					{
						component.TakeDamage(damageInfo);
					}
				}
				Rigidbody attachedRigidbody = collider.attachedRigidbody;
				if (attachedRigidbody != null)
				{
					attachedRigidbody.AddExplosionForce(m_Force, base.transform.position, 2f, m_Radius, ForceMode.Impulse);
				}
			}
			if (m_AudioSource != null)
			{
				m_AudioSource.Play();
			}
			if (m_ParticleSystem != null)
			{
				m_ParticleSystem.Play();
			}
			ShakeManager.ShakeEvent.Send(new ShakeEventData(base.transform.position, m_Radius, m_Scale, ShakeType.Explosion));
		}

		private DamageInfo CreateDamageBasedOnDistance(Transform col, Entity detonator)
		{
			float sqrMagnitude = (base.transform.position - col.transform.position).sqrMagnitude;
			float num = m_Radius * m_Radius;
			float num2 = 1f - Mathf.Clamp01(sqrMagnitude / num);
			return new DamageInfo((0f - m_Damage) * num2, DamageType.Explosion, base.transform.position, (col.transform.position - base.transform.position).normalized, m_Force, Vector3.zero, detonator, col);
		}

		private void Start()
		{
			if (m_DetonateOnStart)
			{
				ActivateDamage(null);
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			if (m_DrawRadiusGizmo)
			{
				Gizmos.DrawWireSphere(base.transform.position, m_Radius);
			}
		}
	}
}
