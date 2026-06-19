using UnityEngine;

namespace MateoRyhr
{
	public class AcelerationMover : IMover
	{
		private AnimationCurve _acelerationCurve;

		private AnimationCurve _decelerationCurve;

		private float _timeSpeedingUp;

		private float _timeSlowingDown;

		private Vector3 _lastMovementDirection;

		private float _lastSpeed;

		public IMovement Movement => AceleratedMovement;

		public IAceleratedMovement AceleratedMovement { get; private set; }

		public AcelerationMover(IAceleratedMovement movement, AnimationCurve acelerationCurve, AnimationCurve decelerationCurve)
		{
			AceleratedMovement = movement;
			_acelerationCurve = acelerationCurve;
			_decelerationCurve = decelerationCurve;
			_lastMovementDirection = Vector3.zero;
		}

		public Vector3 Move(Vector3 direction, float timeLapsed)
		{
			if (direction != Vector3.zero)
			{
				_timeSlowingDown = 0f;
				return Acelerate(direction, timeLapsed);
			}
			_timeSpeedingUp = 0f;
			return Decelerate(timeLapsed);
		}

		private Vector3 Acelerate(Vector3 direction, float timeLapsed)
		{
			_timeSpeedingUp = Mathf.Clamp(_timeSpeedingUp + timeLapsed, 0f, AceleratedMovement.TimeToReachMaxSpeed);
			_lastMovementDirection = direction;
			_lastSpeed = GetSpeedInCurve(_acelerationCurve, _timeSpeedingUp, AceleratedMovement.TimeToReachMaxSpeed);
			return direction * _lastSpeed;
		}

		private Vector3 Decelerate(float timeLapsed)
		{
			_timeSlowingDown = Mathf.Clamp(_timeSlowingDown + timeLapsed, 0f, AceleratedMovement.TimeToStop);
			_lastSpeed = GetSpeedInCurve(_decelerationCurve, _timeSlowingDown, AceleratedMovement.TimeToStop);
			return _lastMovementDirection * _lastSpeed;
		}

		private float GetSpeedInCurve(AnimationCurve curve, float currentTime, float timeToReach)
		{
			return curve.Evaluate(currentTime / timeToReach) * AceleratedMovement.MaxSpeed;
		}
	}
}
