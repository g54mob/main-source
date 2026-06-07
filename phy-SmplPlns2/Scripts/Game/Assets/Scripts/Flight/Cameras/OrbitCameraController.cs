using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class OrbitCameraController : InteractiveCameraController
	{
		private bool _centerOnRigidBody;

		private Vector2 _currentRotation = Vector2.zero;

		private Func<IRigidBody> _targetBody;

		private Func<Transform> _targetTransform;

		protected override bool SupportsMovementInXR => true;

		public OrbitCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, PartScript targetPart)
			: base(cameraManager)
		{
			Initialize(cameraManager, centerOnRigidBody, () => targetPart.transform, () => targetPart.Body.RigidBody);
		}

		public OrbitCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, Func<Transform> transform, Func<IRigidBody> body)
			: base(cameraManager)
		{
			Initialize(cameraManager, centerOnRigidBody, transform, body);
		}

		public OrbitCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, CameraVantageScript cameraVantage)
			: base(cameraManager)
		{
			base.CameraVantage = cameraVantage;
			Initialize(cameraManager, centerOnRigidBody, () => cameraVantage.TransformToTrack, () => cameraVantage.RigidBody);
		}

		public override bool AllowGunReticle(Transform targetingTransform)
		{
			return AllowMissileLocking(targetingTransform);
		}

		public override bool AllowMissileLocking(Transform targetingTransform)
		{
			if (targetingTransform == null)
			{
				return false;
			}
			return Vector3.Dot(base.CameraTransform.forward, targetingTransform.forward) > 0.9f;
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			Transform transform = _targetTransform() ?? base.CameraManager.CameraFocalPosition;
			float num = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.025f);
			base.CameraManager.SharedCameraDistance = Mathf.Lerp(base.CameraManager.SharedCameraDistance, _targetDistance, 3f * num);
			_currentRotation = Vector2.Lerp(_currentRotation, _deltaRotation, 3f * num);
			base.CameraManager.SharedCameraRotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, 0f);
			Vector3 position = transform.position;
			if (_centerOnRigidBody)
			{
				IRigidBody rigidBody = _targetBody();
				if (rigidBody != null)
				{
					position = rigidBody.position;
				}
			}
			position += _targetPositionOffset * 0.5f;
			base.CameraTransform.position = position - base.CameraManager.SharedCameraRotation * Vector3.forward * base.CameraManager.SharedCameraDistance;
			base.CameraTransform.LookAt(position, Vector3.up);
			base.CameraTransform.Rotate(0f, 0f, _cameraRotationOffset);
			ForceCameraAboveTerrain(position - _targetPositionOffset * 0.5f);
			base.CameraManager.CameraFocalPosition.position = transform.position;
		}

		private void Initialize(CameraManagerScript cameraManager, bool centerOnRigidBody, Func<Transform> transform, Func<IRigidBody> body)
		{
			base.Name = "Orbit View";
			_targetTransform = transform;
			_targetBody = body;
			_centerOnRigidBody = centerOnRigidBody;
			_targetDistance = 15f;
			_deltaRotation = new Vector3(15f, 0f, 0f);
		}
	}
}
