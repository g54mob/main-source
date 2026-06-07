using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class FirstPersonCharacterCameraController : InteractiveCameraController
	{
		private bool _animatingRecenter;

		private bool _centerOnRigidBody;

		private bool _cockpitMode;

		private CockpitSoundScript _cockpitSound;

		private Vector2 _currentRotation = Vector2.zero;

		private float _prevAngularDecay;

		private int _prevFrameCount;

		private float _prevRoll;

		private float _prevTime;

		private float _prevValidRoll;

		private float _prevValidTime;

		private bool _selectedAndCentered;

		private float _smoothAngularDecay;

		private Func<IRigidBody> _targetBody;

		private Func<Transform> _targetTransform;

		public float ChickenHeadSensitivity { get; set; } = 50f;

		public bool IsCentered { get; private set; }

		public override float IsCockpitAudio
		{
			get
			{
				if (!_cockpitMode)
				{
					return 0f;
				}
				return _cockpitSound.Intensity;
			}
		}

		public bool IsCockpitMode => _cockpitMode;

		public override bool IsFirstPerson => true;

		public override bool IsRecenterAvailable
		{
			get
			{
				if (!IsCentered)
				{
					return !_animatingRecenter;
				}
				return false;
			}
		}

		public override float PreferredClosestShadowDistance => 2f;

		protected override float InitialFov => _settings.FieldOfViewCharacterFPV;

		protected override float MaximumFov => _settings.FieldOfViewCharacterFPV;

		protected override float MinimumFov => (float)_settings.FieldOfViewCharacterFPV * 0.25f;

		protected override bool SupportsMovementInXR => true;

		public FirstPersonCharacterCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, PartScript targetPart)
			: base(cameraManager)
		{
			Initialize(cameraManager, centerOnRigidBody, () => targetPart.transform, () => targetPart.Body.RigidBody);
		}

		public FirstPersonCharacterCameraController(CameraManagerScript cameraManager, bool centerOnRigidBody, Func<Transform> transform, Func<IRigidBody> body, bool cockpitMode = false, CockpitSoundScript cockpitSound = null)
			: base(cameraManager)
		{
			Initialize(cameraManager, centerOnRigidBody, transform, body, cockpitMode, cockpitSound);
		}

		public override void AddYaw(float yaw)
		{
			_currentRotation += new Vector2(0f, yaw);
			_deltaRotation = _currentRotation;
		}

		public override bool AllowGunReticle(Transform targetingTransform)
		{
			return true;
		}

		public override bool AllowMissileLocking(Transform targetingTransform)
		{
			return true;
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
			IsCentered = true;
			if (_cockpitMode)
			{
				UpdateAsCockpit(frameCount);
				return;
			}
			Transform transform = _targetTransform() ?? base.CameraManager.CameraFocalPosition;
			float num = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.025f);
			if (!PauseManager.Paused)
			{
				_targetPositionOffset *= 1f - 3f * num;
				_cameraRotationOffset *= 1f - 3f * num;
			}
			base.CameraManager.SharedCameraDistance = Mathf.Lerp(base.CameraManager.SharedCameraDistance, _targetDistance, 3f * num);
			float num2 = 3f;
			if (base.MouseLook)
			{
				num2 = 15f;
			}
			_currentRotation = Vector2.Lerp(_currentRotation, _deltaRotation, num2 * num);
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
			base.CameraTransform.SetPositionAndRotation(position, base.CameraManager.SharedCameraRotation);
			base.CameraManager.CameraFocalPosition.position = position + transform.forward;
		}

		public void UpdateAsCockpit(int frameCount)
		{
			if (_prevFrameCount >= frameCount)
			{
				_smoothAngularDecay = _prevAngularDecay;
				_prevValidRoll = _prevRoll;
				_prevValidTime = _prevTime;
			}
			Transform transform = _targetTransform();
			if (transform == null)
			{
				transform = base.CameraManager.CameraFocalPosition;
			}
			float num = Mathf.Max(0f, _settings.CharacterFPVChickenHead);
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles.x = ((eulerAngles.x > 180f) ? (eulerAngles.x - 360f) : eulerAngles.x);
			eulerAngles.z = ((eulerAngles.z > 180f) ? (eulerAngles.z - 360f) : eulerAngles.z);
			float num2 = Mathf.Clamp01(Mathf.Abs(eulerAngles.z / Mathf.Lerp(120f, 60f, num * num * 0.0001f)));
			num2 *= num2 * (3f - 2f * num2);
			num2 -= 1f;
			num2 *= Mathf.Clamp01(2f - 2f * num / 100f);
			if (Time.time > _prevValidTime)
			{
				float num3 = Time.time - _prevValidTime;
				float num4 = Mathf.Abs(eulerAngles.z - _prevValidRoll) / num3;
				_prevAngularDecay = Mathf.Lerp(_smoothAngularDecay, 1f - Mathf.Clamp01((num4 - 20f / num) / (101f - num)), 0.02f * (num + 1f) * num3);
			}
			float num5 = 1f - Mathf.Clamp01(Mathf.Abs(eulerAngles.x / 45f));
			Quaternion quaternion = Quaternion.Euler(0f, 0f, num2 * _prevAngularDecay * num5 * eulerAngles.z);
			Quaternion quaternion2 = Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
			base.CameraTransform.SetPositionAndRotation(transform.position, transform.rotation * quaternion2 * quaternion);
			base.CameraManager.CameraFocalPosition.position = transform.position;
			_prevRoll = transform.rotation.eulerAngles.z;
			_prevRoll = ((_prevRoll > 180f) ? (_prevRoll - 360f) : _prevRoll);
			IsCentered = _deltaRotation.sqrMagnitude < 5f;
			_selectedAndCentered = _deltaRotation.sqrMagnitude < 5f;
			_prevFrameCount = frameCount;
			_prevTime = Time.time;
		}

		private void Initialize(CameraManagerScript cameraManager, bool centerOnRigidBody, Func<Transform> transform, Func<IRigidBody> body, bool cockpitMode = false, CockpitSoundScript cockpitSound = null)
		{
			base.Name = "First Person View";
			_targetTransform = transform;
			_targetBody = body;
			_centerOnRigidBody = centerOnRigidBody;
			_targetDistance = 15f;
			_cockpitMode = cockpitMode;
			_cockpitSound = cockpitSound;
			_deltaRotation = (_cockpitMode ? Vector3.zero : new Vector3(15f, 0f, 0f));
			_fovZoom = true;
			base.RequiresDopplerFix = false;
			base.RequiresPlaneCamera = true;
		}
	}
}
