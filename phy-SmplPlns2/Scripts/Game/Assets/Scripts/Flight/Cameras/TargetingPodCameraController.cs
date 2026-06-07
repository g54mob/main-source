using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class TargetingPodCameraController : CameraController
	{
		private CameraVantageScript _camera;

		private Vector3 _originalShadowCascades;

		private bool _pinching;

		private TargetingPodScript _targetingPod;

		private PartScript _targetPart;

		public override bool IsRecenterAvailable => false;

		public bool IsTargetingPodActive => _targetingPod?.IsActive ?? false;

		public TargetingPodCameraController(CameraManagerScript cameraManager, CameraVantageScript camera)
			: base(cameraManager)
		{
			base.Name = "Targeting Pod";
			_targetPart = camera.PartScript;
			_camera = camera;
			base.RequiresPlaneCamera = true;
			base.CameraVantage = camera;
		}

		public override void HandleInput(InputEvent e)
		{
			if (!_pinching && e.InputButton == InputButton.Primary)
			{
				Vector2 vector = -e.DeltaPosition / Game.Instance.Device.Dpi * 0.25f * _targetingPod.Fov;
				vector.y *= -1f;
				_targetingPod.Slew(-vector);
			}
		}

		public override void HandlePinch(PinchEvent e)
		{
			if (e.InputState != InputState.End)
			{
				_pinching = true;
				float num = e.DistanceDelta / Game.Instance.Device.Dpi;
				Zoom(num * 0.1f);
			}
			else
			{
				_pinching = false;
			}
		}

		public override void LateUpdate()
		{
			base.LateUpdate();
			base.CameraTransform.SetPositionAndRotation(_targetingPod.transform.position, _targetingPod.transform.rotation);
			base.CameraManager.SetCameraFov(_targetingPod.Fov);
			if (!_targetPart.Body.gameObject.activeSelf)
			{
				base.IsActive = false;
			}
			base.CameraManager.CameraFocalPosition.position = base.CameraTransform.position;
		}

		public override void OnDeselected()
		{
			_targetPart.PartMaterialScript.Visible = true;
			_camera.IsSelected = false;
			QualitySettings.shadowCascade4Split = _originalShadowCascades;
			base.CameraManager.EnableTargetingPodEffect(enable: false);
			FlightSceneScript.Instance.FlightUI.OnTargetingPodCameraModeChanged(null);
		}

		public override void OnSelected()
		{
			if (_targetingPod == null)
			{
				_targetingPod = _targetPart.GetComponentInChildren<TargetingPodScript>();
				_camera.Data.Offset = _targetingPod.Data.CameraOffset;
			}
			_targetPart.PartMaterialScript.Visible = false;
			_camera.IsSelected = true;
			_originalShadowCascades = QualitySettings.shadowCascade4Split;
			QualitySettings.shadowCascade4Split = base.CameraManager.FirstPersonShadowCascades;
			base.CameraManager.SharedCameraDistance = 0f;
			base.CameraManager.EnableTargetingPodEffect(enable: true);
			FlightSceneScript.Instance.FlightUI.OnTargetingPodCameraModeChanged(this);
		}

		public override void Update(int frameCount)
		{
			if (GameInputs.Instance.MouseWheelAlwaysZooms)
			{
				float y = UnityEngine.Input.mouseScrollDelta.y;
				if (y != 0f)
				{
					Zoom((y > 0f) ? 0.025f : (-0.025f));
				}
			}
		}

		private void Zoom(float amount)
		{
			_targetingPod.Zoom += amount;
		}
	}
}
