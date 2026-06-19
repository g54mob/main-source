using UnityEngine;

public class AirFuelRatioComponent : MonoBehaviour
{
	public const float STOICH_AFR = 14.7f;

	public const float RICH_LIMIT_AFR = 10f;

	public const float LEAN_LIMIT_AFR = 20f;

	[Header("AFR Target")]
	[SerializeField]
	private float targetAFR = 14.7f;

	[Header("Simulation")]
	[SerializeField]
	private float afrResponseSpeed = 1.5f;

	[SerializeField]
	private bool simulateOxygenSensor = true;

	[Header("Mixture Ranges")]
	[SerializeField]
	private float powerMixtureAFR = 12.5f;

	[SerializeField]
	private float economyMixtureAFR = 16f;

	[SerializeField]
	private float coldStartAFR = 8f;

	private EngineComponent _engine;

	public float CurrentAFR { get; private set; } = 14.7f;

	public float Lambda => CurrentAFR / 14.7f;

	public MixtureState Mixture { get; private set; }

	public float FuelFlowRate { get; private set; }

	private void Awake()
	{
		_engine = GetComponent<EngineComponent>();
	}

	private void Update()
	{
		if (!(_engine == null) && _engine.IsRunning)
		{
			CurrentAFR = Mathf.MoveTowards(CurrentAFR, targetAFR, afrResponseSpeed * Time.deltaTime);
			Mixture = ClassifyMixture(CurrentAFR);
			FuelFlowRate = Mathf.Clamp01(14.7f / CurrentAFR);
		}
	}

	public float GetAFREfficiency()
	{
		float num = CurrentAFR - 14.7f;
		float num2 = 2.5f;
		return Mathf.Exp((0f - num * num) / (2f * num2 * num2));
	}

	public void SetTargetAFR(float afr)
	{
		targetAFR = Mathf.Clamp(afr, 10f, 20f);
	}

	public void SetPowerMixture()
	{
		SetTargetAFR(powerMixtureAFR);
	}

	public void SetEconomyMixture()
	{
		SetTargetAFR(economyMixtureAFR);
	}

	public void SetStoich()
	{
		SetTargetAFR(14.7f);
	}

	public void SetColdStart()
	{
		SetTargetAFR(coldStartAFR);
	}

	private MixtureState ClassifyMixture(float afr)
	{
		if (afr < 12.7f)
		{
			return MixtureState.Rich;
		}
		if (afr > 16.7f)
		{
			return MixtureState.Lean;
		}
		return MixtureState.Stoich;
	}
}
