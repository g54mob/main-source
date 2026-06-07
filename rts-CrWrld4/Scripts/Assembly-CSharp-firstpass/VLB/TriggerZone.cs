using UnityEngine;

namespace VLB
{
	[DisallowMultipleComponent]
	public class TriggerZone : MonoBehaviour
	{
		public bool setIsTrigger;

		public float rangeMultiplier;

		private const int kMeshColliderNumSides = 8;

		private Mesh m_Mesh;

		private void Update()
		{
		}
	}
}
