using UnityEngine;

namespace LaundryBear.Math
{
	public interface IInputReferenceFrame
	{
		Vector3 ProjectOnGround(Vector2 directionalInput, Vector3 up);

		Vector3 GetWorldForward();

		Vector3 GetWorldPosition();

		Vector3 ProcessAnalogueStick(Vector2 directionalInput, Vector3 targetObjectPosition, Vector3 targetObjectForward);

		Vector3 ProcessAnalogueStick(Vector2 directionalInput, Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 upVector);

		void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, out Vector3 forwardVector, out Vector3 rightVector);

		void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 upVector, out Vector3 forwardVector, out Vector3 rightVector);
	}
}
