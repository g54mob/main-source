using UnityEngine;

public class EngineTimingComponent : MonoBehaviour
{
	[Header("Ignition Timing")]
	[SerializeField]
	private float baseAdvance = 10f;

	[SerializeField]
	private float maxAdvance = 35f;

	[SerializeField]
	private float timingRetardKnock = 5f;

	[Header("Knock Detection")]
	[SerializeField]
	private bool simulateKnock;

	[SerializeField]
	private float knockThresholdRPM = 6000f;

	[Header("Valve Timing (degrees)")]
	[SerializeField]
	private float intakeOpen = 10f;

	[SerializeField]
	private float intakeClose = 50f;

	[SerializeField]
	private float exhaustOpen = 55f;

	[SerializeField]
	private float exhaustClose = 15f;

	private EngineComponent _engine;

	public float IgnitionAdvanceDeg { get; private set; }

	public bool KnockDetected { get; private set; }

	public float ValveOverlapDeg => intakeOpen + exhaustClose;

	private void Awake()
	{
		_engine = GetComponent<EngineComponent>();
	}

	private void Update()
	{
		if (!(_engine == null) && _engine.IsRunning)
		{
			UpdateIgnitionTiming(_engine.RPM);
		}
	}

	public float GetTimingEfficiency()
	{
		float num = CalculateOptimalAdvance((_engine != null) ? _engine.RPM : 0f);
		float num2 = Mathf.Abs(IgnitionAdvanceDeg - num);
		return Mathf.Clamp01(1f - num2 / 30f);
	}

	public void SetIgnitionAdvance(float degrees)
	{
		IgnitionAdvanceDeg = Mathf.Clamp(degrees, -5f, maxAdvance);
	}

	public float GetIntakeDuration()
	{
		return intakeClose + 180f + intakeOpen;
	}

	public float GetExhaustDuration()
	{
		return exhaustOpen + 180f + exhaustClose;
	}

	private void UpdateIgnitionTiming(float rpm)
	{
		float num = CalculateOptimalAdvance(rpm);
		KnockDetected = simulateKnock && rpm > knockThresholdRPM && Random.value < 0.005f;
		if (KnockDetected)
		{
			num -= timingRetardKnock;
			Debug.LogWarning("[Timing] Knock detected — retarding ignition.");
		}
		IgnitionAdvanceDeg = Mathf.MoveTowards(IgnitionAdvanceDeg, num, 10f * Time.deltaTime);
	}

	private float CalculateOptimalAdvance(float rpm)
	{
		if (_engine == null)
		{
			return baseAdvance;
		}
		float t = Mathf.Clamp01(rpm / _engine.engineModel.redlineRPM);
		return Mathf.Lerp(baseAdvance, maxAdvance, t);
	}
}
