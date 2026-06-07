using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MMPreventPassingThrough3D")]
	public class MMPreventPassingThrough3D : MonoBehaviour
	{
		public LayerMask ObstaclesLayerMask;

		public float SkinWidth;

		public bool RepositionRigidbody;

		public LayerMask RepositionRigidbodyLayerMask;

		protected float _smallestBoundsWidth;

		protected float _adjustedSmallestBoundsWidth;

		protected float _squaredBoundsWidth;

		protected Vector3 _positionLastFrame;

		protected Rigidbody _rigidbody;

		protected Collider _collider;

		protected Vector3 _lastMovement;

		protected float _lastMovementSquared;

		protected virtual void OnValidate()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Initialization()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void FixedUpdate()
		{
		}
	}
}
