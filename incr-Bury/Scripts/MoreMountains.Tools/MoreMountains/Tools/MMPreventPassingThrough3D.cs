using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MM Prevent Passing Through 3D")]
	public class MMPreventPassingThrough3D : MonoBehaviour
	{
		public enum AdjustmentAxis
		{
			Auto = 0,
			X = 1,
			Y = 2,
			Z = 3
		}

		public LayerMask ObstaclesLayerMask;

		public float SkinWidth = 0.1f;

		public bool RepositionRigidbody = true;

		public LayerMask RepositionRigidbodyLayerMask;

		public AdjustmentAxis Adjustment;

		protected float _adjustmentDistance;

		protected float _adjustedDistance;

		protected float _squaredBoundsWidth;

		protected Vector3 _positionLastFrame;

		protected Rigidbody _rigidbody;

		protected Collider _collider;

		protected Vector3 _lastMovement;

		protected float _lastMovementSquared;

		protected virtual void OnValidate()
		{
			if (RepositionRigidbody && RepositionRigidbodyLayerMask.value == 0)
			{
				RepositionRigidbodyLayerMask = ObstaclesLayerMask;
			}
		}

		protected virtual void Start()
		{
			Initialization();
		}

		protected virtual void Initialization()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_positionLastFrame = _rigidbody.position;
			_collider = GetComponent<Collider>();
			_adjustmentDistance = ComputeAdjustmentDistance();
			_adjustedDistance = _adjustmentDistance * (1f - SkinWidth);
			_squaredBoundsWidth = _adjustmentDistance * _adjustmentDistance;
		}

		protected virtual float ComputeAdjustmentDistance()
		{
			return Adjustment switch
			{
				AdjustmentAxis.X => _collider.bounds.extents.x, 
				AdjustmentAxis.Y => _collider.bounds.extents.y, 
				AdjustmentAxis.Z => _collider.bounds.extents.z, 
				_ => Mathf.Min(Mathf.Min(_collider.bounds.extents.x, _collider.bounds.extents.y), _collider.bounds.extents.z), 
			};
		}

		protected virtual void OnEnable()
		{
			_positionLastFrame = base.transform.position;
		}

		protected virtual void FixedUpdate()
		{
			_lastMovement = base.transform.position - _positionLastFrame;
			_lastMovementSquared = _lastMovement.sqrMagnitude;
			if (_lastMovementSquared > _squaredBoundsWidth)
			{
				float num = Mathf.Sqrt(_lastMovementSquared);
				if (Physics.Raycast(_positionLastFrame, _lastMovement, out var hitInfo, num, ObstaclesLayerMask.value))
				{
					if (!hitInfo.collider)
					{
						return;
					}
					if (hitInfo.collider.isTrigger)
					{
						hitInfo.collider.SendMessage("OnTriggerEnter", _collider);
					}
					if (!hitInfo.collider.isTrigger)
					{
						base.gameObject.SendMessage("PreventedCollision3D", hitInfo, SendMessageOptions.DontRequireReceiver);
						if (RepositionRigidbody)
						{
							int layer = hitInfo.collider.gameObject.layer;
							if (((1 << layer) & (int)RepositionRigidbodyLayerMask) != 0)
							{
								base.transform.position = hitInfo.point - _lastMovement / num * _adjustedDistance;
								_rigidbody.position = hitInfo.point - _lastMovement / num * _adjustedDistance;
							}
						}
					}
				}
			}
			_positionLastFrame = base.transform.position;
		}
	}
}
