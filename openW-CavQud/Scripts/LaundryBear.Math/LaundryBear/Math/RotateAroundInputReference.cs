using System;
using UnityEngine;

namespace LaundryBear.Math
{
	public class RotateAroundInputReference : MonoBehaviour, IInputReferenceFrame
	{
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
			ProcessAnalogueStick(targetObjectPosition, targetObjectForward, out var forwardVector, out var rightVector);
			return directionalInput.x * rightVector + directionalInput.y * forwardVector;
		}

		public Vector3 ProcessAnalogueStick(Vector2 directionalInput, Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 upVector)
		{
			ProcessAnalogueStick(targetObjectPosition, targetObjectForward, upVector, out var forwardVector, out var rightVector);
			return directionalInput.x * rightVector + directionalInput.y * forwardVector;
		}

		public void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, out Vector3 forwardVector, out Vector3 rightVector)
		{
			Vector3 normalized = new Vector3(targetObjectPosition.x - base.transform.position.x, 0f, targetObjectPosition.z - base.transform.position.z).normalized;
			forwardVector = normalized;
			rightVector = Vector3.Cross(Vector3.up, forwardVector);
		}

		public void ProcessAnalogueStick(Vector3 targetObjectPosition, Vector3 targetObjectForward, Vector3 upVector, out Vector3 forwardVector, out Vector3 rightVector)
		{
			Vector3 normalized = new Vector3(targetObjectPosition.x - base.transform.position.x, 0f, targetObjectPosition.z - base.transform.position.z).normalized;
			forwardVector = normalized;
			rightVector = Vector3.Cross(upVector, forwardVector);
		}

		public Vector3 ProjectOnGround(Vector2 directionalInput, Vector3 up)
		{
			throw new NotImplementedException();
		}
	}
}
