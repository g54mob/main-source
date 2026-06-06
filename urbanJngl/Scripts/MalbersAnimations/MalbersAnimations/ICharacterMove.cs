using UnityEngine;

namespace MalbersAnimations
{
	public interface ICharacterMove
	{
		bool MovementDetected { get; }

		void Move(Vector3 move);

		void StopMoving();

		void SetInputAxis(Vector3 inputAxis);

		void SetInputAxis(Vector2 inputAxis);
	}
}
