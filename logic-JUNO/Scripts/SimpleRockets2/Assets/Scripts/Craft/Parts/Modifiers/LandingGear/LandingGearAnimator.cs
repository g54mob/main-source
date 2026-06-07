using System;
using System.Collections.Generic;
using ModApi;
using ModApi.Audio;
using ModApi.GameLoop;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class LandingGearAnimator : MonoBehaviourBase
	{
		[Serializable]
		private struct LandingGearDoor
		{
			public Vector3 OpenRotation;

			public Transform Transform;

			public LandingGearDoor(Vector3 openRotation, Transform transform)
			{
				OpenRotation = openRotation;
				Transform = transform;
			}
		}

		private const float LegRange = 0.9f;

		private const float LegStartingPercent = 0.1f;

		private bool _animating;

		private LoopingAudioScript _audio;

		private List<LandingGearDoor> _bayDoors = new List<LandingGearDoor>();

		[SerializeField]
		private Transform _baySuspension;

		private ControlRodLinkScript _controlRodScript;

		private Vector3 _defaultLocalPos;

		private Vector3 _extendedLocalPos;

		private float _forwardOffset;

		private float _heightOffset;

		private bool _includeSuspensionDistanceInOffset;

		private float _lengthScale;

		private int _phaseXEnd;

		private float _phaseXStart;

		private float _phaseYEnd;

		private float _phaseYStart;

		private float _phaseZEnd;

		private float _phaseZStart;

		private Vector3 _retractedLocalPos;

		[SerializeField]
		private Transform _retractedWheelPosition;

		private float _sideOffset;

		private float _slantAngle;

		[SerializeField]
		private Transform _suspensionBase;

		private float _suspensionDistance;

		private Transform _suspensionParent;

		private bool _updateShape;

		[SerializeField]
		private Transform _wheelBaseRotation;

		[SerializeField]
		private Transform _wheelPrefabBaySuspensionAttachPoint;

		private WheelStyleTransformDataScript _wheelStyleTransformDataScript;

		private float _wheelVerticalAngleOffset;

		public bool Extended { get; private set; } = true;

		public float ExtendedPercent { get; private set; } = 1f;

		public float ForwardOffset
		{
			get
			{
				return _forwardOffset;
			}
			set
			{
				_forwardOffset = value;
				_updateShape = true;
			}
		}

		public float HeightOffset
		{
			get
			{
				return _heightOffset;
			}
			set
			{
				_heightOffset = value;
				_updateShape = true;
			}
		}

		public bool IncludeSuspensionDistanceInOffset
		{
			get
			{
				return _includeSuspensionDistanceInOffset;
			}
			set
			{
				_includeSuspensionDistanceInOffset = value;
				_updateShape = true;
			}
		}

		public float LengthScale
		{
			get
			{
				return _lengthScale;
			}
			set
			{
				_lengthScale = value;
				_updateShape = true;
			}
		}

		public float RetractionSpeedModifier { get; set; } = 1f;

		public float SideOffset
		{
			get
			{
				return _sideOffset;
			}
			set
			{
				_sideOffset = value;
				_updateShape = true;
			}
		}

		public float SlantAngle
		{
			get
			{
				return _slantAngle;
			}
			set
			{
				_slantAngle = value;
				_updateShape = true;
			}
		}

		public float SuspensionDistance
		{
			get
			{
				return _suspensionDistance;
			}
			set
			{
				_suspensionDistance = value;
				_updateShape = true;
			}
		}

		public float WheelVerticalAngleOffset
		{
			get
			{
				return _wheelVerticalAngleOffset;
			}
			set
			{
				_wheelVerticalAngleOffset = value;
				_updateShape = true;
			}
		}

		public void OnGearRebuilt(WheelStyleTransformDataScript wheelStyleTransformDataScript)
		{
			_wheelStyleTransformDataScript = wheelStyleTransformDataScript;
			_defaultLocalPos = _wheelStyleTransformDataScript.WheelAssemblyRoot.localPosition;
			_suspensionParent = wheelStyleTransformDataScript.Suspension?.parent;
			OnExtendedPositionChanged();
		}

		public void SetExtended(bool extended, bool snapToPosition)
		{
			Extended = extended;
			if (snapToPosition)
			{
				if (!extended)
				{
					OnExtendedPositionChanged();
				}
				SnapToExtensionPercent(extended ? 1 : 0);
			}
		}

		public void SetLandingGearDoors(Transform parent, IReadOnlyCollection<Vector3> openRotations)
		{
			_bayDoors.Clear();
			if (!(parent != null) || openRotations == null)
			{
				return;
			}
			int num = 0;
			foreach (Vector3 openRotation in openRotations)
			{
				_bayDoors.Add(new LandingGearDoor(openRotation, parent.GetChild(num)));
				num++;
			}
			if (parent.childCount != openRotations.Count)
			{
				Debug.LogError($"Landing gear door parent contains {parent.childCount} children, but this door style only provides {openRotations.Count} open rotations. Doors may not function properly.");
			}
		}

		public void SnapToExtensionPercent(float percent)
		{
			ExtendedPercent = Mathf.Clamp01(percent);
			UpdateRetraction(ExtendedPercent);
		}

		public void Update()
		{
			if (_updateShape)
			{
				_updateShape = false;
				UpdateShapeFromDesignerProperties(_forwardOffset, _sideOffset, _heightOffset, _lengthScale, _slantAngle, _suspensionDistance, _wheelVerticalAngleOffset);
				UpdateRetraction(ExtendedPercent);
			}
			HandleRetracting();
			Transform transform = _wheelStyleTransformDataScript?.Suspension;
			if (transform != null)
			{
				Quaternion rotation = Quaternion.LookRotation((_suspensionBase.position - transform.position).normalized, transform.up);
				transform.rotation = rotation;
			}
			Transform transform2 = _wheelStyleTransformDataScript?.SuspensionAttachmentAPoint;
			if (transform2 != null)
			{
				Quaternion rotation2 = Quaternion.LookRotation((transform2.position - _baySuspension.position).normalized, Vector3.Cross(_controlRodScript.RodBottom.right, _baySuspension.forward));
				_baySuspension.rotation = rotation2;
				if (transform != null)
				{
					float z = (transform2.position - _wheelPrefabBaySuspensionAttachPoint.position).magnitude / _suspensionParent.lossyScale.z;
					transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
				}
			}
			_controlRodScript.UpdateControlRod();
		}

		private void Awake()
		{
			_controlRodScript = GetComponentInChildren<ControlRodLinkScript>();
			_audio = GetComponent<LoopingAudioScript>();
		}

		private Vector3 CalculateSuspensionTravelDir()
		{
			return Quaternion.AngleAxis(WheelVerticalAngleOffset, Vector3.up) * Vector3.forward;
		}

		private Vector3 CalculateWheelExtendedLocalPosition()
		{
			Vector3 result = new Vector3(_defaultLocalPos.x + _sideOffset, _defaultLocalPos.y + _forwardOffset, _defaultLocalPos.z + _heightOffset) * _lengthScale;
			if (_includeSuspensionDistanceInOffset)
			{
				result -= CalculateSuspensionTravelDir() * _suspensionDistance;
			}
			return result;
		}

		private Vector3 EulerLerp(Vector3 a, Vector3 b, float t)
		{
			return new Vector3(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t), Mathf.Lerp(a.z, b.z, t));
		}

		private void HandleRetracting()
		{
			float num = (float)(Extended ? 1 : (-1)) * Time.deltaTime / (4f / RetractionSpeedModifier);
			float extendedPercent = ExtendedPercent;
			bool flag = extendedPercent == 1f;
			bool flag2 = extendedPercent == 0f;
			ExtendedPercent = Mathf.Clamp01(ExtendedPercent + num);
			bool flag3 = ExtendedPercent == 1f;
			bool flag4 = ExtendedPercent == 0f;
			if (!flag3 && !flag4)
			{
				if ((flag && !flag3) || Game.InDesignerScene)
				{
					OnExtendedPositionChanged();
				}
				UpdateRetraction(ExtendedPercent);
			}
			else
			{
				bool flag5 = !flag && !flag2;
				if (flag5 && flag3)
				{
					UpdateShapeFromDesignerProperties(_forwardOffset, _sideOffset, _heightOffset, _lengthScale, _slantAngle, _suspensionDistance, _wheelVerticalAngleOffset);
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.LandingGearLocked, base.transform.position, userInterfaceSound: false);
				}
				else if (flag5 && flag4)
				{
					UpdateRetraction(0f);
					_wheelStyleTransformDataScript.WheelAssemblyRoot.localPosition = _retractedLocalPos;
					UpdateAngleOffsets(0f, 0f);
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.LandingGearLocked, base.transform.position, userInterfaceSound: false);
				}
			}
			bool flag6 = Utilities.Between(ExtendedPercent, 0f, 1f);
			flag6 = ExtendedPercent != 0f && ExtendedPercent != 1f;
			_audio.UpdateLoopAudio(flag6 ? 1 : 0);
			if (flag6)
			{
				_animating = true;
			}
			else if (_animating)
			{
				_animating = false;
				GetComponentInParent<PartScript>()?.CraftScript?.InitiateDragRecalculation();
			}
		}

		private void OnExtendedPositionChanged()
		{
			_extendedLocalPos = CalculateWheelExtendedLocalPosition();
			Vector3 vector = Vector3.zero;
			if (Game.InFlightScene)
			{
				vector = Vector3.forward * _suspensionDistance;
			}
			_retractedLocalPos = _wheelStyleTransformDataScript.WheelAssemblyRoot.parent.InverseTransformPoint(_retractedWheelPosition.position) + vector;
			float num = Mathf.Abs(_retractedLocalPos.x - _extendedLocalPos.x);
			float num2 = Mathf.Abs(_retractedLocalPos.y - _extendedLocalPos.y);
			float num3 = Mathf.Abs(_retractedLocalPos.z - _extendedLocalPos.z);
			float num4 = num + num2 + num3;
			_ = num / num4;
			float num5 = num2 / num4;
			float num6 = num3 / num4;
			_phaseZStart = 0.1f;
			_phaseZEnd = _phaseZStart + num6 * 0.9f;
			_phaseYStart = _phaseZEnd;
			_phaseYEnd = _phaseYStart + num5 * 0.9f;
			_phaseXStart = _phaseYEnd;
			_phaseXEnd = 1;
		}

		private void UpdateAngleOffsets(float slantAngle, float verticalOffset)
		{
			_wheelStyleTransformDataScript.WheelAssemblyRoot.rotation = _wheelBaseRotation.rotation;
			UpdateSlantAngle(slantAngle);
			_wheelStyleTransformDataScript.WheelAssemblyRoot.localEulerAngles += new Vector3(0f, verticalOffset, 0f);
		}

		private void UpdateOffsets(float forwardOffset, float sideOffset, float heightOffset, float lengthScale, float suspensionDistance, float wheelVerticalAngleOffset)
		{
			_wheelStyleTransformDataScript.WheelAssemblyRoot.localPosition = CalculateWheelExtendedLocalPosition();
		}

		private void UpdateRetraction(float extendedPercent)
		{
			float val = MathUtils.PercentBetween(extendedPercent - 0.1f, 0f, 0.9f);
			float t = MathUtils.PercentBetween(val, _phaseZStart, _phaseZEnd);
			float t2 = MathUtils.PercentBetween(val, _phaseYStart, _phaseYEnd);
			float t3 = MathUtils.PercentBetween(val, _phaseXStart, _phaseXEnd);
			Vector3 localPosition = new Vector3(Mathf.Lerp(_retractedLocalPos.x, _extendedLocalPos.x, t3), Mathf.Lerp(_retractedLocalPos.y, _extendedLocalPos.y, t2), Mathf.Lerp(_retractedLocalPos.z, _extendedLocalPos.z, t));
			_wheelStyleTransformDataScript.WheelAssemblyRoot.localPosition = localPosition;
			float t4 = MathUtils.PercentBetween(extendedPercent, 0f, 0.1f);
			foreach (LandingGearDoor bayDoor in _bayDoors)
			{
				if (bayDoor.Transform != null)
				{
					bayDoor.Transform.localRotation = Quaternion.Euler(EulerLerp(Vector3.zero, bayDoor.OpenRotation, t4));
				}
			}
			float num = MathUtils.PercentBetween(val, 0.4f, 0.6f);
			UpdateAngleOffsets(SlantAngle * num, WheelVerticalAngleOffset * num);
		}

		private void UpdateShapeFromDesignerProperties(float forwardOffset, float sideOffset, float heightOffset, float lengthScale, float slantAngle, float suspensionDistance, float wheelVerticalAngleOffset)
		{
			if (Game.InFlightScene || (Game.InDesignerScene && ExtendedPercent != 0f) || (!Game.InFlightScene && !Game.InDesignerScene))
			{
				UpdateOffsets(forwardOffset, sideOffset, heightOffset, lengthScale, suspensionDistance, wheelVerticalAngleOffset);
				UpdateAngleOffsets(slantAngle, WheelVerticalAngleOffset);
				OnExtendedPositionChanged();
			}
		}

		private void UpdateSlantAngle(float slantAngle)
		{
			Transform transform = _wheelStyleTransformDataScript?.SlantAngleRoot;
			if (transform != null)
			{
				transform.transform.localEulerAngles = new Vector3(slantAngle, 0f, 0f);
			}
		}
	}
}
