using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class KillCameraController : InteractiveCameraController
	{
		private bool _centerOnRigidBody;

		private float _distance;

		private Quaternion _rotation;

		private Transform _target;

		protected override bool SupportsMovementInXR => true;

		public KillCameraController(CameraManagerScript cameraManager, PartScript targetPart, bool centerOnRigidBody)
			: base(cameraManager)
		{
			base.Name = "Impact Cam View";
			_target = targetPart.transform;
			_centerOnRigidBody = centerOnRigidBody;
			_targetDistance = 15f;
			_deltaRotation = new Vector3(25f, -5f);
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
		}

		public override void OnSelected()
		{
			base.OnSelected();
			Vector3 forward = _target.forward;
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.forward, forward);
			_deltaRotation = new Vector2(quaternion.eulerAngles.x + 10f, quaternion.eulerAngles.y + 10f);
			_rotation = Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			_distance = Mathf.Lerp(_distance, _targetDistance, 3f * Time.unscaledDeltaTime);
			Quaternion b = Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
			_rotation = Quaternion.Slerp(_rotation, b, 3f * Time.unscaledDeltaTime);
			Vector3 position = _target.position;
			if (_centerOnRigidBody)
			{
				Rigidbody componentInParent = _target.GetComponentInParent<Rigidbody>();
				if (componentInParent != null)
				{
					position = componentInParent.transform.position;
				}
			}
			base.CameraTransform.position = position - _rotation * Vector3.forward * _distance;
			base.CameraTransform.LookAt(position, Vector3.up);
			ForceCameraAboveTerrain(position);
			base.CameraManager.CameraFocalPosition.position = _target.position;
		}
	}
}
