using ModApi.Craft.Parts;
using ModApi.Flight;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	internal class KillCameraController : InteractiveCameraController
	{
		private bool _centerOnRigidBody;

		private float _distance;

		private Quaternion _rotation;

		private Transform _target;

		private ITimeMultiplierMode _timeModeBackup;

		public override bool AllowDefault => false;

		public override string Type => "Impact Cam";

		internal KillCameraController(CameraManagerScript cameraManager, IPartScript targetPart, bool centerOnRigidBody)
			: base(cameraManager)
		{
			_target = targetPart.Transform;
			_centerOnRigidBody = centerOnRigidBody;
			base.TargetDistance = 15f;
			base.DeltaRotation = new Vector3(25f, -5f);
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
			Game.Instance.FlightScene.TimeManager.SetMode(_timeModeBackup);
		}

		public override void OnSelected(int subMode)
		{
			base.OnSelected(subMode);
			_timeModeBackup = Game.Instance.FlightScene.TimeManager.CurrentMode;
			Game.Instance.FlightScene.TimeManager.SetSlowMotionMode();
			Vector3 forward = _target.forward;
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.forward, forward);
			base.DeltaRotation = new Vector2(quaternion.eulerAngles.x + 10f, quaternion.eulerAngles.y + 10f);
			_rotation = Quaternion.Euler(base.DeltaRotation.x, base.DeltaRotation.y, 0f);
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			_distance = Mathf.Lerp(_distance, base.TargetDistance, 3f * Time.unscaledDeltaTime);
			Quaternion b = Quaternion.Euler(base.DeltaRotation.x, base.DeltaRotation.y, 0f);
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
			base.CameraTransform.position = position - _rotation * Vector3.forward * (0f - _distance);
			base.CameraTransform.LookAt(position, -Physics.gravity);
		}
	}
}
