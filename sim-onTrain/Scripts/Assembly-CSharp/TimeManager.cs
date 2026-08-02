using DG.Tweening;
using UnityEngine;
using UnityEngine.AzureSky;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
	public AzureTimeController azureTimeController;

	public Volume volume;

	public Light sunLight;

	[Range(0.1f, 100f)]
	public float timeMultiplier = 30f;

	private DayTime? liveEditSession;

	public TimeSession morningSession = new TimeSession
	{
		startHour = 5f,
		endHour = 12f,
		lightIntensity = 0.8f,
		lightColor = new Color(1f, 0.95f, 0.8f),
		skyColor = new Color(1f, 0.9f, 0.7f),
		equatorColor = new Color(0.9f, 0.85f, 0.7f),
		groundColor = new Color(0.6f, 0.5f, 0.4f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.8f, 0.85f, 0.9f),
		fogDensity = 0.008f,
		postExposure = 0.5f,
		contrast = 0f,
		gamma = 1f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 1f),
		transitionTime = 30f
	};

	public TimeSession afternoonSession = new TimeSession
	{
		startHour = 12f,
		endHour = 16f,
		lightIntensity = 1f,
		lightColor = Color.white,
		skyColor = Color.white,
		equatorColor = new Color(0.9f, 0.9f, 0.9f),
		groundColor = new Color(0.7f, 0.7f, 0.7f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.7f, 0.8f, 0.9f),
		fogDensity = 0.003f,
		postExposure = 1f,
		contrast = 5f,
		gamma = 1f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 1f),
		transitionTime = 20f
	};

	public TimeSession lateAfternoonSession = new TimeSession
	{
		startHour = 16f,
		endHour = 18f,
		lightIntensity = 0.7f,
		lightColor = new Color(1f, 0.85f, 0.6f),
		skyColor = new Color(1f, 0.8f, 0.5f),
		equatorColor = new Color(0.95f, 0.75f, 0.5f),
		groundColor = new Color(0.7f, 0.5f, 0.4f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.9f, 0.7f, 0.5f),
		fogDensity = 0.012f,
		postExposure = 0f,
		contrast = 0f,
		gamma = 1.1f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 1.1f),
		transitionTime = 30f
	};

	public TimeSession eveningSession = new TimeSession
	{
		startHour = 18f,
		endHour = 21f,
		lightIntensity = 0.6f,
		lightColor = new Color(1f, 0.7f, 0.4f),
		skyColor = new Color(1f, 0.6f, 0.3f),
		equatorColor = new Color(0.8f, 0.5f, 0.35f),
		groundColor = new Color(0.5f, 0.35f, 0.3f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.6f, 0.4f, 0.5f),
		fogDensity = 0.018f,
		postExposure = -1f,
		contrast = -10f,
		gamma = 0.9f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 0.9f),
		transitionTime = 40f
	};

	public TimeSession lateEveningSession = new TimeSession
	{
		startHour = 21f,
		endHour = 23.99f,
		lightIntensity = 0.35f,
		lightColor = new Color(0.85f, 0.75f, 0.7f),
		skyColor = new Color(0.5f, 0.35f, 0.35f),
		equatorColor = new Color(0.4f, 0.3f, 0.35f),
		groundColor = new Color(0.3f, 0.25f, 0.25f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.35f, 0.25f, 0.4f),
		fogDensity = 0.022f,
		postExposure = -2f,
		contrast = -12f,
		gamma = 0.85f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 0.85f),
		transitionTime = 35f
	};

	public TimeSession nightSession = new TimeSession
	{
		startHour = 0f,
		endHour = 5f,
		lightIntensity = 0.2f,
		lightColor = new Color(0.7f, 0.8f, 1f),
		skyColor = new Color(0.2f, 0.2f, 0.4f),
		equatorColor = new Color(0.18f, 0.18f, 0.35f),
		groundColor = new Color(0.15f, 0.15f, 0.25f),
		fogMode = FogMode.Exponential,
		fogColor = new Color(0.15f, 0.15f, 0.3f),
		fogDensity = 0.025f,
		postExposure = -3f,
		contrast = -15f,
		gamma = 0.8f,
		gammaRGBW = new Vector4(0f, 0f, 0f, 0.8f),
		transitionTime = 30f
	};

	public DayTime currentTimeSession;

	public UnityEvent OnDayCompleted = new UnityEvent();

	private ColorAdjustments colorAdjustments;

	private LiftGammaGain liftGammaGain;

	private DayTime previousTimeSession;

	private TimeSession currentSession;

	private bool isInitialized;

	private bool IsLiveEditActive => liveEditSession.HasValue;

	public string CurrentTimeDisplay
	{
		get
		{
			if (!(azureTimeController != null))
			{
				return "N/A";
			}
			return $"{azureTimeController.GetTimeline():F2}h";
		}
	}

	public string SessionInfo
	{
		get
		{
			if (currentSession == null)
			{
				return "N/A";
			}
			return currentSession.TimeRangeInfo;
		}
	}

	private void StopLiveEdit()
	{
		liveEditSession = null;
		Debug.Log("Live Edit Mode deactivated");
	}

	private void TestMorning()
	{
		TestSession(morningSession, DayTime.Morning);
	}

	private void TestAfternoon()
	{
		TestSession(afternoonSession, DayTime.Afternoon);
	}

	private void TestLateAfternoon()
	{
		TestSession(lateAfternoonSession, DayTime.LateAfternoon);
	}

	private void TestEvening()
	{
		TestSession(eveningSession, DayTime.Evening);
	}

	private void TestLateEvening()
	{
		TestSession(lateEveningSession, DayTime.LateEvening);
	}

	private void TestNight()
	{
		TestSession(nightSession, DayTime.Night);
	}

	private void TestCurrentSession()
	{
		if (azureTimeController == null)
		{
			Debug.LogWarning("Azure Time Controller bulunamadı!");
			return;
		}
		float timeline = azureTimeController.GetTimeline();
		TimeSession timeSession = null;
		DayTime dayTime = DayTime.Morning;
		if (morningSession.IsInTimeRange(timeline))
		{
			timeSession = morningSession;
			dayTime = DayTime.Morning;
		}
		else if (afternoonSession.IsInTimeRange(timeline))
		{
			timeSession = afternoonSession;
			dayTime = DayTime.Afternoon;
		}
		else if (lateAfternoonSession.IsInTimeRange(timeline))
		{
			timeSession = lateAfternoonSession;
			dayTime = DayTime.LateAfternoon;
		}
		else if (eveningSession.IsInTimeRange(timeline))
		{
			timeSession = eveningSession;
			dayTime = DayTime.Evening;
		}
		else if (lateEveningSession.IsInTimeRange(timeline))
		{
			timeSession = lateEveningSession;
			dayTime = DayTime.LateEvening;
		}
		else
		{
			timeSession = nightSession;
			dayTime = DayTime.Night;
		}
		float num = (timeSession.startHour + timeSession.endHour) / 2f;
		if (timeSession.startHour > timeSession.endHour)
		{
			float num2 = 24f - timeSession.startHour + timeSession.endHour;
			num = timeSession.startHour + num2 / 2f;
			if (num >= 24f)
			{
				num -= 24f;
			}
		}
		azureTimeController.SetTimeline(num);
		currentTimeSession = dayTime;
		currentSession = timeSession;
		if (volume != null)
		{
			volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
			volume.profile.TryGet<LiftGammaGain>(out liftGammaGain);
		}
		ApplyTimeSettings(timeSession, 0f);
		ForceUpdatePostProcess();
		Debug.Log($"Testing {dayTime} session at {num:F1}h");
	}

	private void TestSession(TimeSession session, DayTime sessionType)
	{
		if (azureTimeController == null)
		{
			Debug.LogWarning("Azure Time Controller bulunamadı!");
			return;
		}
		float num = (session.startHour + session.endHour) / 2f;
		if (session.startHour > session.endHour)
		{
			float num2 = 24f - session.startHour + session.endHour;
			num = session.startHour + num2 / 2f;
			if (num >= 24f)
			{
				num -= 24f;
			}
		}
		azureTimeController.SetTimeline(num);
		currentTimeSession = sessionType;
		currentSession = session;
		liveEditSession = sessionType;
		if (volume != null)
		{
			volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
			volume.profile.TryGet<LiftGammaGain>(out liftGammaGain);
		}
		ApplyTimeSettings(session, 0f);
		ForceUpdatePostProcess();
		Debug.Log($"\ud83d\udd34 Live Edit Mode: {sessionType} at {num:F1}h - Changes will auto-apply");
	}

	private void OnMorningSessionChanged()
	{
		if (liveEditSession == DayTime.Morning)
		{
			ApplyLiveEditChanges(morningSession);
		}
	}

	private void OnAfternoonSessionChanged()
	{
		if (liveEditSession == DayTime.Afternoon)
		{
			ApplyLiveEditChanges(afternoonSession);
		}
	}

	private void OnLateAfternoonSessionChanged()
	{
		if (liveEditSession == DayTime.LateAfternoon)
		{
			ApplyLiveEditChanges(lateAfternoonSession);
		}
	}

	private void OnEveningSessionChanged()
	{
		if (liveEditSession == DayTime.Evening)
		{
			ApplyLiveEditChanges(eveningSession);
		}
	}

	private void OnLateEveningSessionChanged()
	{
		if (liveEditSession == DayTime.LateEvening)
		{
			ApplyLiveEditChanges(lateEveningSession);
		}
	}

	private void OnNightSessionChanged()
	{
		if (liveEditSession == DayTime.Night)
		{
			ApplyLiveEditChanges(nightSession);
		}
	}

	private void ApplyLiveEditChanges(TimeSession session)
	{
		if (volume != null)
		{
			volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
			volume.profile.TryGet<LiftGammaGain>(out liftGammaGain);
		}
		ApplyTimeSettings(session, 0f);
		ForceUpdatePostProcess();
	}

	private void Awake()
	{
		if (volume != null)
		{
			volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
			volume.profile.TryGet<LiftGammaGain>(out liftGammaGain);
		}
	}

	private void Start()
	{
		CheckTimeSession();
		if (currentSession != null)
		{
			ApplyTimeSettings(currentSession, 0f);
			ForceUpdatePostProcess();
			isInitialized = true;
			previousTimeSession = currentTimeSession;
			Debug.Log($"TimeManager initialized: {currentTimeSession} session applied immediately");
		}
	}

	private void Update()
	{
		CheckTimeSession();
		SetTime();
	}

	private void OnDisable()
	{
		DOTween.Kill(this);
		RenderSettings.ambientMode = AmbientMode.Trilight;
		RenderSettings.ambientSkyColor = afternoonSession.skyColor;
		RenderSettings.ambientEquatorColor = afternoonSession.equatorColor;
		RenderSettings.ambientGroundColor = afternoonSession.groundColor;
		RenderSettings.fog = true;
		RenderSettings.fogMode = afternoonSession.fogMode;
		RenderSettings.fogColor = afternoonSession.fogColor;
		RenderSettings.fogDensity = afternoonSession.fogDensity;
		if (colorAdjustments != null)
		{
			colorAdjustments.postExposure.value = afternoonSession.postExposure;
			colorAdjustments.contrast.value = afternoonSession.contrast;
		}
		if (liftGammaGain != null)
		{
			liftGammaGain.gamma.value = afternoonSession.gammaRGBW;
		}
	}

	private void SetTime()
	{
		if (currentTimeSession == previousTimeSession)
		{
			return;
		}
		if (currentSession != null)
		{
			if (!isInitialized)
			{
				float timeline = azureTimeController.GetTimeline();
				Debug.Log($"Initial session set: saat: {timeline:F2}h ({GetTimeString(timeline)}) - {currentTimeSession} session (no transition)");
				ApplyTimeSettings(currentSession, 0f);
				isInitialized = true;
			}
			else
			{
				float transitionDuration = CalculateRealTransitionDuration(currentSession.transitionTime);
				float timeline2 = azureTimeController.GetTimeline();
				Debug.Log($"Transition started: saat: {timeline2:F2}h ({GetTimeString(timeline2)}) - {currentTimeSession} session");
				ApplyTimeSettings(currentSession, transitionDuration, timeline2);
				ForceUpdatePostProcess();
			}
		}
		previousTimeSession = currentTimeSession;
		if (currentTimeSession == DayTime.Morning)
		{
			OnDayCompleted.Invoke();
		}
	}

	private string GetTimeString(float hours)
	{
		int num = (int)hours;
		int num2 = (int)((hours - (float)num) * 60f);
		return $"{num:D2}:{num2:D2}";
	}

	private float CalculateRealTransitionDuration(float gameMinutes)
	{
		if (TrainGameManager.Instance == null)
		{
			Debug.LogWarning("TrainGameManager bulunamadı");
			return gameMinutes;
		}
		float num = TrainGameManager.Instance.azureTimeMultiplier / 60f;
		return gameMinutes * num * 0.6f;
	}

	private void ApplyTimeSettings(TimeSession session, float transitionDuration, float startTime = -1f)
	{
		DOTween.Kill(this);
		RenderSettings.ambientMode = AmbientMode.Trilight;
		RenderSettings.fog = true;
		RenderSettings.fogMode = session.fogMode;
		if (transitionDuration > 0f)
		{
			DOTween.To(() => sunLight.intensity, delegate(float x)
			{
				sunLight.intensity = x;
			}, session.lightIntensity, transitionDuration).SetTarget(this);
			DOTween.To(() => sunLight.color, delegate(Color x)
			{
				sunLight.color = x;
			}, session.lightColor, transitionDuration).SetTarget(this);
			DOTween.To(() => RenderSettings.ambientSkyColor, delegate(Color x)
			{
				RenderSettings.ambientSkyColor = x;
			}, session.skyColor, transitionDuration).SetTarget(this);
			DOTween.To(() => RenderSettings.ambientEquatorColor, delegate(Color x)
			{
				RenderSettings.ambientEquatorColor = x;
			}, session.equatorColor, transitionDuration).SetTarget(this);
			DOTween.To(() => RenderSettings.ambientGroundColor, delegate(Color x)
			{
				RenderSettings.ambientGroundColor = x;
			}, session.groundColor, transitionDuration).SetTarget(this);
			DOTween.To(() => RenderSettings.fogColor, delegate(Color x)
			{
				RenderSettings.fogColor = x;
			}, session.fogColor, transitionDuration).SetTarget(this);
			DOTween.To(() => RenderSettings.fogDensity, delegate(float x)
			{
				RenderSettings.fogDensity = x;
			}, session.fogDensity, transitionDuration).SetTarget(this).OnComplete(delegate
			{
				if (startTime >= 0f && azureTimeController != null)
				{
					float timeline = azureTimeController.GetTimeline();
					float num = timeline - startTime;
					if (num < 0f)
					{
						num += 24f;
					}
					float num2 = num * 60f;
					Debug.Log($"Transition completed: saat: {timeline:F2}h ({GetTimeString(timeline)}) - Oyunda geçen süre: {num2:F1} dakika ({num:F3} saat)");
				}
			});
			if (colorAdjustments != null)
			{
				DOTween.To(() => colorAdjustments.postExposure.value, delegate(float x)
				{
					colorAdjustments.postExposure.value = x;
				}, session.postExposure, transitionDuration).SetTarget(this);
				DOTween.To(() => colorAdjustments.contrast.value, delegate(float x)
				{
					colorAdjustments.contrast.value = x;
				}, session.contrast, transitionDuration).SetTarget(this);
			}
			if (liftGammaGain != null)
			{
				Vector4 currentGamma = liftGammaGain.gamma.value;
				Vector4 gammaRGBW = session.gammaRGBW;
				DOTween.To(() => currentGamma, delegate(Vector4 x)
				{
					currentGamma = x;
					liftGammaGain.gamma.value = currentGamma;
				}, gammaRGBW, transitionDuration).SetTarget(this);
			}
		}
		else
		{
			sunLight.intensity = session.lightIntensity;
			sunLight.color = session.lightColor;
			RenderSettings.ambientSkyColor = session.skyColor;
			RenderSettings.ambientEquatorColor = session.equatorColor;
			RenderSettings.ambientGroundColor = session.groundColor;
			RenderSettings.fogColor = session.fogColor;
			RenderSettings.fogDensity = session.fogDensity;
			if (colorAdjustments != null)
			{
				colorAdjustments.postExposure.value = session.postExposure;
				colorAdjustments.contrast.value = session.contrast;
			}
			if (liftGammaGain != null)
			{
				liftGammaGain.gamma.value = session.gammaRGBW;
			}
		}
	}

	private void ForceUpdatePostProcess()
	{
		if (volume != null)
		{
			volume.weight = volume.weight;
		}
	}

	private void CheckTimeSession()
	{
		float timeline = azureTimeController.GetTimeline();
		if (morningSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.Morning;
			currentSession = morningSession;
		}
		else if (afternoonSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.Afternoon;
			currentSession = afternoonSession;
		}
		else if (lateAfternoonSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.LateAfternoon;
			currentSession = lateAfternoonSession;
		}
		else if (eveningSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.Evening;
			currentSession = eveningSession;
		}
		else if (lateEveningSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.LateEvening;
			currentSession = lateEveningSession;
		}
		else if (nightSession.IsInTimeRange(timeline))
		{
			currentTimeSession = DayTime.Night;
			currentSession = nightSession;
		}
	}

	public TimeSession GetCurrentSession()
	{
		return currentSession;
	}

	public void ForceTransitionToSession(DayTime targetTime)
	{
		TimeSession sessionByTime = GetSessionByTime(targetTime);
		if (sessionByTime != null)
		{
			float num = ((azureTimeController != null) ? azureTimeController.GetTimeline() : (-1f));
			float transitionDuration = CalculateRealTransitionDuration(sessionByTime.transitionTime);
			if (num >= 0f)
			{
				Debug.Log($"Force Transition started: saat: {num:F2}h ({GetTimeString(num)}) - {targetTime} session");
			}
			ApplyTimeSettings(sessionByTime, transitionDuration, num);
			currentTimeSession = targetTime;
			currentSession = sessionByTime;
			ForceUpdatePostProcess();
		}
	}

	private TimeSession GetSessionByTime(DayTime timeType)
	{
		return timeType switch
		{
			DayTime.Morning => morningSession, 
			DayTime.Afternoon => afternoonSession, 
			DayTime.LateAfternoon => lateAfternoonSession, 
			DayTime.Evening => eveningSession, 
			DayTime.LateEvening => lateEveningSession, 
			DayTime.Night => nightSession, 
			_ => null, 
		};
	}
}
