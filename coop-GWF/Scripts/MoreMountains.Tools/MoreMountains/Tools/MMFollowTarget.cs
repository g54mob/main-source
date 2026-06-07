using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Movement/MMFollowTarget")]
	public class MMFollowTarget : MonoBehaviour
	{
		public enum UpdateModes
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		public enum FollowModes
		{
			RegularLerp = 0,
			MMLerp = 1,
			MMSpring = 2
		}

		public enum PositionSpaces
		{
			World = 0,
			Local = 1
		}

		[Header("Follow Position")]
		public bool FollowPosition = true;

		[MMCondition("FollowPosition", true)]
		public bool FollowPositionX = true;

		[MMCondition("FollowPosition", true)]
		public bool FollowPositionY = true;

		[MMCondition("FollowPosition", true)]
		public bool FollowPositionZ = true;

		[MMCondition("FollowPosition", true)]
		public PositionSpaces PositionSpace;

		[Header("Follow Rotation")]
		public bool FollowRotation = true;

		[Header("Follow Scale")]
		public bool FollowScale = true;

		[MMCondition("FollowScale", true)]
		public float FollowScaleFactor = 1f;

		[Header("Target")]
		public Transform Target;

		[MMCondition("FollowPosition", true)]
		public Vector3 Offset;

		[MMCondition("FollowPosition", true)]
		public bool AddInitialDistanceXToXOffset;

		[MMCondition("FollowPosition", true)]
		public bool AddInitialDistanceYToYOffset;

		[MMCondition("FollowPosition", true)]
		public bool AddInitialDistanceZToZOffset;

		[Header("Position Interpolation")]
		public bool InterpolatePosition = true;

		[MMCondition("InterpolatePosition", true)]
		public FollowModes FollowPositionMode = FollowModes.MMLerp;

		[MMCondition("InterpolatePosition", true)]
		public float FollowPositionSpeed = 10f;

		[MMEnumCondition("FollowPositionMode", new int[] { 2 })]
		[Range(0.01f, 1f)]
		public float PositionSpringDamping = 0.3f;

		[MMEnumCondition("FollowPositionMode", new int[] { 2 })]
		public float PositionSpringFrequency = 3f;

		[Header("Rotation Interpolation")]
		public bool InterpolateRotation = true;

		[MMCondition("InterpolateRotation", true)]
		public FollowModes FollowRotationMode = FollowModes.MMLerp;

		[MMCondition("InterpolateRotation", true)]
		public float FollowRotationSpeed = 10f;

		[MMEnumCondition("FollowRotationMode", new int[] { 2 })]
		[Range(0.01f, 1f)]
		public float RotationSpringDamping = 0.3f;

		[MMEnumCondition("FollowRotationMode", new int[] { 2 })]
		public float RotationSpringFrequency = 3f;

		[Header("Scale Interpolation")]
		public bool InterpolateScale = true;

		[MMCondition("InterpolateScale", true)]
		public FollowModes FollowScaleMode = FollowModes.MMLerp;

		[MMCondition("InterpolateScale", true)]
		public float FollowScaleSpeed = 10f;

		[MMEnumCondition("FollowScaleMode", new int[] { 2 })]
		[Range(0.01f, 1f)]
		public float ScaleSpringDamping = 0.3f;

		[MMEnumCondition("FollowScaleMode", new int[] { 2 })]
		public float ScaleSpringFrequency = 3f;

		[Header("Mode")]
		public UpdateModes UpdateMode;

		public bool DisableSelfOnSetActiveFalse;

		[Header("Distances")]
		public bool UseMinimumDistanceBeforeFollow;

		public float MinimumDistanceBeforeFollow = 1f;

		public bool UseMaximumDistance;

		public float MaximumDistance = 1f;

		[Header("Anchor")]
		public bool AnchorToInitialPosition;

		[MMCondition("AnchorToInitialPosition", true)]
		public float MaxDistanceToAnchor = 1f;

		protected Vector3 _positionVelocity = Vector3.zero;

		protected Vector3 _scaleVelocity = Vector3.zero;

		protected Vector3 _rotationVelocity = Vector3.zero;

		protected Vector3 _initialPosition;

		protected Vector3 _direction;

		protected Vector3 _newPosition;

		protected Vector3 _newRotation;

		protected Vector3 _newScale;

		protected Vector3 _newTargetPosition;

		protected Quaternion _newTargetRotation;

		protected Vector3 _newTargetRotationEulerAngles;

		protected Vector3 _newTargetRotationEulerAnglesLastFrame;

		protected Vector3 _newTargetScale;

		protected float _rotationFloatVelocity;

		protected float _rotationFloatCurrent;

		protected float _rotationFloatTarget;

		protected Vector3 _currentRotationEulerAngles;

		protected Quaternion _rotationBeforeSpring;

		protected Quaternion _initialRotation;

		protected Vector3 _lastTargetPosition;

		protected bool _localSpace => PositionSpace == PositionSpaces.Local;

		protected virtual void Start()
		{
			Initialization();
		}

		public virtual void Initialization()
		{
			SetInitialPosition();
			SetOffset();
		}

		public virtual void StopFollowing()
		{
			FollowPosition = false;
		}

		public virtual void StartFollowing()
		{
			FollowPosition = true;
			SetInitialPosition();
		}

		protected virtual void SetInitialPosition()
		{
			_initialPosition = (_localSpace ? base.transform.localPosition : base.transform.position);
			_initialRotation = base.transform.rotation;
			_lastTargetPosition = (_localSpace ? base.transform.localPosition : base.transform.position);
		}

		protected virtual void SetOffset()
		{
			if (!(Target == null))
			{
				Vector3 vector = base.transform.position - Target.transform.position;
				Offset.x = (AddInitialDistanceXToXOffset ? vector.x : Offset.x);
				Offset.y = (AddInitialDistanceYToYOffset ? vector.y : Offset.y);
				Offset.z = (AddInitialDistanceZToZOffset ? vector.z : Offset.z);
			}
		}

		protected virtual void Update()
		{
			if (!(Target == null) && UpdateMode == UpdateModes.Update)
			{
				FollowTargetRotation();
				FollowTargetScale();
				FollowTargetPosition();
			}
		}

		protected virtual void FixedUpdate()
		{
			if (UpdateMode == UpdateModes.FixedUpdate)
			{
				FollowTargetRotation();
				FollowTargetScale();
				FollowTargetPosition();
			}
		}

		protected virtual void LateUpdate()
		{
			if (UpdateMode == UpdateModes.LateUpdate)
			{
				FollowTargetRotation();
				FollowTargetScale();
				FollowTargetPosition();
			}
		}

		protected virtual void FollowTargetPosition()
		{
			if (Target == null || !FollowPosition)
			{
				return;
			}
			_newTargetPosition = Target.position + Offset;
			if (!FollowPositionX)
			{
				_newTargetPosition.x = _initialPosition.x;
			}
			if (!FollowPositionY)
			{
				_newTargetPosition.y = _initialPosition.y;
			}
			if (!FollowPositionZ)
			{
				_newTargetPosition.z = _initialPosition.z;
			}
			float num = 0f;
			_direction = (_newTargetPosition - base.transform.position).normalized;
			num = Vector3.Distance(base.transform.position, _newTargetPosition);
			float interpolatedDistance = num;
			if (InterpolatePosition)
			{
				switch (FollowPositionMode)
				{
				case FollowModes.MMLerp:
					interpolatedDistance = MMMaths.Lerp(0f, num, FollowPositionSpeed, Time.deltaTime);
					interpolatedDistance = ApplyMinMaxDistancing(num, interpolatedDistance);
					base.transform.Translate(_direction * interpolatedDistance, Space.World);
					break;
				case FollowModes.RegularLerp:
					interpolatedDistance = Mathf.Lerp(0f, num, Time.deltaTime * FollowPositionSpeed);
					interpolatedDistance = ApplyMinMaxDistancing(num, interpolatedDistance);
					base.transform.Translate(_direction * interpolatedDistance, Space.World);
					break;
				case FollowModes.MMSpring:
					_newPosition = base.transform.position;
					MMMaths.Spring(ref _newPosition, _newTargetPosition, ref _positionVelocity, PositionSpringDamping, PositionSpringFrequency, Time.deltaTime);
					if (_localSpace)
					{
						base.transform.localPosition = _newPosition;
					}
					else
					{
						base.transform.position = _newPosition;
					}
					break;
				}
			}
			else
			{
				interpolatedDistance = ApplyMinMaxDistancing(num, interpolatedDistance);
				base.transform.Translate(_direction * interpolatedDistance, Space.World);
			}
			if (AnchorToInitialPosition && Vector3.Distance(base.transform.position, _initialPosition) > MaxDistanceToAnchor)
			{
				if (_localSpace)
				{
					base.transform.localPosition = _initialPosition + Vector3.ClampMagnitude(base.transform.localPosition - _initialPosition, MaxDistanceToAnchor);
				}
				else
				{
					base.transform.position = _initialPosition + Vector3.ClampMagnitude(base.transform.position - _initialPosition, MaxDistanceToAnchor);
				}
			}
		}

		protected virtual float ApplyMinMaxDistancing(float trueDistance, float interpolatedDistance)
		{
			if (UseMinimumDistanceBeforeFollow && trueDistance - interpolatedDistance < MinimumDistanceBeforeFollow)
			{
				interpolatedDistance = 0f;
			}
			if (UseMaximumDistance && trueDistance - interpolatedDistance >= MaximumDistance)
			{
				interpolatedDistance = trueDistance - MaximumDistance;
			}
			return interpolatedDistance;
		}

		protected virtual void FollowTargetRotation()
		{
			if (Target == null || !FollowRotation)
			{
				return;
			}
			_newTargetRotation = Target.rotation;
			_newTargetRotationEulerAngles = Target.rotation.eulerAngles;
			_currentRotationEulerAngles = base.transform.rotation.eulerAngles;
			if (FollowRotationMode == FollowModes.MMSpring && _newTargetRotationEulerAnglesLastFrame != _newTargetRotationEulerAngles)
			{
				_rotationBeforeSpring = base.transform.rotation;
				_rotationFloatCurrent = 0f;
				_rotationFloatTarget = Mathf.Abs(_newTargetRotation.eulerAngles.x) + Mathf.Abs(_newTargetRotation.eulerAngles.y) + Mathf.Abs(_newTargetRotation.z) - (Mathf.Abs(_currentRotationEulerAngles.x) + Mathf.Abs(_currentRotationEulerAngles.y) + Mathf.Abs(_currentRotationEulerAngles.z));
				_rotationFloatTarget = Mathf.Abs(_rotationFloatTarget);
			}
			if (InterpolateRotation)
			{
				switch (FollowRotationMode)
				{
				case FollowModes.MMLerp:
					base.transform.rotation = MMMaths.Lerp(base.transform.rotation, _newTargetRotation, FollowRotationSpeed, Time.deltaTime);
					break;
				case FollowModes.RegularLerp:
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, _newTargetRotation, Time.deltaTime * FollowRotationSpeed);
					break;
				case FollowModes.MMSpring:
					if (_rotationFloatCurrent != _rotationFloatTarget)
					{
						MMMaths.Spring(ref _rotationFloatCurrent, _rotationFloatTarget, ref _rotationFloatVelocity, RotationSpringDamping, RotationSpringFrequency, Time.deltaTime);
						float t = MMMaths.Remap(_rotationFloatCurrent, 0f, _rotationFloatTarget, 0f, 1f);
						base.transform.rotation = Quaternion.LerpUnclamped(_rotationBeforeSpring, _newTargetRotation, t);
					}
					break;
				}
			}
			else
			{
				base.transform.rotation = _newTargetRotation;
			}
			_newTargetRotationEulerAnglesLastFrame = _newTargetRotationEulerAngles;
		}

		protected virtual void FollowTargetScale()
		{
			if (Target == null || !FollowScale)
			{
				return;
			}
			_newTargetScale = Target.localScale * FollowScaleFactor;
			if (InterpolateScale)
			{
				switch (FollowScaleMode)
				{
				case FollowModes.MMLerp:
					base.transform.localScale = MMMaths.Lerp(base.transform.localScale, _newTargetScale, FollowScaleSpeed, Time.deltaTime);
					break;
				case FollowModes.RegularLerp:
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, _newTargetScale, Time.deltaTime * FollowScaleSpeed);
					break;
				case FollowModes.MMSpring:
					_newScale = base.transform.localScale;
					MMMaths.Spring(ref _newScale, _newTargetScale, ref _scaleVelocity, ScaleSpringDamping, ScaleSpringFrequency, Time.deltaTime);
					base.transform.localScale = _newScale;
					break;
				}
			}
			else
			{
				base.transform.localScale = _newTargetScale;
			}
		}

		public virtual void ChangeFollowTarget(Transform newTarget)
		{
			Target = newTarget;
		}

		protected virtual void OnDisable()
		{
			if (DisableSelfOnSetActiveFalse)
			{
				base.enabled = false;
			}
		}
	}
}
