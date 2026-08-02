using System;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public class DestructibleObject : MonoBehaviour, IDamageable
	{
		[Serializable]
		public class DebrisFragment
		{
			[SerializeField]
			private Rigidbody m_Piece;

			[Header("Default Force")]
			[SerializeField]
			private Vector3 m_DefaultForceMin;

			[SerializeField]
			private Vector3 m_DefaultForceMax;

			public Rigidbody Fragment => m_Piece;

			public DebrisFragment(Rigidbody rigidbody, Vector3 defaultForceMin = default(Vector3), Vector3 defaultForceMax = default(Vector3))
			{
				m_Piece = rigidbody;
				m_DefaultForceMin = defaultForceMin;
				m_DefaultForceMax = defaultForceMax;
			}

			public void ApplyDefaultForce()
			{
				Vector3 force = new Vector3(UnityEngine.Random.Range(m_DefaultForceMin.x, m_DefaultForceMax.x), UnityEngine.Random.Range(m_DefaultForceMin.y, m_DefaultForceMax.y), UnityEngine.Random.Range(m_DefaultForceMin.z, m_DefaultForceMax.z));
				m_Piece.AddForce(force, ForceMode.Impulse);
			}

			public void ApplyCustomForce(Vector3 force, ForceMode forceMode)
			{
				m_Piece.AddForce(force, forceMode);
			}
		}

		[BHeader("Health")]
		[SerializeField]
		[Clamp(0f, 100f)]
		private float m_InitialHealth = 100f;

		[SerializeField]
		private DamageResistance m_DamageResistance;

		[BHeader("Debris")]
		[SerializeField]
		[Tooltip("Must be a child of the object.")]
		private GameObject m_DestroyedVersion;

		[Space]
		[SerializeField]
		private List<DebrisFragment> m_DebrisFragments;

		[SerializeField]
		private bool m_ApplyDefaultDebrisForce;

		[SerializeField]
		private float m_CustomDebrisForceMult = 1f;

		private float m_CurrentHealth = 100f;

		private bool m_Destroyed;

		public void TakeDamage(DamageInfo damageData)
		{
			if (!m_Destroyed)
			{
				float num = 0f - Mathf.Abs(damageData.Delta);
				num *= 1f - m_DamageResistance.GetDamageResistance(damageData);
				m_CurrentHealth = Mathf.Clamp(m_CurrentHealth + num, 0f, m_InitialHealth);
				if (m_CurrentHealth == 0f)
				{
					DestroyObject(damageData);
				}
			}
		}

		protected virtual void DestroyObject(DamageInfo data)
		{
			m_DestroyedVersion.transform.SetParent(base.transform.parent);
			m_DestroyedVersion.SetActive(value: true);
			float num = data.HitImpulse * m_CustomDebrisForceMult / (float)m_DebrisFragments.Count;
			for (int i = 0; i < m_DebrisFragments.Count; i++)
			{
				Vector3 force = (data.HitDirection + Vector3.down + (m_DebrisFragments[i].Fragment.position - base.transform.position)) * num;
				if (m_ApplyDefaultDebrisForce)
				{
					m_DebrisFragments[i].ApplyDefaultForce();
				}
				else
				{
					m_DebrisFragments[i].ApplyCustomForce(force, ForceMode.Impulse);
				}
			}
			m_Destroyed = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void Start()
		{
			m_CurrentHealth = m_InitialHealth;
		}
	}
}
