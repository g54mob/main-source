using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	private readonly int UNSCALED_TIME = Shader.PropertyToID("_UNSCALED_TIME");

	[SerializeField]
	private AnimationCurve _dayNightCycle;

	[SerializeField]
	private RangedFloat _dayRange = new RangedFloat(0.5f, 1f);

	[SerializeField]
	private bool _forceMiddayStart = true;

	[SerializeField]
	private CircadianVisuals _environmentVisuals;

	[SerializeField]
	private int _hoursInDay = 24;

	[Header("Night Light Settings")]
	[SerializeField]
	private float _sleepTimeScale = 20f;

	[SerializeField]
	private Gradient _nightLightColor;

	[SerializeField]
	private RangedFloat _nightLightActive = new RangedFloat(0.5f, 1f);

	[SerializeField]
	private float _nightLightTransitionTime = 0.1f;

	[SerializeField]
	private RangedFloat _nightLightDelayRange = new RangedFloat(0.1f, 0.25f);

	[SerializeField]
	[Range(0f, 100f)]
	private int _nightLightDelayChance;

	private float _cycleDuration;

	private float _dayDuration;

	private float _nightDuration;

	private float _middayValue;

	private bool _hasReachedMidday;

	private List<NightLight> _nightLights;

	private bool _nightLightsEnabled;

	private bool _applySleepSpeed;

	public List<Day> Days { get; } = new List<Day>();

	public Day CurrentDay { get; private set; }

	public float CurrentPlayTime { get; private set; }

	public float LastSavedPlayTime { get; set; }

	public CircadianVisuals CycleVisuals => _environmentVisuals;

	public bool Initialized { get; private set; }

	public float DeltaTime { get; private set; }

	public static float CycleDuration
	{
		get
		{
			if (!GameManager.TimeManager)
			{
				return 0f;
			}
			return GameManager.TimeManager._cycleDuration;
		}
	}

	public static float DayDuration
	{
		get
		{
			if (!GameManager.TimeManager)
			{
				return 0f;
			}
			return GameManager.TimeManager._dayDuration;
		}
	}

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.NighttimeStarted, OnNightStart);
	}

	public void Initialize()
	{
		InitializeCycleData();
		NextDay();
		InitializeNightLights();
	}

	public void Restore(DayPersistentData[] daysToRestore)
	{
		int num = daysToRestore.Length;
		InitializeCycleData();
		Days.Clear();
		foreach (DayPersistentData dayPersistentData in daysToRestore)
		{
			Days.Add(dayPersistentData.ReturnRestored(_dayDuration, _nightDuration));
		}
		List<Day> days = Days;
		CurrentDay = days[days.Count - 1];
		CurrentDay.Report.Start();
		CurrentDay.ProgressCycle(Time.deltaTime);
		_hasReachedMidday = 1 < num || _dayDuration < CurrentDay.CurrentTime || _dayNightCycle.Evaluate(CurrentDay.CurrentTime) == _middayValue;
		InitializeNightLights();
	}

	private void InitializeNightLights()
	{
		_nightLights = new List<NightLight>();
		_nightLightsEnabled = ReturnEvaluateNightLightsEnabled();
		Initialized = true;
	}

	private void Update()
	{
		Shader.SetGlobalFloat(UNSCALED_TIME, Time.unscaledTime);
		if (!Initialized)
		{
			return;
		}
		TrackPlayTime();
		if (CurrentDay != null && UIManager.State != UIState.GameTimePaused)
		{
			if (CurrentDay.DayTime == Day.E_DayTime.Night)
			{
				if (CanApplySleepSpeed())
				{
					_applySleepSpeed = true;
				}
			}
			else
			{
				_applySleepSpeed = false;
			}
			DeltaTime = (_applySleepSpeed ? (Time.unscaledDeltaTime * _sleepTimeScale) : Time.deltaTime);
			if (CurrentDay.ProgressCycle(DeltaTime))
			{
				NextDay();
			}
		}
		bool flag = ReturnEvaluateNightLightsEnabled();
		if (flag != _nightLightsEnabled)
		{
			_nightLightsEnabled = flag;
			StartCoroutine(SetNightLightsEnabledRoutine(_nightLightsEnabled));
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.NighttimeStarted, OnNightStart);
	}

	private void InitializeCycleData(float increment = 1f)
	{
		if (_dayNightCycle.length < 2)
		{
			return;
		}
		float num = _dayNightCycle[0].time;
		float time = _dayNightCycle[_dayNightCycle.length - 1].time;
		float num2 = float.NaN;
		float num3 = float.NaN;
		_cycleDuration = time - num;
		_middayValue = 0f;
		for (; num <= time; num += increment)
		{
			float num4 = _dayNightCycle.Evaluate(num);
			if (_dayRange.ReturnContainsValue(num4))
			{
				if (float.IsNaN(num2))
				{
					num2 = num;
				}
			}
			else if (float.IsNaN(num3))
			{
				num3 = num - increment;
			}
			if (_middayValue < num4)
			{
				_middayValue = num4;
			}
		}
		_dayDuration = num3 - num2;
		_nightDuration = _cycleDuration - _dayDuration;
	}

	private void OnNightStart(GameEvent gameEvent)
	{
		GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.DailyReportAvailableNotification, new DayObjectOfInterest(Days.Count - 1));
	}

	public void NextDay()
	{
		if (CurrentDay != null)
		{
			CurrentDay.Finish();
			DayEvent.Dispatch(GameEventType.DayEnded, CurrentDay, Days);
		}
		CurrentDay = new Day(_dayDuration, _nightDuration, _hoursInDay);
		Days.Add(CurrentDay);
		DayEvent.Dispatch(GameEventType.DayStarted, CurrentDay, Days);
	}

	public void RegisterNightLight(NightLight nightlight)
	{
		if (_nightLights.AddUnique(nightlight))
		{
			nightlight.SetColor(_nightLightColor.Evaluate(Random.Range(0, 1)));
			nightlight.SetEnabled(_nightLightsEnabled);
		}
	}

	public void UnregiserNightLight(NightLight nightLight)
	{
		if (_nightLights != null && _nightLights.Remove(nightLight))
		{
			nightLight.SetEnabled(enabled: false);
		}
	}

	private IEnumerator SetNightLightsEnabledRoutine(bool enabled)
	{
		foreach (NightLight nightLight in _nightLights)
		{
			nightLight.SetEnabled(enabled, _nightLightTransitionTime);
			if (Random.Range(0, 100) < _nightLightDelayChance)
			{
				yield return new WaitForSeconds(_nightLightDelayRange.ReturnRandom());
			}
		}
	}

	private void TrackPlayTime()
	{
		CurrentPlayTime += Time.unscaledDeltaTime;
	}

	public float ReturnTotalTimePlayed()
	{
		return CurrentPlayTime + LastSavedPlayTime;
	}

	public string ReturnTimeInHoursMinutes(float timeToConvert, bool includeUnits = true)
	{
		int num = Mathf.FloorToInt(timeToConvert / 3600f);
		int num2 = Mathf.FloorToInt((timeToConvert - (float)(num * 3600)) / 60f);
		if (includeUnits)
		{
			return $"{num}h:{num2:00}m";
		}
		return $"{num}:{num2:00}";
	}

	public string ReturnTimeInHoursMinutes(bool includeUnits = true)
	{
		return ReturnTimeInHoursMinutes(ReturnTotalTimePlayed(), includeUnits);
	}

	public float ReturnDayNightBlend()
	{
		float num = _dayNightCycle.Evaluate(CurrentDay.CurrentTime);
		if (_forceMiddayStart && !_hasReachedMidday)
		{
			_hasReachedMidday = num == _middayValue;
			num = _middayValue;
		}
		AudioManager.SetDayTimeParameter(num);
		return num;
	}

	private bool ReturnEvaluateNightLightsEnabled()
	{
		return _nightLightActive.ReturnContainsValue(_dayNightCycle.Evaluate(CurrentDay.CurrentTime));
	}

	private bool CanApplySleepSpeed(float threshold = 0.75f)
	{
		List<Agent> agents = Community.PlayerCommunity.Agents;
		float num = 0f;
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.CurrentActivity == Activity.Sleeping)
			{
				num += 1f;
			}
		}
		return threshold < num / (float)agents.Count;
	}

	public static float GetDeltaTime()
	{
		if (TryReturnInstance(out var instance))
		{
			return instance.DeltaTime;
		}
		return Time.deltaTime;
	}

	public static bool ReturnIsDayTime()
	{
		if (TryReturnInstance(out var instance) && instance.CurrentDay != null)
		{
			return instance.CurrentDay.DayTime == Day.E_DayTime.Day;
		}
		return true;
	}

	private static bool TryReturnInstance(out TimeManager instance)
	{
		instance = GameManager.TimeManager;
		return instance != null;
	}
}
