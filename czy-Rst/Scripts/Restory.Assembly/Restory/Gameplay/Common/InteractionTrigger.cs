using Restory.Constants;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Common
{
	public class InteractionTrigger : MonoBehaviour, IInteractionTrigger
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private BoxCollider boxCollider;

		private readonly Collider[] collisions = new Collider[2];

		private Vector3 colliderSize;

		private Vector3 colliderCenter;

		private Vector3 colliderHalfExtents;

		private LayerMask collisionMask;

		public InteractiveObject InteractiveObject => interactiveObject;

		public BoxCollider Collider => boxCollider;

		private void Start()
		{
			collisionMask = ProjectConstants.Layers.InteractiveObjectsMask | ProjectConstants.Layers.ObstaclesMask;
			CacheColliderParams();
		}

		public void ChangeColliderParams(BoxCollider boxCollider)
		{
			this.boxCollider.size = boxCollider.size;
			this.boxCollider.center = boxCollider.center;
			CacheColliderParams();
		}

		public bool HasCollision()
		{
			int num = Physics.OverlapBoxNonAlloc(base.transform.TransformPoint(colliderCenter), colliderHalfExtents, collisions, base.transform.rotation, collisionMask);
			for (int i = 0; i < num; i++)
			{
				if (!(collisions[i] == boxCollider))
				{
					return true;
				}
			}
			return false;
		}

		private void CacheColliderParams()
		{
			colliderSize = boxCollider.size;
			colliderCenter = boxCollider.center;
			colliderHalfExtents = colliderSize * 0.5f;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Matrix4x4 matrix = Gizmos.matrix;
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.DrawWireCube(colliderCenter, colliderSize);
			Gizmos.matrix = matrix;
		}
	}
}
