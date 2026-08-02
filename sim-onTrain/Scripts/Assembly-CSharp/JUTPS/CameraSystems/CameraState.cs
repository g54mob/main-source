using System;
using UnityEngine;

namespace JUTPS.CameraSystems
{
	[Serializable]
	public class CameraState
	{
		[Header("Settings")]
		public string StateName = "Camera State";

		public float Distance;

		public float MovementSpeed;

		[Header("Camera FOV")]
		public float CameraFieldOfView;

		[Header("Camera Pivot Position Offsets")]
		public float UpTargetOffset = 1f;

		public float RightTargetOffset;

		public float ForwardTargetOffset;

		[Header("Camera Position Adjustment")]
		public float RightCameraOffset = 0.6f;

		public float UpCameraOffset = 0.45f;

		public float ForwardCameraOffset;

		[Header("Camera Rotation Settings")]
		public float RotationSensibility = 1f;

		public float VerticalRotationSensibility = 0.7f;

		public float MaxRotation = -80f;

		public float MinRotation = 80f;

		[Header("Camera Layer Collisions")]
		public LayerMask CollisionLayers;

		[HideInInspector]
		public string SettingsIDName;

		public Vector3 GetCameraPivotPosition(Transform target)
		{
			if (!(target != null))
			{
				return Vector3.zero;
			}
			return target.position + target.up * UpTargetOffset + target.forward * ForwardTargetOffset + target.right * RightTargetOffset;
		}

		public Vector3 GetCameraPosition(Transform camera)
		{
			return camera.parent.position - camera.forward * (Distance + ForwardCameraOffset) + camera.right * RightCameraOffset + camera.up * UpCameraOffset;
		}

		public CameraState(string stateName, float distance = 3f, float movementSpeed = 15f, float cameraFielOfView = 60f, float upOffset = 0f, float rightOffset = 0f, float forwardOffset = 0f, float xAdjust = 0.6f, float yAdjust = 0.6f, float zAdjust = 0f, float rotationSensibility = 5f, float minRotation = -80f, float maxRotation = 80f)
		{
			StateName = stateName;
			Distance = distance;
			MovementSpeed = movementSpeed;
			CameraFieldOfView = cameraFielOfView;
			UpTargetOffset = upOffset;
			RightTargetOffset = rightOffset;
			ForwardTargetOffset = forwardOffset;
			RightCameraOffset = xAdjust;
			UpCameraOffset = yAdjust;
			ForwardCameraOffset = zAdjust;
			RotationSensibility = rotationSensibility;
			MinRotation = minRotation;
			MaxRotation = maxRotation;
			SettingsIDName = stateName;
		}
	}
}
