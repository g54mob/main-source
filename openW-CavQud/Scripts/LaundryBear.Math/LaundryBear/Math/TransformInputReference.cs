using UnityEngine;

namespace LaundryBear.Math
{
	public class TransformInputReference : MonoBehaviour, IInputReferenceFrame
	{
		public Vector3 ProjectOnGround(Vector2 directionalInput, Vector3 up)
		{
			Vector3 vector = Vector3.ProjectOnPlane(base.transform.forward, up);
			Vector3 vector2 = Vector3.ProjectOnPlane(base.transform.right, up);
			return (vector * directionalInput.y + vector2 * directionalInput.x).normalized;
		}

		public Vector3 GetWorldForward()
		{
			return base.transform.forward;
		}

		public Vector3 GetWorldPosition()
		{
			return base.transform.position;
		}

		public Vector3 ProcessAnalogueStick(Vector2 directionalInput, Vector3 targetObjectPosition, Vector3 targetObjectForward)
		{
			return Vector3.ProjectOnPlane(base.transform.TransformDirection(directionalInput.x, 0f, directionalInput.y), Vector3.up).normalized;
		}

		public Vector3 ProcessAnalogueStick(Vector2 directionalInput, Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 upVector)
		{
			return Vector3.ProjectOnPlane(base.transform.TransformDirection(directionalInput.x, 0f, directionalInput.y), upVector).normalized;
		}

		public void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, out Vector3 forwardVector, out Vector3 rightVector)
		{
			forwardVector = Vector3.ProjectOnPlane(base.transform.forward, Vector3.up).normalized;
			rightVector = Vector3.ProjectOnPlane(base.transform.right, Vector3.up).normalized;
		}

		public void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 up, out Vector3 forwardVector, out Vector3 rightVector)
		{
			forwardVector = Vector3.ProjectOnPlane(base.transform.forward, up).normalized;
			rightVector = Vector3.ProjectOnPlane(base.transform.right, up).normalized;
		}
	}
}
