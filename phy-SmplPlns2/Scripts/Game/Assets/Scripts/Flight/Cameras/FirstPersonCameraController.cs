using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class FirstPersonCameraController : InteractiveCameraController
	{
		private bool _animatingRecenter;

		private bool _autoCenter;

		private CameraVantageScript _camera;

		private CockpitSoundScript _cockpitSound;

		private bool _isLookingBack;

		private bool _lookAtCockpit;

		private Vector3 _originalShadowCascades;

		private PartScript _targetPart;

		public override Vector3 AngularVelocity
		{
			get
			{
				if (_targetPart.Body.RigidBody != null)
				{
					return _targetPart.Body.RigidBody.angularVelocity;
				}
				return Vector3.zero;
			}
		}

		public bool IsCentered { get; private set; }

		public override float IsCockpitAudio
		{
			get
			{
				if (!(_cockpitSound == null))
				{
					return _cockpitSound.Intensity;
				}
				return 0f;
			}
		}

		public override bool IsFirstPerson => true;

		public override bool IsRecenterAvailable
		{
			get
			{
				if (!_autoCenter && !IsCentered)
				{
					return !_animatingRecenter;
				}
				return false;
			}
		}

		public override float PreferredClosestShadowDistance => 2f;

		public FirstPersonCameraController(CameraManagerScript cameraManager, CameraVantageScript camera, CockpitSoundScript cockpitSound)
			: base(cameraManager)
		{
			base.Name = "First Person";
			_autoCenter = camera.Data.AutoCenterCamera || camera.Data.LookAtCockpit;
			_targetPart = camera.PartScript;
			_camera = camera;
			_lookAtCockpit = camera.Data.LookAtCockpit;
			base.RequiresDopplerFix = false;
			base.RequiresPlaneCamera = true;
			base.AutoSwitchWhenBelowWater = true;
			base.CameraVantage = camera;
			_fovZoom = true;
			_cockpitSound = cockpitSound;
		}

		public override bool AllowGunReticle(Transform targetingTransform)
		{
			return true;
		}

		public override bool AllowMissileLocking(Transform targetingTransform)
		{
			return true;
		}

		public override void OnDeselected()
		{
			_targetPart.PartMaterialScript.Visible = true;
			_camera.IsSelected = false;
			IsCentered = false;
			QualitySettings.shadowCascade4Split = _originalShadowCascades;
		}

		public override void OnSelected()
		{
			_targetPart.PartMaterialScript.Visible = false;
			IsCentered = false;
			_camera.IsSelected = true;
			_originalShadowCascades = QualitySettings.shadowCascade4Split;
			QualitySettings.shadowCascade4Split = base.CameraManager.FirstPersonShadowCascades;
			base.CameraManager.SharedCameraDistance = 0f;
		}

		public override void OnXREnabled()
		{
			base.OnXREnabled();
			_deltaRotation = Vector2.zero;
		}

		public override void RecenterView()
		{
			_animatingRecenter = true;
			DOTween.To(() => _deltaRotation, delegate(Vector2 x)
			{
				_deltaRotation = x;
			}, Vector2.zero, 0.5f).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
			{
				_animatingRecenter = false;
			});
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			Quaternion quaternion = Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
			Transform transform = _targetPart.transform;
			Vector3 vector = Vector3.zero;
			if (_autoCenter || _lookAtCockpit)
			{
				float num = 0f;
				if (_deltaRotation.y > 90f)
				{
					num = Mathf.Clamp01((_deltaRotation.y - 90f) / 90f);
				}
				else if (_deltaRotation.y < -90f)
				{
					num = Mathf.Clamp((_deltaRotation.y + 90f) / 90f, -1f, 0f);
				}
				if (num != 0f)
				{
					Vector2 lookBackTranslation = _camera.Data.LookBackTranslation;
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
			base.CameraTransform.position = _camera.FirstPersonVantagePosition + vector;
			_camera.ViewPosition = _camera.transform.InverseTransformDirection(vector);
			_camera.ViewRotation = _deltaRotation;
			if (base.CameraManager.XRCameraManager.XrCamerasEnabled)
			{
				_camera.ViewPosition += base.CameraTransform.InverseTransformDirection(base.CameraManager.XRCameraManager.MainCamera.transform.position - base.CameraTransform.position);
				Vector3 eulerAngles = (quaternion * Quaternion.Inverse(base.CameraTransform.rotation) * base.CameraManager.XRCameraManager.MainCamera.transform.rotation).eulerAngles;
				while (eulerAngles.x > 180f)
				{
					eulerAngles.x -= 360f;
				}
				while (eulerAngles.y > 180f)
				{
					eulerAngles.y -= 360f;
				}
				while (eulerAngles.z > 180f)
				{
					eulerAngles.z -= 360f;
				}
				_camera.ViewRotation = eulerAngles;
			}
			if (_lookAtCockpit)
			{
				Vector3 worldUp = (_camera.Data.AutoOrient ? _camera.LocalOrientedCenterOfMassRigidBodies.transform.up : _camera.transform.up);
				base.CameraTransform.LookAt(_targetPart.Aircraft.MainCockpit.transform, worldUp);
				base.CameraTransform.rotation = base.CameraTransform.rotation * quaternion;
			}
			else
			{
				Quaternion quaternion2;
				if (_camera.Data.AutoOrient)
				{
					Vector3 upwards = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.OrientedCenterOfMassRigidBodies.up ?? Vector3.up;
					quaternion2 = Quaternion.LookRotation(_camera.transform.forward, upwards);
				}
				else
				{
					quaternion2 = _camera.transform.rotation;
				}
				base.CameraTransform.rotation = quaternion2 * quaternion;
			}
			bool flag = base.CameraLookLeftRightAxis == 0f && base.CameraLookUpDownAxis == 0f;
			if (!_touching && _autoCenter && flag && !_animatingRecenter)
			{
				Vector2 vector2 = _deltaRotation * (5f * Time.unscaledDeltaTime);
				_deltaRotation -= vector2;
				if (_deltaRotation.magnitude < 1f)
				{
					_deltaRotation = default(Vector2);
				}
			}
			IsCentered = _deltaRotation.sqrMagnitude < 5f;
			if (!_targetPart.Body.gameObject.activeSelf)
			{
				base.IsActive = false;
			}
			base.CameraManager.CameraFocalPosition.position = base.CameraTransform.position;
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
				return !_lookAtCockpit;
			}
			return false;
		}

		protected override Vector2 InputRotationMultiplier()
		{
			if (_autoCenter || _lookAtCockpit)
			{
				return new Vector2(-90f, _isLookingBack ? 180f : 90f);
			}
			return new Vector2(-360f, 360f) * Time.unscaledDeltaTime;
		}
	}
}
