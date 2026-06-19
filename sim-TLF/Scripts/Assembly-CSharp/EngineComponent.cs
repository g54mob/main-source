using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

[RequireComponent(typeof(ThrottleComponent))]
[RequireComponent(typeof(AirFuelRatioComponent))]
[RequireComponent(typeof(EngineTimingComponent))]
public class EngineComponent : MonoBehaviour
{
	[Header("Engine Identity")]
	public string engineName = "V8 Aircraft Engine";

	public EngineModel engineModel;

	[Header("RPM")]
	[SerializeField]
	private float idleRPM = 800f;

	[SerializeField]
	private float maxRPM = 8500f;

	[SerializeField]
	private float rpmSmoothTime = 0.15f;

	[Header("Engine State")]
	[SerializeField]
	private bool autoStart;

	private float _targetRPM;

	private float _rpmVelocity;

	public readonly List<Vector2> TorqueCurveSamples = new List<Vector2>();

	private const int MAX_CURVE_SAMPLES = 200;

	private float _lastSampleTime;

	public float RPM { get; private set; }

	public float NormalizedRPM => Mathf.Clamp01((RPM - idleRPM) / (maxRPM - idleRPM));

	public float Torque { get; private set; }

	public float Power { get; private set; }

	public bool IsRunning { get; private set; }

	public bool IsStalled { get; private set; }

	public ThrottleComponent Throttle { get; private set; }

	public AirFuelRatioComponent AFR { get; private set; }

	public EngineTimingComponent Timing { get; private set; }

	public event Action OnEngineStarted;

	public event Action OnEngineStopped;

	public event Action OnEngineStalled;

	private void Awake()
	{
		Throttle = GetComponent<ThrottleComponent>();
		AFR = GetComponent<AirFuelRatioComponent>();
		Timing = GetComponent<EngineTimingComponent>();
		if (engineModel == null)
		{
			engineModel = new EngineModel();
		}
	}

	private void Start()
	{
		if (autoStart)
		{
			StartEngine();
		}
	}

	private void Update()
	{
		if (IsRunning)
		{
			CalculateRPM();
			CalculateTorqueAndPower();
			CheckStall();
		}
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void StartEngine()
	{
		if (!IsRunning)
		{
			IsRunning = true;
			IsStalled = false;
			RPM = idleRPM;
			this.OnEngineStarted?.Invoke();
			Debug.Log("[Engine] " + engineName + " started.");
		}
	}

	public void StopEngine()
	{
		if (IsRunning)
		{
			IsRunning = false;
			RPM = 0f;
			Torque = 0f;
			Power = 0f;
			this.OnEngineStopped?.Invoke();
			Debug.Log("[Engine] " + engineName + " stopped.");
		}
	}

	public float ReadRPM()
	{
		return RPM;
	}

	public float GetTorqueAtRPM(float rpm)
	{
		return engineModel.EvaluateTorque(rpm);
	}

	private void CalculateRPM()
	{
		float throttlePosition = Throttle.ThrottlePosition;
		float timingEfficiency = Timing.GetTimingEfficiency();
		float aFREfficiency = AFR.GetAFREfficiency();
		float num = timingEfficiency * aFREfficiency;
		_targetRPM = Mathf.Lerp(idleRPM, maxRPM, throttlePosition * num);
		RPM = Mathf.SmoothDamp(RPM, _targetRPM, ref _rpmVelocity, rpmSmoothTime);
		RPM = Mathf.Clamp(RPM, 0f, maxRPM);
	}

	private void CalculateTorqueAndPower()
	{
		Torque = engineModel.EvaluateTorque(RPM) * AFR.GetAFREfficiency() * Timing.GetTimingEfficiency();
		float num = RPM * MathF.PI / 30f;
		Power = Torque * num / 1000f;
		RecordTorqueSample();
	}

	private void CheckStall()
	{
		if (RPM < idleRPM * 0.5f && Throttle.ThrottlePosition < 0.02f)
		{
			IsStalled = true;
			IsRunning = false;
			RPM = 0f;
			this.OnEngineStalled?.Invoke();
			Debug.LogWarning("[Engine] " + engineName + " stalled!");
		}
	}

	private void RecordTorqueSample()
	{
		if (!(Time.time - _lastSampleTime < 0.1f))
		{
			_lastSampleTime = Time.time;
			TorqueCurveSamples.Add(new Vector2(RPM, Torque));
			if (TorqueCurveSamples.Count > 200)
			{
				TorqueCurveSamples.RemoveAt(0);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = (IsRunning ? Color.green : Color.red);
		Gizmos.DrawWireSphere(base.transform.position, 0.3f);
	}
}
