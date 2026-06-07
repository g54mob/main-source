using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public class FirstPersonCameraController : InteractiveCameraController
	{
		private bool _autoCenter;

		private IPartScript _cameraPart;

		private EvaScript _eva;

		private bool _fovZoomEnabled;

		private bool _isLookingBack;

		private Transform _parentTransform;

		private Transform _target;

		private float _zoomPercent;

		public override bool AllowDefault => false;

		public override bool AllowPartSelection => !base.ViewIsFocused;

		public override Vector3 AngularVelocity
		{
			get
			{
				if (_cameraPart.BodyScript.RigidBody != null)
				{
					return _cameraPart.BodyScript.RigidBody.angularVelocity;
				}
				return Vector3.zero;
			}
		}

		public CameraVantageScript CameraVantageScript { get; private set; }

		public bool DisablePartMaterial { get; set; } = true;

		public float? EyeballOffset { get; set; }

		public bool FovZoomEnabled
		{
			get
			{
				return _fovZoomEnabled;
			}
			set
			{
				_fovZoomEnabled = value;
				if (!_fovZoomEnabled)
				{
					AdjustFovZoom(100f);
				}
			}
		}

		public Vector3 HeadUpVec { get; set; }

		public override string Type => "FPS";

		public override bool VaporTrailsVisible
		{
			get
			{
				if (!(_eva == null))
				{
					return _eva.EvaActive;
				}
				return true;
			}
		}

		internal FirstPersonCameraController(CameraManagerScript cameraManager, CameraVantageScript camera)
			: base(cameraManager)
		{
			SetVantageScript(camera);
			Initialize();
		}

		internal FirstPersonCameraController(CameraManagerScript cameraManager)
			: base(cameraManager)
		{
			Initialize();
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
			if (DisablePartMaterial)
			{
				_cameraPart.PartMaterialScript.IsVisible = true;
			}
			base.GameView.GameCamera.FieldOfView = base.GameView.GameCamera.FieldOfViewDefault;
			_eva = null;
		}

		public override bool OnPinch(PinchEventData eventData)
		{
			if (_fovZoomEnabled)
			{
				float num = eventData.DistanceDelta / Game.Instance.Device.Dpi;
				float zoomPercentage = 1f + -0.5f * num;
				AdjustFovZoom(zoomPercentage);
			}
			return true;
		}

		public override void OnSelected(int subMode)
		{
			base.OnSelected(subMode);
			if (DisablePartMaterial)
			{
				_cameraPart.PartMaterialScript.IsVisible = false;
			}
			if (CameraVantageScript.Data.VariableZoom)
			{
				base.GameView.GameCamera.FieldOfView = CameraVantageScript.CurrentFieldOfView;
			}
			else
			{
				base.GameView.GameCamera.FieldOfView = CameraVantageScript.Data.FieldOfView;
			}
			_eva = _cameraPart?.GetModifier<EvaScript>();
			base.CameraManager.SharedCameraDistance = 0f;
		}

		public void SetVantageScript(CameraVantageScript cameraVantage)
		{
			SetEnabled(cameraVantage.Data.EnabledByDefault, notifyCameraManager: false);
			base.MouseLook = cameraVantage.MouseLook;
			_parentTransform = base.CameraTransform.parent;
			_autoCenter = cameraVantage.AutoCenterCamera || cameraVantage.LookAtCommandPod;
			_cameraPart = cameraVantage.PartScript;
			if (cameraVantage.LookAtCommandPod)
			{
				_target = _cameraPart.CraftScript.ActiveCommandPod.Part.PartScript.Transform;
			}
			CameraVantageScript = cameraVantage;
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			UpdateCameraPosition();
			Quaternion quaternion = Quaternion.Euler(base.DeltaRotation.x, base.DeltaRotation.y, 0f);
			if (_target != null)
			{
				Vector3 worldUp = (CameraVantageScript.AutoOrient ? CameraVantageScript.PartScript.CommandPod.PilotSeatOrientation.transform.up : CameraVantageScript.transform.up);
				base.CameraTransform.LookAt(_target, worldUp);
				base.CameraTransform.rotation = base.CameraTransform.rotation * quaternion;
			}
			else
			{
				Quaternion quaternion2 = ((!CameraVantageScript.AutoOrient) ? CameraVantageScript.CameraPosition.transform.rotation : Quaternion.LookRotation(CameraVantageScript.CameraPosition.transform.forward, Game.Instance.FlightScene.CraftNode.CraftScript.ActiveCommandPod.PilotSeatOrientation.up));
				base.CameraTransform.rotation = quaternion2 * quaternion;
			}
			if (!base.MouseLook)
			{
				bool flag = base.CameraLookLeftRightAxis == 0f && base.CameraLookUpDownAxis == 0f;
				if (!base.Touching && _autoCenter && flag)
				{
					Vector2 vector = base.DeltaRotation * 5f * Time.unscaledDeltaTime;
					base.DeltaRotation -= vector;
					if (base.DeltaRotation.magnitude < 1f)
					{
						base.DeltaRotation = Vector2.zero;
					}
				}
			}
			if (CameraVantageScript.Data.VariableZoom)
			{
				base.GameView.GameCamera.FieldOfView = CameraVantageScript.CurrentFieldOfView;
			}
		}

		public override void Zoom(float zoomPercentage)
		{
			if (_fovZoomEnabled)
			{
				AdjustFovZoom(zoomPercentage);
			}
		}

		protected override float GetCameraLookLeftRightAxis(float lookLeftRightAxis, float lookBackAxis)
		{
			_isLookingBack = lookBackAxis != 0f;
			if (!_isLookingBack)
			{
				return lookLeftRightAxis;
			}
			return lookBackAxis;
		}

		protected override bool InputRotationIsAdditives()
		{
			if (!_autoCenter)
			{
				return _target == null;
			}
			return false;
		}

		protected override Vector2 InputRotationMultiplier()
		{
			if (_autoCenter || _target != null)
			{
				return new Vector2(-90f, _isLookingBack ? 180f : 90f);
			}
			return new Vector2(-360f, 360f) * Time.unscaledDeltaTime;
		}

		protected override void OnCameraBelowTerrain(Vector3 suggestedCameraFramePos, double distanceRaised)
		{
			if ((_parentTransform.position - suggestedCameraFramePos).magnitude < 100f)
			{
				base.CameraTransform.localPosition = Vector3.zero;
				_parentTransform.position = suggestedCameraFramePos;
			}
			else
			{
				base.CameraManager.UnRegisterCustomCameraVantage(CameraVantageScript);
			}
		}

		private void AdjustFovZoom(float zoomPercentage)
		{
			float num = Mathf.Clamp(zoomPercentage * base.CameraManager.FieldOfView, 15f, CameraVantageScript.Data.FieldOfView);
			base.CameraManager.FieldOfView = num;
			_zoomPercent = Mathf.InverseLerp(CameraVantageScript.Data.FieldOfView, 15f, num);
			base.PanSensitivity = Mathf.Lerp(1f, 0.1f, _zoomPercent);
		}

		private void Initialize()
		{
			base.RequiresPlaneCamera = true;
			base.AutoSwitchWhenBelowWater = true;
		}

		private void UpdateCameraPosition()
		{
			Transform transform = _cameraPart.Transform;
			Vector3 vector = Vector3.zero;
			if (_autoCenter || _target != null)
			{
				float num = 0f;
				if (base.DeltaRotation.y > 90f)
				{
					num = Mathf.Clamp01((base.DeltaRotation.y - 90f) / 90f);
				}
				else if (base.DeltaRotation.y < -90f)
				{
					num = Mathf.Clamp((base.DeltaRotation.y + 90f) / 90f, -1f, 0f);
				}
				if (num != 0f)
				{
					Vector2 lookBackTranslation = CameraVantageScript.CameraVantage.LookBackTranslation;
					if (lookBackTranslation.x != 0f)
					{
						vector = transform.right * (num * lookBackTranslation.x);
					}
					if (lookBackTranslation.y != 0f)
					{
						vector += transform.up * (Mathf.Abs(num) * lookBackTranslation.y);
					}
				}
			}
			base.CameraTransform.localPosition = Vector3.zero;
			_parentTransform.position = CameraVantageScript.FirstPersonVantagePosition + vector;
			if (EyeballOffset.HasValue)
			{
				base.CameraTransform.position += Vector3.ProjectOnPlane(base.CameraTransform.forward, HeadUpVec).normalized * EyeballOffset.Value;
			}
			base.PlanetPosition = base.GameView.ReferenceFrame.FrameToPlanetPosition(base.CameraTransform.position);
		}
	}
}
