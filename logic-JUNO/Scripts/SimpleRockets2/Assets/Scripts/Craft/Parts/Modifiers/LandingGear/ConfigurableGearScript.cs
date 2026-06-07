using System.Collections.Generic;
using Assets.Scripts.CustomWheelCollider;
using ModApi.Craft;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class ConfigurableGearScript : MonoBehaviour
	{
		[SerializeField]
		private LandingGearAnimator _animator;

		[SerializeField]
		private Transform _attachPointWithBay;

		[SerializeField]
		private Transform _attachPointWithoutBay;

		[SerializeField]
		private Transform _backBrace;

		[SerializeField]
		private Transform _backOfBay;

		private ResizableWheelColliderNew _collider;

		[SerializeField]
		private Transform _forwardBrace;

		[SerializeField]
		private Transform _frontOfBay;

		private LandingGearTracks _gearTireTracks;

		[SerializeField]
		private Transform _landingGearRoot;

		private PartScript _partScript;

		[SerializeField]
		private Transform _supportBrace;

		private WheelStyleTransformDataScript _wheelStyleTransformDataScript;

		public Transform AttachPointWithBay
		{
			get
			{
				return _attachPointWithBay;
			}
			set
			{
				_attachPointWithBay = value;
			}
		}

		public Transform AttachPointWithoutBay
		{
			get
			{
				return _attachPointWithoutBay;
			}
			set
			{
				_attachPointWithoutBay = value;
			}
		}

		public Transform BackOfBay
		{
			get
			{
				return _backOfBay;
			}
			set
			{
				_backOfBay = value;
			}
		}

		public float Brake
		{
			get
			{
				return _collider.BrakeInput;
			}
			set
			{
				_collider.BrakeInput = value;
			}
		}

		public float BrakeTorque
		{
			get
			{
				return _collider.Data.BrakeTorque;
			}
			set
			{
				_collider.Data.BrakeTorque = value;
			}
		}

		public bool Extended => _animator.Extended;

		public float ExtendedPercent => _animator.ExtendedPercent;

		public float ForwardOffset
		{
			get
			{
				return _animator.ForwardOffset;
			}
			set
			{
				_animator.ForwardOffset = value;
			}
		}

		public Transform FrontOfBay
		{
			get
			{
				return _frontOfBay;
			}
			set
			{
				_frontOfBay = value;
			}
		}

		public float GearRatio
		{
			get
			{
				return _collider.Data.GearRatio;
			}
			set
			{
				_collider.Data.GearRatio = value;
			}
		}

		public bool Grounded => _collider.IsGrounded;

		public float HeightOffset
		{
			get
			{
				return _animator.HeightOffset;
			}
			set
			{
				_animator.HeightOffset = value;
			}
		}

		public Transform LandingGearRoot
		{
			get
			{
				return _landingGearRoot;
			}
			set
			{
				_landingGearRoot = value;
			}
		}

		public float LengthScale
		{
			get
			{
				return _animator.LengthScale;
			}
			set
			{
				_animator.LengthScale = value;
			}
		}

		public float MotorThrottle
		{
			get
			{
				return _collider.MotorThrottle;
			}
			set
			{
				_collider.MotorThrottle = value;
			}
		}

		public float MotorTorque
		{
			get
			{
				return _collider.Data.MaxTorqueAtMotorShaft;
			}
			set
			{
				_collider.Data.MaxTorqueAtMotorShaft = value;
			}
		}

		public float RetractionSpeedModifier
		{
			get
			{
				return _animator.RetractionSpeedModifier;
			}
			set
			{
				_animator.RetractionSpeedModifier = value;
			}
		}

		public float RPM => _collider.Rpm;

		public float OffroadPercentage => _collider.OffroadPercentage;

		public float Scale { get; set; }

		public bool ShowUpperBraces
		{
			get
			{
				return _forwardBrace.gameObject.activeSelf;
			}
			set
			{
				_forwardBrace.gameObject.SetActive(value);
				_backBrace.gameObject.SetActive(value);
			}
		}

		public float SideOffset
		{
			get
			{
				return _animator.SideOffset;
			}
			set
			{
				_animator.SideOffset = value;
			}
		}

		public float SlantAngle
		{
			get
			{
				return _animator.SlantAngle;
			}
			set
			{
				_animator.SlantAngle = value;
			}
		}

		public bool SupportArmEnabled
		{
			get
			{
				return _supportBrace.gameObject.activeSelf;
			}
			set
			{
				_supportBrace.gameObject.SetActive(value);
			}
		}

		public Transform SupportBrace => _supportBrace;

		public float SuspensionTravel
		{
			get
			{
				return _animator.SuspensionDistance;
			}
			set
			{
				_animator.SuspensionDistance = value;
			}
		}

		public float TractionForward => _collider.Data.TractionForward;

		public float TractionSideways => _collider.Data.TractionSideways;

		public float VerticalAngleOffset
		{
			get
			{
				return _animator.WheelVerticalAngleOffset;
			}
			set
			{
				_animator.WheelVerticalAngleOffset = value;
			}
		}

		public float WheelTurnAngle
		{
			get
			{
				return _collider.SteerAngle;
			}
			set
			{
				_collider.SteerAngle = value;
			}
		}

		public void OnCraftStructureChanged(ICraftScript craftScript)
		{
			if (_collider != null)
			{
				_collider.OnMassChanged();
				_collider.SetRigidBody(GetComponentInParent<Rigidbody>());
			}
		}

		public void OnGearRebuilt(WheelStyleTransformDataScript wheelStyleTransformDataScript)
		{
			_wheelStyleTransformDataScript = wheelStyleTransformDataScript;
			_animator?.OnGearRebuilt(wheelStyleTransformDataScript);
		}

		public void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			_gearTireTracks?.RecalculateFrameState(positionDelta, velocityDelta);
			_collider?.RecalculateFrameState(positionDelta, velocityDelta);
		}

		public void SetExtended(bool extended, bool snapToPosition)
		{
			if (Game.IsCareer && !Game.Instance.GameState.Validator.IsItemAvailable("LandingGear.Retraction"))
			{
				_animator.SetExtended(extended: true, snapToPosition: true);
			}
			else
			{
				_animator.SetExtended(extended, snapToPosition);
			}
		}

		public void SetLandingGearDoors(Transform parent, IReadOnlyCollection<Vector3> openRotations)
		{
			_animator?.SetLandingGearDoors(parent, openRotations);
		}

		public void SnapToExtensionPercent(float percent)
		{
			_animator.SnapToExtensionPercent(percent);
		}

		public void Update()
		{
			_gearTireTracks?.Update();
			CraftControls craftControls = _partScript.CommandPod?.Controls;
			if (_collider != null && craftControls != null)
			{
				_collider.EnableInternalFriction = craftControls.Throttle == 0f;
			}
		}

		internal void GenerateInspectorModel(PartInspectorModel model)
		{
			_collider.OnGenerateInspectorModel(model);
		}

		internal void Initialize(bool createWheelCollider, bool suspensionEnabled, float springForceScale, float damperScale, float forwardTractionScalar, float sidewaysTractionScalar, bool doubleWheel)
		{
			_partScript = GetComponentInParent<PartScript>();
			if (createWheelCollider)
			{
				ResizableWheelColliderNew resizableWheelColliderNew = _wheelStyleTransformDataScript.ColliderTransform.gameObject.AddComponent<ResizableWheelColliderNew>();
				resizableWheelColliderNew.Data.TractionForward = forwardTractionScalar;
				resizableWheelColliderNew.Data.TractionSideways = sidewaysTractionScalar;
				resizableWheelColliderNew.Data.Radius = 0.3f * Scale;
				resizableWheelColliderNew.Data.Width = 0.22f * Scale * (doubleWheel ? 2.5f : 1f);
				resizableWheelColliderNew.Data.SuspensionDistance = SuspensionTravel * Scale;
				resizableWheelColliderNew.Data.SuspensionEnabled = suspensionEnabled;
				resizableWheelColliderNew.Data.SpringForceScale = springForceScale;
				resizableWheelColliderNew.Data.DamperScale = damperScale;
				resizableWheelColliderNew.WheelSpinRoot = _wheelStyleTransformDataScript.WheelSpinRoot;
				resizableWheelColliderNew.WheelTurnRoot = _wheelStyleTransformDataScript.WheelTurnRoot;
				resizableWheelColliderNew.WheelSuspensionTravelRoot = _wheelStyleTransformDataScript.WheelSuspensionTravelRoot;
				resizableWheelColliderNew.Initialize(GetComponentInParent<Rigidbody>());
				_gearTireTracks = new LandingGearTracks(resizableWheelColliderNew, _partScript);
				_collider = resizableWheelColliderNew;
			}
			_animator.IncludeSuspensionDistanceInOffset = !Game.InFlightScene;
		}
	}
}
