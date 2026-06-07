using UnityEngine;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Collider))]
	public class MMCinemachineZone3D : MMCinemachineZone
	{
		protected Collider _collider;

		protected Collider _confinerCollider;

		protected Rigidbody _confinerRigidbody;

		protected BoxCollider _boxCollider;

		protected SphereCollider _sphereCollider;
	}
}
