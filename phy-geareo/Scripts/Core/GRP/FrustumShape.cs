using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class FrustumShape : MonoBehaviour
	{
		public MeshCollider meshCollider;

		public List<Collider> targets;

		private bool dirty;

		public void Fetch(Camera camera, Vector2 position, Vector2 size)
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}
	}
}
