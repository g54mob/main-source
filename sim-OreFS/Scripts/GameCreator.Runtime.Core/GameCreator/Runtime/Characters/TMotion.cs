using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public abstract class TMotion
	{
		protected TUnitMotion Motion { get; private set; }

		protected Character Character { get; private set; }

		protected Transform Transform { get; private set; }

		public int Priority { get; internal set; }

		public void Initialize(TUnitMotion motion, int priority)
		{
			Priority = priority;
			Motion = motion;
			Character = motion.Character;
			Transform = motion.Transform;
		}

		public abstract Character.MovementType Update();

		public virtual Character.MovementType Stop(bool success)
		{
			Priority = -1;
			Motion.MoveDirection = Vector3.zero;
			Motion.MovePosition = Transform.position;
			return Character.MovementType.None;
		}

		public virtual void OnDrawGizmos()
		{
		}

		protected virtual void Setup()
		{
		}

		protected Vector3 CalculateSpeed(Vector3 direction)
		{
			direction = direction.normalized * Motion.LinearSpeed;
			return direction;
		}

		protected Vector3 CalculateAcceleration(Vector3 tarDirection)
		{
			if (!Motion.UseAcceleration)
			{
				return tarDirection;
			}
			Vector3 moveDirection = Character.Motion.MoveDirection;
			if (tarDirection.sqrMagnitude < 0.01f)
			{
				tarDirection = Vector3.zero;
			}
			bool num = moveDirection.sqrMagnitude < tarDirection.sqrMagnitude;
			moveDirection = Vector3.Lerp(t: (num ? Motion.Acceleration : Motion.Deceleration) * Character.Time.DeltaTime, a: moveDirection, b: tarDirection);
			if (num)
			{
				return (Vector3.Project(moveDirection, tarDirection).sqrMagnitude < tarDirection.sqrMagnitude) ? moveDirection : tarDirection;
			}
			float sqrMagnitude = moveDirection.sqrMagnitude;
			float sqrMagnitude2 = tarDirection.sqrMagnitude;
			return (Mathf.Abs(sqrMagnitude) > 0.01f || Mathf.Abs(sqrMagnitude2) > 0.01f) ? moveDirection : Vector3.zero;
		}
	}
}
