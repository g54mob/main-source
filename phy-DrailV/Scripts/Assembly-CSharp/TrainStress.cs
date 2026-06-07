using System;
using System.Collections;
using DV;
using DV.OriginShift;
using DV.Telemetry;
using DV.Utils;
using UnityEngine;

public class TrainStress : MonoBehaviour
{
	public struct Snapshot
	{
		public Vector3 stressVector;

		public float stressMagnitude;

		public float derailBuildup;
	}

	public class Telemetry : TelemetryData<TrainStress, Snapshot>
	{
		protected override string ObjectName => base.TargetObject.name + "(TrainStress)";

		public Telemetry(TrainStress ts)
			: base(ts, true, 3600)
		{
		}

		protected override void RecordTo(TrainStress obj, ref Snapshot data)
		{
			data.stressVector = obj.stressVector;
			data.stressMagnitude = obj.stress;
			data.derailBuildup = obj.derailBuildUp;
		}
	}

	private const float DERAIL_VELOCITY_THRESHOLD_KMH = 15f;

	private const float WHEELSLIP_DERAIL_THRESHOLD_INFLUENCE = 0.4f;

	private const float WHEEL_DMG_DERAIL_THRESHOLD_INFLUENCE = 0.5f;

	private const float RAW_STRESS_SCALE_FACTOR = 0.01f;

	private const float SLOW_BUILDUP_STRESS_SMOOTH_TIME = 0.3f;

	private const float SLOW_BUILDUP_STRESS_MULTIPLIER = 0.125f;

	private const float STRESS_CALCULATION_WAIT_TIME = 2f;

	public static bool globalIgnoreStressCalculation;

	private TrainCar car;

	private GameParams gameParams;

	private ConfigurableJoint cj;

	private bool noStressCheck;

	[NonSerialized]
	public float derailBuildUp;

	[NonSerialized]
	public float stress;

	[NonSerialized]
	public Vector3 stressVector;

	[NonSerialized]
	public Vector3 targetStress;

	[NonSerialized]
	public float slowBuildUpStress;

	private Vector3 refStress;

	private float avgSpeedKmh;

	private float refAvgSpeedKmh;

	private float refSlowBuildUpStress;

	private bool stressCalculationReady;

	private Coroutine initializeCoro;

	[HideInInspector]
	public TrainStressFrameData debugStressData;

	private Telemetry telemetryRecorder;

	public event Action<float, Vector3> StressDamage;

	private void Awake()
	{
		gameParams = Globals.G.GameParams;
		car = GetComponent<TrainCar>();
		telemetryRecorder = new Telemetry(this);
		car.TelemetryRecorder.RegisterChild(telemetryRecorder);
		SetupDingleberry();
		if (!SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
		{
			Initialize();
		}
	}

	private void OnEnable()
	{
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		SetupListeners(on: false);
		ResetTrainStress();
	}

	public void Initialize()
	{
		if (initializeCoro != null)
		{
			Debug.LogError("initializeCoro was already running!");
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initializeCoro);
		}
		initializeCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(InitializeStressCoro());
	}

	private IEnumerator InitializeStressCoro()
	{
		stressCalculationReady = false;
		EnableStress(set: false);
		yield return WaitFor.Seconds(2f);
		stressCalculationReady = true;
		if (car == null)
		{
			Debug.LogError("Unexpected state: car is null!");
			yield break;
		}
		OnMovementStateChanged(!car.isStationary);
		car.MovementStateChanged += OnMovementStateChanged;
		initializeCoro = null;
	}

	public void Deinitialize()
	{
		if (initializeCoro != null)
		{
			Debug.LogWarning("initializeCoro wasn't finished!");
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initializeCoro);
			initializeCoro = null;
		}
		stressCalculationReady = false;
		EnableStress(set: false);
		car.MovementStateChanged -= OnMovementStateChanged;
		cj.transform.localPosition = Vector3.zero;
		cj.transform.localRotation = Quaternion.identity;
		Rigidbody component = cj.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.velocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
		}
		else
		{
			Debug.LogError("Unexpected error: Missing rb from " + cj.gameObject.name + "!", cj);
		}
	}

	public void EnableStress(bool set)
	{
		cj.gameObject.SetActive(set);
		base.enabled = set;
	}

	private void OnMovementStateChanged(bool isMoving)
	{
		EnableStress(isMoving);
	}

	private void SetupListeners(bool on)
	{
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			if (on)
			{
				SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld += HandleOriginShift;
			}
			else
			{
				SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld -= HandleOriginShift;
			}
		}
	}

	private void HandleOriginShift(Vector3 newMove, Vector3 _)
	{
		noStressCheck = true;
		SingletonBehaviour<CoroutineManager>.Instance.Run(ContinueStressCheck());
	}

	private IEnumerator ContinueStressCheck()
	{
		yield return WaitFor.Seconds(1f);
		noStressCheck = false;
	}

	public void DisableStressCheckForTwoSeconds()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(DisableStressCheckForTwoSecondsCoro());
	}

	private IEnumerator DisableStressCheckForTwoSecondsCoro()
	{
		stressCalculationReady = false;
		yield return WaitFor.Seconds(2f);
		stressCalculationReady = true;
	}

	private void SetupDingleberry()
	{
		GameObject gameObject = new GameObject("[stress dingleberry]");
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.transform.localPosition = new Vector3(0f, 0f, car.Bounds.center.z);
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.sleepThreshold = 0f;
		rigidbody.mass = 10f;
		rigidbody.useGravity = false;
		cj = gameObject.AddComponent<ConfigurableJoint>();
		cj.xMotion = ConfigurableJointMotion.Limited;
		cj.yMotion = ConfigurableJointMotion.Limited;
		cj.zMotion = ConfigurableJointMotion.Limited;
		cj.angularXMotion = ConfigurableJointMotion.Locked;
		cj.angularYMotion = ConfigurableJointMotion.Locked;
		cj.angularZMotion = ConfigurableJointMotion.Locked;
		cj.connectedBody = car.rb;
		cj.enableCollision = false;
		cj.autoConfigureConnectedAnchor = false;
		cj.anchor = Vector3.zero;
		cj.connectedAnchor = gameObject.transform.localPosition;
		cj.massScale = 10f;
		cj.connectedMassScale = 0.1f;
		gameObject.SetActive(value: false);
		SingletonBehaviour<PausePhysicsHandler>.Instance.Register(rigidbody);
	}

	private void FixedUpdate()
	{
		if (car.rb.isKinematic || !stressCalculationReady || globalIgnoreStressCalculation)
		{
			return;
		}
		float num = car.rb.velocity.magnitude * 3.6f;
		avgSpeedKmh = Mathf.SmoothDamp(avgSpeedKmh, num, ref refAvgSpeedKmh, 0.5f);
		Vector3 vector = base.transform.InverseTransformDirection(cj.currentForce);
		float num2 = vector.magnitude * 0.01f;
		if (num2 > 1f)
		{
			float num3 = num2 - 1f;
			this.StressDamage?.Invoke(num3 * 1383.3334f, -cj.currentForce.normalized);
		}
		vector.y /= 100f;
		vector.z /= 100f;
		targetStress = vector;
		stressVector = Vector3.SmoothDamp(stressVector, targetStress, ref refStress, 0.1f, 1500f);
		stress = stressVector.magnitude;
		slowBuildUpStress = Mathf.SmoothDamp(slowBuildUpStress, targetStress.magnitude * 0.125f, ref refSlowBuildUpStress, 0.3f, 1500f, Time.fixedDeltaTime);
		if (!noStressCheck && !car.derailed)
		{
			float derailStressThreshold = gameParams.DerailStressThreshold;
			float derailMinVelocity = gameParams.DerailMinVelocity;
			float derailBuildUpThreshold = gameParams.DerailBuildUpThreshold;
			float derailBuildUpMultiplier = gameParams.DerailBuildUpMultiplier;
			float derailRandomChance = gameParams.DerailRandomChance;
			bool flag = num > derailMinVelocity;
			if (flag && stress > derailStressThreshold)
			{
				derailBuildUp += Time.fixedDeltaTime * stress * derailBuildUpMultiplier;
			}
			derailBuildUp -= Time.fixedDeltaTime * 90f * (derailBuildUp / 32f);
			derailBuildUp = Mathf.Clamp(derailBuildUp, 0f, float.PositiveInfinity);
			if (derailBuildUp > derailBuildUpThreshold && UnityEngine.Random.value < derailRandomChance && flag)
			{
				Derail("Due to stress build up: " + derailBuildUp + " at speed: " + car.rb.velocity.magnitude * 3.6f);
			}
		}
		debugStressData.position = base.transform.AbsolutePosition();
		debugStressData.rotation = base.transform.rotation;
		debugStressData.velocity = car.rb.velocity;
		debugStressData.jointForce = cj.currentForce;
		debugStressData.jointTorque = cj.currentTorque;
		debugStressData.isValid = true;
	}

	public void Derail(string msg)
	{
		Debug.LogWarning("DERAILED! " + msg, base.gameObject);
		car.Derail();
	}

	public void ResetTrainStress()
	{
		if (stress != 0f || slowBuildUpStress != 0f)
		{
			stress = 0f;
			slowBuildUpStress = 0f;
			stressVector = Vector3.zero;
			refStress = Vector3.zero;
			refSlowBuildUpStress = 0f;
		}
		derailBuildUp = 0f;
	}

	private void DrawTextDebug(float value, Vector3 position, int offsetIndex, string prefix)
	{
	}
}
