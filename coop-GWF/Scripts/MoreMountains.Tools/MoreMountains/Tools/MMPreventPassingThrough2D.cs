using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MMPreventPassingThrough2D")]
	public class MMPreventPassingThrough2D : MonoBehaviour
	{
		public enum Modes
		{
			Raycast = 0,
			BoxCast = 1
		}

		public Modes Mode;

		public LayerMask ObstaclesLayerMask;

		public float SkinWidth = 0.1f;

		public bool RepositionRigidbodyIfHitTrigger = true;

		[FormerlySerializedAs("RepositionRigidbody")]
		public bool RepositionRigidbodyIfHitNonTrigger = true;

		[Header("Debug")]
		[MMReadOnly]
		public RaycastHit2D Hit;

		protected float _smallestBoundsWidth;

		protected float _adjustedSmallestBoundsWidth;

		protected float _squaredBoundsWidth;

		protected Vector3 _positionLastFrame;

		protected Rigidbody2D _rigidbody;

		protected Collider2D _collider;

		protected Vector2 _lastMovement;

		protected float _lastMovementSquared;

		protected RaycastHit2D _hitInfo;

		protected Vector2 _colliderSize;

		protected virtual void Start()
		{
			Initialization();
		}

		protected virtual void Initialization()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_positionLastFrame = _rigidbody.position;
			_collider = GetComponent<Collider2D>();
			if (_collider as BoxCollider2D != null)
			{
				_colliderSize = (_collider as BoxCollider2D).size;
			}
			_smallestBoundsWidth = Mathf.Min(Mathf.Min(_collider.bounds.extents.x, _collider.bounds.extents.y), _collider.bounds.extents.z);
			_adjustedSmallestBoundsWidth = _smallestBoundsWidth * (1f - SkinWidth);
			_squaredBoundsWidth = _smallestBoundsWidth * _smallestBoundsWidth;
		}

		protected virtual void OnEnable()
		{
			_positionLastFrame = base.transform.position;
		}

		protected virtual void Update()
		{
			_lastMovement = base.transform.position - _positionLastFrame;
			_lastMovementSquared = _lastMovement.sqrMagnitude;
			if (_lastMovementSquared > _squaredBoundsWidth)
			{
				float num = Mathf.Sqrt(_lastMovementSquared);
				if (Mode == Modes.Raycast)
				{
					_hitInfo = MMDebug.RayCast(_positionLastFrame, _lastMovement.normalized, num, ObstaclesLayerMask, Color.blue, drawGizmo: true);
				}
				else
				{
					_hitInfo = Physics2D.BoxCast(_positionLastFrame, _colliderSize, 0f, layerMask: ObstaclesLayerMask, direction: _lastMovement.normalized, distance: num);
				}
				if (_hitInfo.collider != null)
				{
					if (_hitInfo.collider.isTrigger)
					{
						_hitInfo.collider.SendMessage("OnTriggerEnter2D", _collider, SendMessageOptions.DontRequireReceiver);
						if (RepositionRigidbodyIfHitTrigger)
						{
							base.transform.position = _hitInfo.point - _lastMovement / num * _adjustedSmallestBoundsWidth;
							_rigidbody.position = _hitInfo.point - _lastMovement / num * _adjustedSmallestBoundsWidth;
						}
					}
					if (!_hitInfo.collider.isTrigger)
					{
						Hit = _hitInfo;
						base.gameObject.SendMessage("PreventedCollision2D", Hit, SendMessageOptions.DontRequireReceiver);
						if (RepositionRigidbodyIfHitNonTrigger)
						{
							base.transform.position = _hitInfo.point - _lastMovement / num * _adjustedSmallestBoundsWidth;
							_rigidbody.position = _hitInfo.point - _lastMovement / num * _adjustedSmallestBoundsWidth;
						}
					}
				}
			}
			_positionLastFrame = base.transform.position;
		}
	}
}
