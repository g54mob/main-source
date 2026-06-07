using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DV;
using DV.Logic.Job;
using DV.PointSet;
using DV.Telemetry;
using DV.ThingTypes;
using DV.Utils;
using DV.Wheels;
using Unity.Linq;
using UnityEngine;

public class Bogie : MonoBehaviour
{
	public struct Snapshot
	{
		public Vector3 position;

		public Quaternion orientation;

		public Vector3 velocity;

		public Vector3 angularVelocity;

		public string track;

		public double trackSpan;

		public int trackDirection;

		public bool kinematic;
	}

	public class Telemetry : TelemetryData<Bogie, Snapshot>
	{
		protected override string ObjectName => base.TargetObject.name + "(Bogie)";

		public Telemetry(Bogie b)
			: base(b, true, 3600)
		{
		}

		protected override void RecordTo(Bogie obj, ref Snapshot data)
		{
			if (obj.rb != null)
			{
				data.position = obj.rb.position;
				data.orientation = obj.rb.rotation;
				data.velocity = obj.rb.velocity;
				data.angularVelocity = obj.rb.angularVelocity;
				data.kinematic = obj.rb.isKinematic;
			}
			else
			{
				data.position = obj.transform.position;
				data.orientation = obj.transform.rotation;
				data.velocity = Vector3.zero;
				data.angularVelocity = Vector3.zero;
				data.kinematic = false;
			}
			data.track = ((obj.track != null) ? obj.track.name : "");
			data.trackSpan = ((obj.traveller != null) ? obj.traveller.Span : (-1.0));
			data.trackDirection = obj.trackDirection;
		}
	}

	public class AxleInfo
	{
		public readonly Transform transform;

		public readonly float distanceFromBogiePivot;

		public AxleInfo(Transform transform)
		{
			distanceFromBogiePivot = transform.localPosition.z;
			this.transform = transform;
		}
	}

	private const float RESISTANCE_FORCE_SCALE_DOWN_VELOCITY = 0.1f;

	private const float BRAKE_MASS_FACTOR = 8.695652E-05f;

	private const float VERTICAL_SUSPENSION_FORCE = 9000000f;

	private const float HORIZONTAL_SUSPENSION_FORCE = 4500000f;

	private const float ROTATIONAL_SUSPENSION_FORCE = 4500000f;

	private const float FORCE_TO_DAMPER = 10f;

	private const float REFERENCE_MASS = 115000f;

	private const float SPAN_DELTA_ROUND_TO_0_THRESHOLD = 0.0001f;

	private const float WHEEL_SLIDE_BRAKING_FORCE_REDUCTION = 0.4f;

	private const float TRACK_STRESS_ROLLING_RESISTANCE_MULTIPLIER = 25f;

	private const string BOGIE_AXLE_PARENT = "bogie_car";

	private const string BOGIE_AXLE_PREFIX = "[axle]";

	public RailTrack track;

	[NonSerialized]
	public float brakingForce;

	private TrainCar _car;

	[NonSerialized]
	public bool isFrontBogie;

	[NonSerialized]
	public Rigidbody rb;

	private Vector3 initialConnectedAnchor;

	private bool isDerailedOnLoad;

	private bool constrainNodeUp = true;

	public PointSetTraveller traveller;

	public EquiPointSet.Point point1;

	public EquiPointSet.Point point2;

	[HideInInspector]
	[SerializeField]
	public double spawnPointsetSpan;

	private const bool USE_PRECISE_INTERPOLATION = false;

	private int trackDirection = 1;

	[NonSerialized]
	public BogieAudioController audioController;

	private AxleInfo[] axles;

	public const float BRAKE_SLOPE_ANGLE_MIN = 0f;

	public const float BRAKE_SLOPE_ANGLE_MAX = 5f;

	public const float SLOPE_Z_VELOCITY_THRESHOLD_MIN = 0.01f;

	public const float SLOPE_Z_VELOCITY_THRESHOLD_MAX = 0.1f;

	private Vector3? slopeStopPosition;

	private GameParams gameParams;

	[NonSerialized]
	public TrainStress trainStress;

	private Vector3 startingLocalPosition;

	private Quaternion startingLocalRotation;

	[NonSerialized]
	public bool fullyInitialized;

	[NonSerialized]
	public float maxBrakingForcePerKg;

	private float rollingResistanceCoefficient;

	private CarSpawner carSpawner;

	private HashSet<Bogie> bogiesOnTrack;

	private Telemetry telemetryRecorder;

	public bool DistanceTrackingEnabled { get; set; }

	public double TotalDistanceTravelled { get; private set; }

	public TrainCar Car
	{
		get
		{
			if (_car == null)
			{
				_car = GetComponentInParent<TrainCar>();
			}
			return _car;
		}
	}

	public bool HasDerailed { get; private set; }

	public float TrackDirectionSign => trackDirection;

	public AxleInfo[] Axles
	{
		get
		{
			if (axles == null)
			{
				GameObject gameObject = base.gameObject.Child("bogie_car");
				if (gameObject == null)
				{
					Debug.LogError("Bogie [" + base.name + "] doesn't have correct hierarchy setup [bogie_car/[axle]]. Wheels rotation and axle joint audio won't work", base.gameObject);
					axles = new AxleInfo[0];
					return axles;
				}
				GameObject[] array = (from ch in gameObject.Children()
					where ch.name.StartsWith("[axle]")
					select ch).ToArray();
				axles = new AxleInfo[array.Length];
				if (array.Length != 0)
				{
					for (int num = 0; num < axles.Length; num++)
					{
						axles[num] = new AxleInfo(array[num].transform);
					}
				}
				else
				{
					Debug.LogError("Bogie [" + base.name + "] doesn't have correct hierarchy setup [bogie_car/[axle]]. Wheels rotation and axle joint audio won't work", base.gameObject);
				}
			}
			return axles;
		}
	}

	public bool isStoppedOnSlope { get; private set; }

	public event Action<bool> StoppedOnSlope;

	public event Action<RailTrack, Bogie> TrackChanged;

	private void Awake()
	{
		isFrontBogie = Car.FrontBogie == this;
		startingLocalPosition = base.transform.localPosition;
		startingLocalRotation = base.transform.localRotation;
		telemetryRecorder = new Telemetry(this);
		Car.TelemetryRecorder.RegisterChild(telemetryRecorder);
		TrainCarType_v2 parentType = Car.carLivery.parentType;
		maxBrakingForcePerKg = parentType.brakes.MaxBrakingForcePerBogie * 8.695652E-05f;
		rollingResistanceCoefficient = parentType.RollingResistanceCoef;
		carSpawner = SingletonBehaviour<CarSpawner>.Instance;
	}

	public void ResetDistanceTravelled()
	{
		TotalDistanceTravelled = 0.0;
	}

	public void SetDerailedOnLoadFlag(bool set)
	{
		isDerailedOnLoad = set;
	}

	private void Start()
	{
		gameParams = Globals.G.GameParams;
		trainStress = Car.stress;
		if (!isDerailedOnLoad)
		{
			SetupPhysics();
			if (!carSpawner.PoolSetupInProgress)
			{
				Car.UpdateMassRatioWhenBogiesInitialized();
			}
		}
		else
		{
			Derail("Loaded state", suppressDerailSound: true, callDerailOnOtherBogies: false);
			isDerailedOnLoad = false;
		}
		fullyInitialized = true;
	}

	public void RemoveBogieFromCurrentTrack()
	{
		if ((bool)track)
		{
			if (!bogiesOnTrack.Remove(this))
			{
				Debug.LogError("Failed at removing bogie from bogiesOnTrack of '" + track.name + "'", track);
			}
			track.TrackPointsUpdated -= WakeUpOnTrackPointsUpdated;
			track = null;
			bogiesOnTrack = null;
		}
	}

	private bool UpdatePointSetTraveller(float localZVelocity)
	{
		Vector3 lhs = (Vector3)(point2.position - point1.position);
		Vector3 rhs = (Vector3)(new Vector3d(base.transform.position) - new Vector3d(WorldMover.currentMove) - point1.position);
		float num = Vector3.Dot(lhs, rhs) / lhs.sqrMagnitude * (float)traveller.curPoint.spanToNextPoint - (float)traveller.pointRelativeSpan;
		if (Mathf.Abs(num) < 0.0001f)
		{
			num = 0f;
		}
		if (num == 0f && Mathf.Abs(localZVelocity) > 1f)
		{
			Debug.LogError($"Point Set Traveller not moving even though velocity is: {localZVelocity}");
		}
		double num2 = traveller.Span + (double)num;
		double span = track.GetKinkedPointSet().span;
		if (num2 >= 0.0 && num2 < span)
		{
			double value = traveller.Travel(num);
			if (DistanceTrackingEnabled)
			{
				TotalDistanceTravelled += (double)Math.Abs(num) - Math.Abs(value);
			}
		}
		else
		{
			bool flag = num2 < 0.0;
			Junction.Branch branch = (flag ? track.GetInBranch() : track.GetOutBranch());
			if (branch == null || branch.track == null)
			{
				Derail("Reached end of track!");
				return false;
			}
			if (DistanceTrackingEnabled)
			{
				if (num2 < 0.0)
				{
					TotalDistanceTravelled += traveller.Span;
				}
				else if (num2 >= span)
				{
					TotalDistanceTravelled += span - traveller.Span;
				}
			}
			int num3 = ((flag != branch.first) ? 1 : (-1));
			RailTrack railTrack = branch.track;
			SwitchJunctionIfNeeded(track, flag);
			SetTrack(railTrack, branch.first ? 0.0 : railTrack.GetKinkedPointSet().span, trackDirection * num3);
			double num4 = Math.Abs(flag ? num2 : (num2 - span)) * (double)(branch.first ? 1 : (-1));
			double value2 = traveller.Travel(num4);
			if (DistanceTrackingEnabled)
			{
				TotalDistanceTravelled += Math.Abs(num4) - Math.Abs(value2);
			}
		}
		point1 = traveller.curPoint;
		point2 = traveller.pointSet.points[traveller.curPoint.index + 1];
		return true;
	}

	private void WakeUpOnTrackPointsUpdated(RailTrack _)
	{
		Car.ForceOptimizationState(sleep: false);
		RefreshBogiePoints();
	}

	public void RefreshBogiePoints()
	{
		traveller.RefreshTraveler();
		point1 = traveller.pointSet.points[point1.index];
		point2 = traveller.pointSet.points[point2.index];
		PreventSlopePositionHolding();
	}

	private void SetupPhysics()
	{
		rb = GetComponent<Rigidbody>();
		if ((bool)rb)
		{
			Debug.LogWarning("Bogie on car '" + Car.name + "' already has a Rigidbody, it shouldn't", this);
		}
		else
		{
			rb = base.gameObject.AddComponent<Rigidbody>();
		}
		rb.mass = Car.massController.DefaultBogieRbMass;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		SingletonBehaviour<PausePhysicsHandler>.Instance.Register(rb);
		ConfigurableJoint configurableJoint = base.transform.GetComponent<ConfigurableJoint>();
		if ((bool)configurableJoint)
		{
			Debug.LogWarning("Bogie on car '" + Car.name + "' already has a ConfigurableJoint, it shouldn't", this);
		}
		else
		{
			configurableJoint = base.transform.gameObject.AddComponent<ConfigurableJoint>();
		}
		configurableJoint.anchor = new Vector3(0f, 1f, 0f);
		configurableJoint.axis = new Vector3(0f, 0f, 1f);
		configurableJoint.connectedBody = Car.rb;
		configurableJoint.autoConfigureConnectedAnchor = false;
		initialConnectedAnchor = configurableJoint.connectedBody.transform.InverseTransformPoint(base.transform.TransformPoint(configurableJoint.anchor));
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = 0.3f
		};
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 0f,
			damper = 0f
		};
		configurableJoint.linearLimit = linearLimit;
		configurableJoint.linearLimitSpring = linearLimitSpring;
		SetupJointSettings(Car.massController.TotalMass);
	}

	public void SetupJointSettings(float mass)
	{
		ConfigurableJoint component = GetComponent<ConfigurableJoint>();
		if ((bool)component)
		{
			float num = Car.carLivery.parentType.bogieSuspensionMultiplier * (mass / 115000f);
			JointDrive yDrive = component.yDrive;
			yDrive.positionSpring = 9000000f * num;
			yDrive.positionDamper = 9000000f * num / 10f;
			component.yDrive = yDrive;
			JointDrive zDrive = component.zDrive;
			zDrive.positionSpring = 4500000f * num;
			zDrive.positionDamper = 4500000f * num / 10f;
			component.zDrive = zDrive;
			JointDrive angularXDrive = component.angularXDrive;
			angularXDrive.positionSpring = 4500000f * num;
			angularXDrive.positionDamper = 4500000f * num / 10f;
			component.angularXDrive = angularXDrive;
			SoftJointLimit lowAngularXLimit = component.lowAngularXLimit;
			lowAngularXLimit.limit = -5f;
			component.lowAngularXLimit = lowAngularXLimit;
			SoftJointLimit highAngularXLimit = component.highAngularXLimit;
			highAngularXLimit.limit = 5f;
			component.highAngularXLimit = highAngularXLimit;
			float num2 = Car.rb.mass * Physics.gravity.y / yDrive.positionSpring;
			component.connectedAnchor = initialConnectedAnchor + num2 * Vector3.up;
		}
	}

	private void UpdateRotation()
	{
		Quaternion rot = Quaternion.LookRotation(traveller.worldForward * trackDirection, traveller.worldUp);
		rb.MoveRotation(rot);
	}

	public void PreventSlopePositionHolding()
	{
		slopeStopPosition = null;
	}

	private void FixedUpdate()
	{
		if (SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess || carSpawner.PoolSetupInProgress)
		{
			return;
		}
		TrainCar car = Car;
		if (HasDerailed || rb.IsSleeping())
		{
			return;
		}
		car.ActivateGravity(set: true);
		if (!track)
		{
			Derail("Due to missing track");
			return;
		}
		float z = base.transform.InverseTransformDirection(rb.velocity).z;
		float num = Mathf.Abs(z);
		if (!rb.isKinematic)
		{
			if (!isFrontBogie)
			{
				car.brakeSystem.heatController.currentAbsSpeed = (car.adhesionController.IsWheelSliding ? 0f : num);
			}
			if (!UpdatePointSetTraveller(z))
			{
				return;
			}
			rb.velocity = z * base.transform.forward;
			rb.MovePosition((Vector3)traveller.worldPosition + WorldMover.currentMove);
			if (constrainNodeUp)
			{
				rb.angularVelocity = Vector3.zero;
				UpdateRotation();
			}
		}
		float num2 = maxBrakingForcePerKg * rb.mass;
		brakingForce = car.brakeSystem.brakingFactor * num2;
		float num3 = Mathf.Abs(car.transform.localEulerAngles.x);
		float num4 = ((num3 > 180f) ? Mathf.Abs(num3 - 360f) : num3);
		bool num5 = num4 >= 0f && num4 < 5f;
		float num6 = Mathf.Lerp(0.01f, 0.1f, Mathf.InverseLerp(0f, 5f, num4));
		if (num5 && num <= num6 && car.brakeSystem.brakingFactor > 0.5f && !rb.isKinematic)
		{
			if (slopeStopPosition.HasValue)
			{
				rb.MovePosition(slopeStopPosition.Value + WorldMover.currentMove);
			}
			else
			{
				slopeStopPosition = (Vector3)traveller.worldPosition;
			}
			rb.velocity = Vector3.zero;
			if (!isStoppedOnSlope)
			{
				isStoppedOnSlope = true;
				this.StoppedOnSlope?.Invoke(isStoppedOnSlope);
			}
			return;
		}
		slopeStopPosition = null;
		if (isStoppedOnSlope)
		{
			isStoppedOnSlope = false;
			this.StoppedOnSlope?.Invoke(isStoppedOnSlope);
		}
		float num7 = brakingForce;
		bool flag = false;
		AdhesionController adhesionController = car.adhesionController;
		if (adhesionController != null)
		{
			if (adhesionController.wheelSlide > 0f)
			{
				num7 = Mathf.Lerp(num7, 0.4f * num2, adhesionController.wheelSlide);
			}
			if (adhesionController.wheelslipController.IsSome(out var value) && value.wheelslip > 0f)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			float num8 = rb.mass * (0f - Physics.gravity.y);
			float num9 = 1f + 25f * Mathf.Clamp01(trainStress.slowBuildUpStress);
			float num10 = rollingResistanceCoefficient * num9 * num8;
			float num11 = num7 + num10;
			if (num < 0.1f)
			{
				num11 = Mathf.Max(num10, Mathf.Lerp(0f, num11, num / 0.1f));
			}
			rb.AddForce(base.transform.forward * Mathf.Sign(z) * -1f * num11);
		}
	}

	public void ForceSleep(bool set)
	{
		if (set)
		{
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.Sleep();
		}
		else
		{
			rb.WakeUp();
			rb.useGravity = true;
		}
	}

	public void Derail(string message = "", bool suppressDerailSound = false, bool callDerailOnOtherBogies = true)
	{
		if (!Application.isPlaying || HasDerailed)
		{
			return;
		}
		if (!isDerailedOnLoad)
		{
			Job jobOfCar = SingletonBehaviour<JobsManager>.Instance.GetJobOfCar(Car.logicCar);
			Debug.LogWarning("DERAILED! " + message + " | TYPE: " + Car.carLivery.id + " | ID: " + Car.ID + " | JOB_ID: " + ((jobOfCar != null) ? jobOfCar.ID : "/"), base.gameObject);
		}
		constrainNodeUp = false;
		base.enabled = false;
		isStoppedOnSlope = false;
		slopeStopPosition = null;
		if ((bool)track)
		{
			if (!bogiesOnTrack.Remove(this))
			{
				Debug.LogError("Failed at removing bogie from bogiesOnTrack of '" + track.name + "'", track);
			}
			track.TrackPointsUpdated -= WakeUpOnTrackPointsUpdated;
			track = null;
			bogiesOnTrack = null;
			this.TrackChanged?.Invoke(track, this);
		}
		if (!isDerailedOnLoad)
		{
			UnityEngine.Object.Destroy(GetComponent<ConfigurableJoint>());
			UnityEngine.Object.Destroy(rb);
			rb = null;
			base.transform.localPosition = startingLocalPosition;
			SingletonBehaviour<CoroutineManager>.Instance.Run(FixPositionAfterDerail());
		}
		HasDerailed = true;
		if ((bool)Car)
		{
			Car.Derail(suppressDerailSound, callDerailOnOtherBogies);
		}
	}

	private IEnumerator FixPositionAfterDerail()
	{
		yield return WaitFor.FixedUpdate;
		if ((bool)base.gameObject)
		{
			base.transform.localPosition = startingLocalPosition;
		}
	}

	public void ResetBogiesToStartPosition()
	{
		base.transform.localPosition = startingLocalPosition;
		base.transform.localRotation = startingLocalRotation;
	}

	public void ResetBogieMassToDefault()
	{
		if ((object)rb == null)
		{
			Debug.LogError("Unexpected state: Attempting to change mass on null rb!", this);
		}
		else
		{
			rb.mass = Car.massController.DefaultBogieRbMass;
		}
	}

	public void RerailInitialize()
	{
		if (HasDerailed)
		{
			ResetBogiesToStartPosition();
			SetupPhysics();
			constrainNodeUp = true;
			isDerailedOnLoad = false;
			HasDerailed = false;
			base.enabled = true;
		}
	}

	public float GetPerlinNoiseOffset(float seed, float freqMult)
	{
		float num = (float)traveller.Span;
		return PN(num * 0.1f * freqMult, 0.07f, seed) + PN(num * 0.5f * freqMult, 0.015f, seed);
	}

	private float PN(float frequency, float scale = 1f, float seed = 342.23f)
	{
		return (-0.5f + Mathf.PerlinNoise(seed, frequency)) * scale;
	}

	private void SwitchJunctionIfNeeded(RailTrack track, bool first)
	{
		Junction junction = null;
		if (first && (bool)track.inJunction)
		{
			junction = track.inJunction;
		}
		else if (!first && (bool)track.outJunction)
		{
			junction = track.outJunction;
		}
		if (!junction)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < junction.outBranches.Count; i++)
		{
			if (junction.outBranches[i].track == track)
			{
				num = i;
				break;
			}
		}
		if (num != -1 && num != junction.selectedBranch)
		{
			junction.Switch(Junction.SwitchMode.FORCED);
		}
	}

	public void SetTrack(RailTrack newTrack, double positionAlongTrack, int newTrackDirection = 0)
	{
		if (Application.isPlaying && track != null)
		{
			if (bogiesOnTrack != null && bogiesOnTrack.Contains(this))
			{
				track.TrackPointsUpdated -= WakeUpOnTrackPointsUpdated;
				bogiesOnTrack.Remove(this);
			}
			else
			{
				Debug.LogWarning("Previous track '" + track.name + "' did not contain bogie '" + base.name + "' of car '" + Car.name + "'", this);
			}
		}
		ValidateTrack(newTrack, "SetTrack");
		track = newTrack;
		bogiesOnTrack = newTrack.BogiesOnTrack();
		track.TrackPointsUpdated += WakeUpOnTrackPointsUpdated;
		this.TrackChanged?.Invoke(track, this);
		if (Application.isPlaying)
		{
			bogiesOnTrack.Add(this);
			traveller = new PointSetTraveller(track.GetKinkedPointSet());
			traveller.MoveToSpan(positionAlongTrack);
			point1 = traveller.curPoint;
			point2 = traveller.pointSet.points[traveller.curPoint.index + 1];
			if (newTrackDirection == 0)
			{
				FigureOutDirection();
			}
			else
			{
				trackDirection = Math.Sign(newTrackDirection);
			}
		}
		else
		{
			spawnPointsetSpan = positionAlongTrack;
		}
	}

	private void FigureOutDirection()
	{
		float num = Vector3.Dot(Vector3.LerpUnclamped(point1.forward, point2.forward, 0.5f).normalized, base.transform.forward);
		trackDirection = ((!(num < 0f)) ? 1 : (-1));
	}

	private void ValidateTrack(RailTrack track, [CallerMemberName] string caller = "")
	{
		if (track == null)
		{
			Debug.LogWarning(Msg("has no track assigned"), this);
		}
		else if (track.GetKinkedPointSet() == null)
		{
			Debug.LogError(Msg("has track assigned but its PointSet is null"), this);
		}
		else if (track.GetKinkedPointSet().points == null)
		{
			Debug.LogError(Msg("has track with null points array"), this);
		}
		else if (track.GetKinkedPointSet().points.Length == 0)
		{
			Debug.LogError(Msg("has track with empty points array"), this);
		}
		else if (track.GetKinkedPointSet().points.Length < 2)
		{
			Debug.LogError(Msg("has track with points array with only 1 point"), this);
		}
		string Msg(string msg)
		{
			return "Bogie on '" + Car.name + "' " + msg + " (" + caller + ")";
		}
	}

	public void ApplyForce(float inputForce)
	{
		rb.AddForce(base.transform.forward * inputForce);
	}

	private void OnDrawGizmos()
	{
	}
}
