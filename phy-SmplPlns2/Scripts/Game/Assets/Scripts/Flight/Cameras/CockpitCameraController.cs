using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class CockpitCameraController : InteractiveCameraController
	{
		public const string CockpitCameraName = "Cockpit View";

		private CockpitData _cockpit;

		private bool _isLookingBack;

		private Vector3 _originalShadowCascades;

		private PartScript _targetPart;

		public static bool SelectedAndCentered { get; private set; }

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

		public CockpitData Cockpit => _cockpit;

		public CockpitCameraController(CameraManagerScript cameraManager, PartScript target)
			: base(cameraManager)
		{
			base.Name = "Cockpit View";
			_targetPart = target;
			_cockpit = target.GetModifier<CockpitScript>()?.Cockpit;
			base.RequiresPlaneCamera = true;
			base.AutoSwitchWhenBelowWater = true;
			_fovZoom = true;
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
			QualitySettings.shadowCascade4Split = _originalShadowCascades;
			SelectedAndCentered = false;
		}

		public override void OnSelected()
		{
			_targetPart.PartMaterialScript.Visible = false;
			_originalShadowCascades = QualitySettings.shadowCascade4Split;
			QualitySettings.shadowCascade4Split = base.CameraManager.FirstPersonShadowCascades;
			base.CameraManager.SharedCameraDistance = 0f;
			SelectedAndCentered = false;
		}

		public override void OnXREnabled()
		{
			base.OnXREnabled();
			_deltaRotation = Vector2.zero;
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			Quaternion quaternion = Quaternion.Euler(_deltaRotation.x, _deltaRotation.y, 0f);
			Transform transform = _targetPart.transform;
			float num = 0f;
			if (_deltaRotation.y > 90f)
			{
				num = Mathf.Clamp01((_deltaRotation.y - 90f) / 90f);
			}
			else if (_deltaRotation.y < -90f)
			{
				num = Mathf.Clamp((_deltaRotation.y + 90f) / 90f, -1f, 0f);
			}
			Vector3 vector = Vector3.zero;
			if (num != 0f)
			{
				Vector2 vector2 = ((_cockpit != null) ? _cockpit.LookBackTranslation : new Vector2(0.3f, 0f));
				if (vector2.x != 0f)
				{
					vector = transform.right * (num * vector2.x);
				}
				if (vector2.y != 0f)
				{
					vector += transform.up * (Mathf.Abs(num) * vector2.y);
				}
			}
			base.CameraTransform.SetPositionAndRotation(transform.position + vector, transform.rotation * quaternion);
			bool flag = base.CameraLookLeftRightAxis == 0f && base.CameraLookUpDownAxis == 0f;
			if (!_touching && flag)
			{
				Vector2 vector3 = _deltaRotation * (5f * Time.unscaledDeltaTime);
				_deltaRotation -= vector3;
				if (_deltaRotation.magnitude < 1f)
				{
					_deltaRotation = default(Vector2);
				}
			}
			if (_deltaRotation.sqrMagnitude < 5f)
			{
				SelectedAndCentered = true;
			}
			else
			{
				SelectedAndCentered = false;
			}
			base.CameraManager.CameraFocalPosition.position = _targetPart.transform.position;
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
			return false;
		}

		protected override Vector2 InputRotationMultiplier()
		{
			return new Vector2(-90f, _isLookingBack ? 180f : 90f);
		}
	}
}
