using UnityEngine;

namespace HQFPSTemplate
{
	public class ExplosiveBarrel : MonoBehaviour, IDamageable
	{
		[SerializeField]
		private float m_Health = 100f;

		[SerializeField]
		private DamageDealerObject m_Explosion;

		private bool m_Exploded;

		public void TakeDamage(DamageInfo damageData)
		{
			if (!m_Exploded)
			{
				m_Health += damageData.Delta;
				if (m_Health <= 0f)
				{
					m_Exploded = true;
					m_Explosion.ActivateDamage(null);
					Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
