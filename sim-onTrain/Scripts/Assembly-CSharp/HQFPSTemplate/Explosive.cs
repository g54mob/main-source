using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	public class Explosive : Projectile
	{
		[SerializeField]
		private bool m_DetonateOnImpact;

		[SerializeField]
		[Range(0f, 15f)]
		private float m_DetonationDelay = 1.5f;

		[Space]
		[SerializeField]
		private UnityEvent m_OnExplosiveLaunched;

		[Space]
		[SerializeField]
		private UnityEvent m_OnExplosiveDetonate;

		private DamageDealerObject[] m_DamageDealers;

		private Entity m_Detonator;

		private bool m_IsDetonating;

		public Entity GetEntity()
		{
			return null;
		}

		public override void Launch(Entity launcher)
		{
			if (!m_IsDetonating)
			{
				m_IsDetonating = true;
				m_OnExplosiveLaunched.Invoke();
				m_DamageDealers = GetComponentsInChildren<DamageDealerObject>(includeInactive: true);
				if (!m_DetonateOnImpact)
				{
					StartCoroutine(C_DetonateWithDelay(launcher));
				}
				m_Detonator = launcher;
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (m_DetonateOnImpact && m_IsDetonating)
			{
				StartCoroutine(C_DetonateWithDelay(m_Detonator));
			}
		}

		protected virtual void Detonate(Entity launcher)
		{
			m_DetonateOnImpact = false;
			m_OnExplosiveDetonate.Invoke();
			for (int i = 0; i < m_DamageDealers.Length; i++)
			{
				m_DamageDealers[i].gameObject.SetActive(value: true);
				m_DamageDealers[i].ActivateDamage(launcher);
			}
			Object.Destroy(base.gameObject);
		}

		private IEnumerator C_DetonateWithDelay(Entity launcher)
		{
			yield return new WaitForSeconds(m_DetonationDelay);
			Detonate(launcher);
		}
	}
}
