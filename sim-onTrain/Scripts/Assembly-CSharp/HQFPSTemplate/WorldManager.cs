using UnityEngine;

namespace HQFPSTemplate
{
	public class WorldManager : Singleton<WorldManager>
	{
		[SerializeField]
		private float m_NorthAngleDirection;

		public Vector3 NorthDirection
		{
			get
			{
				return GetNorthDirection();
			}
			private set
			{
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.DrawRay(base.transform.position, GetNorthDirection());
			Gizmos.DrawWireSphere(GetNorthDirection(), 0.15f);
		}

		private Vector3 GetNorthDirection()
		{
			return Quaternion.Euler(0f, m_NorthAngleDirection, 0f) * Vector3.forward;
		}
	}
}
