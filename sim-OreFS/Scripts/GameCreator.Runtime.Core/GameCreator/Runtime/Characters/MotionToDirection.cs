using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionToDirection : TMotion
	{
		public Character.MovementType Setup(Vector3 velocity, Space space)
		{
			Setup();
			Character.MovementType result = ((velocity.sqrMagnitude > 0.01f) ? Character.MovementType.MoveToDirection : Character.MovementType.None);
			velocity = CalculateAcceleration(velocity);
			TUnitMotion motion = base.Motion;
			motion.MoveDirection = space switch
			{
				Space.World => velocity, 
				Space.Self => base.Transform.TransformDirection(velocity), 
				_ => base.Motion.MoveDirection, 
			};
			base.Motion.MovePosition = base.Transform.TransformPoint(base.Motion.MoveDirection);
			return result;
		}

		public override Character.MovementType Update()
		{
			base.Motion.MovePosition = base.Motion.Transform.TransformPoint(base.Motion.MoveDirection);
			if (!(base.Motion.MoveDirection.sqrMagnitude > 0.01f))
			{
				return Character.MovementType.None;
			}
			return Character.MovementType.MoveToDirection;
		}
	}
}
