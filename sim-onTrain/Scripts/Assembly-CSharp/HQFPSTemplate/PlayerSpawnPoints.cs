using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerSpawnPoints : MonoBehaviour
	{
		[SerializeField]
		private float m_MaxVerticalRaycast = 2f;

		[SerializeField]
		private LayerMask m_GroundLayerMask = 0;

		private Transform[] m_Spawnpoints;

		public Vector3 GetRandomSpawnPoint()
		{
			if (m_Spawnpoints != null)
			{
				Vector3 vector = m_Spawnpoints[Random.Range(0, m_Spawnpoints.Length)].position;
				if (Physics.Raycast(vector, -base.transform.up, out var hitInfo, m_MaxVerticalRaycast, m_GroundLayerMask))
				{
					vector = hitInfo.point + Vector3.up * 0.1f;
				}
				return vector;
			}
			return Vector3.zero;
		}

		public Quaternion GetRandomRotation()
		{
			return Quaternion.Euler(0f, Random.Range(0, 360), 0f);
		}

		private void Awake()
		{
			m_Spawnpoints = GetComponentsInChildren<Transform>();
		}
	}
}
