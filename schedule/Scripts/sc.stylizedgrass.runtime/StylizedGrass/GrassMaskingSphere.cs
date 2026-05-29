using UnityEngine;

namespace StylizedGrass
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class GrassMaskingSphere : MonoBehaviour
	{
		[Min(0.1f)]
		public float radius;

		public Vector3 offset;

		private Vector4 vector;

		private readonly int _PlayerSphereID;

		public void Update()
		{
		}

		private void UpdateProperties()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
