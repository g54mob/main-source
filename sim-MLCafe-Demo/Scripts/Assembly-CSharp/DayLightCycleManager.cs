using UnityEngine;

public class DayLightCycleManager : MonoBehaviour
{
	[SerializeField]
	private Light mainLight;

	[SerializeField]
	private Gradient sunGradientOverTime;

	[SerializeField]
	private DayLightProperty sunTemperature;

	[SerializeField]
	private DayLightProperty sunIntensity;

	[SerializeField]
	private Gradient fogColorOverTime;

	[SerializeField]
	private DayLightProperty fogIntensity;

	[SerializeField]
	private DayLightProperty skyInterpolation;

	[SerializeField]
	private bool useRealtimeUpdate;

	[SerializeField]
	private AnimationCurve lanternActivationOverTime;

	private WorldTime worldTime;

	private static DayLightCycleManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		worldTime = WorldTime.instance;
	}

	private void Update()
	{
		float time = (useRealtimeUpdate ? Mathf.InverseLerp(0f, WorldTime.GetTotalAmountOfTicks(), WorldTime.GetCurrentTick()) : WorldTime.GetDaytimeAlpha());
		mainLight.color = sunGradientOverTime.Evaluate(time);
		mainLight.colorTemperature = Mathf.Lerp(sunTemperature.min, sunTemperature.max, sunTemperature.curveOverTime.Evaluate(time));
		mainLight.intensity = Mathf.Lerp(sunIntensity.min, sunIntensity.max, sunIntensity.curveOverTime.Evaluate(time));
		RenderSettings.fogColor = fogColorOverTime.Evaluate(time);
		RenderSettings.fogDensity = Mathf.Lerp(fogIntensity.min, fogIntensity.max, fogIntensity.curveOverTime.Evaluate(time));
		RenderSettings.skybox.SetFloat("_Sky", Mathf.Lerp(skyInterpolation.min, skyInterpolation.max, skyInterpolation.curveOverTime.Evaluate(time)));
	}

	public static float GetLanternLightEvaluation()
	{
		return instance.lanternActivationOverTime.Evaluate(WorldTime.GetDaytimeAlpha());
	}
}
