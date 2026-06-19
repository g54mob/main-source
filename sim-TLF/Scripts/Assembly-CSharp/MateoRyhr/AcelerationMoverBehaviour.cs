using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class AcelerationMoverBehaviour : MoverBehaviour, IAceleratedMovement, IMovement
	{
		[Header("Required")]
		[SerializeField]
		private Rigidbody _rigidBody;

		[Header("Settings")]
		[Header("The curve need to go from 0 to 1")]
		[SerializeField]
		private AnimationCurve _acelerationCurve;

		[Header("The curve need to go from 1 to 0")]
		[SerializeField]
		private AnimationCurve _decelerationCurve;

		[SerializeField]
		private FloatVariable _timeToReachMaxSpeed;

		[SerializeField]
		private FloatVariable _timeToStop;

		public UnityEvent OnStartMove;

		public UnityEvent OnNoMove;

		private bool _isMoving;

		public float TimeToReachMaxSpeed => _timeToReachMaxSpeed.Value;

		public float TimeToStop => _timeToStop.Value;

		public float MaxSpeed => _maxSpeed.Value;

		private protected override void Awake()
		{
			base.Awake();
			_mover = new AcelerationMover(this, _acelerationCurve, _decelerationCurve);
			base.CanMove = true;
		}

		private void FixedUpdate()
		{
			if (!_isMoving)
			{
				if (_direction.Value != Vector2.zero)
				{
					_isMoving = true;
					OnStartMove?.Invoke();
				}
			}
			else if (_direction.Value == Vector2.zero)
			{
				_isMoving = false;
				OnNoMove?.Invoke();
			}
			ApplyMovement(_mover.Move(GetMovementDirection(), Time.fixedDeltaTime));
		}

		private void ApplyMovement(Vector3 vel)
		{
			_rigidBody.linearVelocity = new Vector3(vel.x, _rigidBody.linearVelocity.y, vel.z);
		}

		private Vector3 GetMovementDirection()
		{
			if (!base.CanMove)
			{
				return Vector3.zero;
			}
			return base.transform.TransformDirection(new Vector3(_direction.Value.x, 0f, _direction.Value.y));
		}
	}
}
