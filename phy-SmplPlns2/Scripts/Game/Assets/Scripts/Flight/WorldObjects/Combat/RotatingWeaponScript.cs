using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class RotatingWeaponScript : MonoBehaviour, INpcWeaponSystem
	{
		protected enum VerticalRotationAxisType
		{
			X = 0,
			Z = 1
		}

		[SerializeField]
		private bool _allowFiringOnClient;

		[SerializeField]
		[Tooltip("The horizontal rotation transform.")]
		private Transform _horizontalRotation;

		[SerializeField]
		[Tooltip("The maximum horizontal rotation angle.")]
		private float _horizontalRotationMax;

		[SerializeField]
		[Tooltip("The minimum horizontal rotation angle.")]
		private float _horizontalRotationMin;

		[SerializeField]
		[Tooltip("The horizontal rotation rate (in degrees per second)")]
		private float _horizontalRotationRate;

		[SerializeField]
		[Tooltip("The max range of the weapon.")]
		private float _maxRange;

		[SerializeField]
		[Tooltip("The list of rigid bodies to be ignored by the target occlusion test.")]
		private List<Rigidbody> _occlusionTestIgnoredBodies;

		[SerializeField]
		[Tooltip("The layer mask to use for the target occlusion test.")]
		private LayerMask _occlusionTestLayerMask;

		[SerializeField]
		[Tooltip("The frequency in seconds at which target information is updated an the current target is selected.")]
		private float _targetUpdateFrequency = 0.5f;

		[SerializeField]
		[Tooltip("The vertical rotation transform.")]
		private Transform _verticalRotation;

		[SerializeField]
		[Tooltip("The vertical rotation axis.")]
		private VerticalRotationAxisType _verticalRotationAxis;

		[SerializeField]
		[Tooltip("The maximum vertical rotation angle.")]
		private float _verticalRotationMax;

		[SerializeField]
		[Tooltip("The minimum vertical rotation angle.")]
		private float _verticalRotationMin;

		[SerializeField]
		[Tooltip("The vertical rotation rate (in degrees per second)")]
		private float _verticalRotationRate;

		[SerializeField]
		[Tooltip("The transform to use to represent the point at which the weapon becomes disabled if it sinks under the water.")]
		private Transform _waterLevelDisablePoint;

		public bool CanFire
		{
			get
			{
				if (IsArmed)
				{
					if (!_allowFiringOnClient)
					{
						return IsOwner;
					}
					return true;
				}
				return false;
			}
		}

		public virtual Vector2 CurrentAnglesToTarget { get; set; }

		public TrackedTarget CurrentTarget { get; protected set; }

		public virtual float HorizontalRotationRate => _horizontalRotationRate;

		public bool IsArmed { get; private set; }

		public virtual bool IsDisabled { get; protected set; }

		public bool IsOwner => SyncTarget?.IsOwner ?? true;

		public Vector3 Position => base.transform.position;

		public NpcTargetingSystem TargetingSystem { get; private set; }

		public virtual float VerticalRotationRate => _verticalRotationRate;

		protected virtual bool CanRotateTowardsTarget
		{
			get
			{
				if (!IsDisabled && CurrentTarget != null && !CurrentTarget.Occluded)
				{
					return !CurrentTarget.Target.IsDead;
				}
				return false;
			}
		}

		protected Vector3 CurrentAimPosition { get; private set; }

		protected virtual float CurrentHorizontalRotation { get; set; }

		protected virtual float CurrentVerticalRotation { get; set; }

		protected Transform HorizontalRotation => _horizontalRotation;

		protected float HorizontalRotationMax => _horizontalRotationMax;

		protected float HorizontalRotationMin => _horizontalRotationMin;

		protected float MaxRange => _maxRange;

		protected LayerMask OcclusionTestLayerMask => _occlusionTestLayerMask;

		protected SynchronizedTargetScript SyncTarget { get; private set; }

		protected Transform VerticalRotation => _verticalRotation;

		protected VerticalRotationAxisType VerticalRotationAxis => _verticalRotationAxis;

		protected float VerticalRotationMax => _verticalRotationMax;

		protected float VerticalRotationMin => _verticalRotationMin;

		protected virtual Transform WaterLevelDisablePoint => _waterLevelDisablePoint;

		public virtual void Arm()
		{
			IsArmed = true;
		}

		public virtual void Disable()
		{
			IsDisabled = true;
		}

		public void InitializeTargetingSystem(NpcTargetingSystem targetingSystem)
		{
			TargetingSystem = targetingSystem;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		protected virtual Vector2 GetAnglesToTarget(Vector3 aimPosition)
		{
			Vector3 v = HorizontalRotation.InverseTransformPoint(aimPosition);
			float? y = 0f;
			Vector3 to = v.Copy(null, y);
			float x = Vector3.Angle(Vector3.forward, to) * Mathf.Sign(to.x);
			Vector3 vector = VerticalRotation.parent.InverseTransformPoint(aimPosition) - VerticalRotation.localPosition;
			float num = (0f - Mathf.Atan2(vector.y, Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z))) * 57.29578f;
			num -= CurrentVerticalRotation;
			return new Vector2(x, num);
		}

		protected virtual Vector3 GetTargetAimPosition()
		{
			if (CurrentTarget != null)
			{
				return CurrentTarget.Target.Position;
			}
			return Vector3.zero;
		}

		protected virtual void RotateTowardsTarget()
		{
			float num = Mathf.Abs(HorizontalRotationMax - HorizontalRotationMin);
			float num2 = Mathf.Abs(VerticalRotationMax - VerticalRotationMin);
			if (num > 0f)
			{
				float num3 = CurrentHorizontalRotation + CurrentAnglesToTarget.x;
				if (num3 > HorizontalRotationMax)
				{
					float num4 = num3 - 360f;
					num3 = ((!(num4 > HorizontalRotationMin)) ? ((Mathf.Abs(num3 - HorizontalRotationMax) < Mathf.Abs(num4 - HorizontalRotationMin)) ? HorizontalRotationMax : HorizontalRotationMin) : num4);
				}
				else if (num3 < HorizontalRotationMin)
				{
					float num5 = num3 + 360f;
					num3 = ((!(num5 < HorizontalRotationMax)) ? ((Mathf.Abs(num3 - HorizontalRotationMin) < Mathf.Abs(num5 - HorizontalRotationMax)) ? HorizontalRotationMin : HorizontalRotationMax) : num5);
				}
				float num6 = Mathf.Sign(num3 - CurrentHorizontalRotation);
				CurrentHorizontalRotation += HorizontalRotationRate * num6 * Time.deltaTime;
				if ((num6 > 0f && CurrentHorizontalRotation > num3) || (num6 < 0f && CurrentHorizontalRotation < num3))
				{
					CurrentHorizontalRotation = num3;
				}
			}
			if (num2 > 0f)
			{
				float num7 = CurrentVerticalRotation + CurrentAnglesToTarget.y;
				if (num7 > VerticalRotationMax)
				{
					float num8 = num7 - 360f;
					num7 = ((!(num8 > VerticalRotationMin)) ? ((Mathf.Abs(num7 - VerticalRotationMax) < Mathf.Abs(num8 - VerticalRotationMin)) ? VerticalRotationMax : VerticalRotationMin) : num8);
				}
				else if (num7 < VerticalRotationMin)
				{
					float num9 = num7 + 360f;
					num7 = ((!(num9 < VerticalRotationMax)) ? ((Mathf.Abs(num7 - VerticalRotationMin) < Mathf.Abs(num9 - VerticalRotationMax)) ? VerticalRotationMin : VerticalRotationMax) : num9);
				}
				float num10 = Mathf.Sign(num7 - CurrentVerticalRotation);
				CurrentVerticalRotation += VerticalRotationRate * num10 * Time.deltaTime;
				if ((num10 > 0f && CurrentVerticalRotation > num7) || (num10 < 0f && CurrentVerticalRotation < num7))
				{
					CurrentVerticalRotation = num7;
				}
			}
			Vector3 zero = Vector3.zero;
			if (VerticalRotationAxis == VerticalRotationAxisType.X)
			{
				zero.x = CurrentVerticalRotation;
			}
			else if (VerticalRotationAxis == VerticalRotationAxisType.Z)
			{
				zero.z = CurrentVerticalRotation;
			}
			if (HorizontalRotation == VerticalRotation)
			{
				HorizontalRotation.localEulerAngles = new Vector3(0f, CurrentHorizontalRotation, 0f) + zero;
				return;
			}
			HorizontalRotation.localEulerAngles = new Vector3(0f, CurrentHorizontalRotation, 0f);
			VerticalRotation.localEulerAngles = zero;
		}

		protected virtual void Start()
		{
			if (_occlusionTestIgnoredBodies == null)
			{
				_occlusionTestIgnoredBodies = new List<Rigidbody>();
			}
			SyncTarget = GetComponent<SynchronizedTargetScript>();
			if (SyncTarget != null)
			{
				SyncTarget.TargetChanged += OnSyncTargetChanged;
				if (SyncTarget.Target != null)
				{
					OnSyncTargetChanged(SyncTarget.Target);
				}
			}
			StartUpdateCurrentTargetCoroutine();
		}

		protected virtual void StartUpdateCurrentTargetCoroutine()
		{
			StartCoroutine(UpdateCurrentTargetCoroutine());
		}

		protected virtual void Update()
		{
			if (PauseManager.Paused || IsDisabled)
			{
				return;
			}
			if (WaterLevelDisablePoint != null)
			{
				float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
				if (floatingOriginSeaLevel.HasValue && WaterLevelDisablePoint.position.y < floatingOriginSeaLevel.Value)
				{
					Disable();
					return;
				}
			}
			if (CanRotateTowardsTarget)
			{
				CurrentAimPosition = GetTargetAimPosition();
				CurrentAnglesToTarget = GetAnglesToTarget(CurrentAimPosition);
				RotateTowardsTarget();
			}
		}

		private void OnSyncTargetChanged(Target target)
		{
			if (!IsOwner)
			{
				if (!IsArmed)
				{
					Arm();
				}
				TrackedTarget trackedTarget = TargetingSystem.FindTrackedTarget(target);
				if (trackedTarget == null)
				{
					trackedTarget = TargetingSystem.AddTarget(target);
				}
				CurrentTarget = trackedTarget;
			}
		}

		private IEnumerator UpdateCurrentTargetCoroutine()
		{
			WaitForSeconds yieldInstruction = new WaitForSeconds(_targetUpdateFrequency);
			yield return yieldInstruction;
			while (true)
			{
				yield return yieldInstruction;
				if (IsDisabled || !IsOwner)
				{
					continue;
				}
				TrackedTarget trackedTarget = null;
				if (IsArmed)
				{
					foreach (TrackedTarget target in TargetingSystem.Targets)
					{
						if (target.AggressionLevel == AggressionLevel.Hostile && !(target.Distance > MaxRange) && !target.Occluded && !target.Target.IsDead && (trackedTarget == null || trackedTarget.Distance > target.Distance) && (target.Lock == null || target.Lock.AcquireOrMaintain(base.gameObject)))
						{
							if (trackedTarget != null && trackedTarget.Lock != null)
							{
								trackedTarget.Lock.Release(base.gameObject);
							}
							trackedTarget = target;
						}
					}
				}
				if (CurrentTarget != trackedTarget)
				{
					if (CurrentTarget != null && CurrentTarget.Lock != null && CurrentTarget != trackedTarget)
					{
						CurrentTarget.Lock.Release(base.gameObject);
					}
					CurrentTarget = trackedTarget;
					SyncTarget?.SetTarget(CurrentTarget?.Target);
				}
			}
		}
	}
}
