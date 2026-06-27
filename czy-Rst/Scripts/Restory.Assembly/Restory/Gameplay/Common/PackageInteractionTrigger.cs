using Restory.Constants;
using Restory.Data.Outline;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Common
{
	public class PackageInteractionTrigger : MonoBehaviour, IInteractionTrigger
	{
		[SerializeField]
		private BoxCollider boxCollider;

		[SerializeField]
		private OutlineSettingsPreset selectedPreset;

		[SerializeField]
		private OutlineSettingsPreset collidingPreset;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		private readonly Collider[] collisions = new Collider[2];

		private Vector3 colliderSize;

		private Vector3 colliderCenter;

		private Vector3 colliderHalfExtents;

		private LayerMask collisionMask;

		private InteractiveObject packedInteractiveObject;

		public InteractiveObject InteractiveObject => packedInteractiveObject;

		public BoxCollider Collider => boxCollider;

		private void Start()
		{
			collisionMask = ProjectConstants.Layers.InteractiveObjectsMask | ProjectConstants.Layers.ObstaclesMask;
			CacheColliderParams();
		}

		private void OnDisable()
		{
			Cleanup();
		}

		public void Init(InteractiveObject packedInteractiveObject)
		{
			this.packedInteractiveObject = packedInteractiveObject;
			packedInteractiveObject.OnSelected += ResolveSelect;
			packedInteractiveObject.OnDeselected += ResolveDeselect;
			packedInteractiveObject.OnDragStateChanged += ResolveDragStateChanged;
		}

		public void Cleanup()
		{
			if ((bool)packedInteractiveObject)
			{
				packedInteractiveObject.OnSelected -= ResolveSelect;
				packedInteractiveObject.OnDeselected -= ResolveDeselect;
				packedInteractiveObject.OnDragStateChanged -= ResolveDragStateChanged;
				packedInteractiveObject = null;
			}
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

		private void ResolveSelect()
		{
			outlinableAdapter.OverridePreset = selectedPreset;
			outlinableAdapter.IsActive = true;
		}

		private void ResolveDeselect()
		{
			outlinableAdapter.IsActive = false;
		}

		private void ResolveDragStateChanged(InteractiveObjectDragState dragState)
		{
			switch (dragState)
			{
			case InteractiveObjectDragState.None:
			case InteractiveObjectDragState.FreeSoared:
				outlinableAdapter.IsActive = false;
				break;
			case InteractiveObjectDragState.Storable:
			case InteractiveObjectDragState.Shippable:
				outlinableAdapter.OverridePreset = selectedPreset;
				outlinableAdapter.IsActive = true;
				break;
			default:
				outlinableAdapter.OverridePreset = collidingPreset;
				outlinableAdapter.IsActive = true;
				break;
			}
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
