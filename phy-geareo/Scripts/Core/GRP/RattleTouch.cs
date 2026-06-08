using UnityEngine;

namespace GRP
{
	public struct RattleTouch
	{
		public RattleKey key;

		public Collider colliderA;

		public Collider colliderB;

		public Rigidbody rigidbodyA;

		public Rigidbody rigidbodyB;

		public Collision collision;

		public ContactPoint contact;

		public Vector3 velocity;

		public void Build()
		{
		}
	}
}
