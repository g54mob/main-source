using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeDisplay : MonoBehaviour
{
	public GameObject timeCircle;

	public GameObject timeDisplay;

	public GameObject advanceTimeToEndOfWorkDayButton;

	public GameObject advanceTimeToStartOfWorkDayButton;

	public GameObject advanceTimeToNightAtHomeButton;

	public GameObject advanceTimeToDayAtHomeButton;

	public GameObject tutorialArrowGraphic;

	private TutorialCallback currentTutorialCallback;

	private TextMeshPro timeText;

	private static StringBuilder dateBuilder = new StringBuilder();

	private static int workEndHour = 17;

	private static int workStartHour = 9;

	private static int homeEveningHour = 18;

	private static int homeNightHourStart = 20;

	private static int homeMorningHourStart = 7;

	private ClockState currentClockState;

	private List<TimeLockReason> timeLocks = new List<TimeLockReason>();

	private float postEVTarget = -1f;

	private float postEVDefault;

	private Color colorFilterTarget = new Color(0.7573529f, 0.7991887f, 1f);

	private Color colorFilterDefault = Color.white;

	private Coroutine currentDayEase;

	private Coroutine currentNightEase;

	private ColorGrading colorGradingRef;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private DogRegistration dogRegRef;

	private GlobalClock globalClockRef;

	private static ObjectRegistration objRegRef;

	private void Awake()
	{
		objRegRef = ObjectRegistration.GetRegistrationScript();
		globalClockRef = objRegRef.GetGlobalComponent<GlobalClock>(GlobalObject.GLOBAL_CLOCK);
		dogRegRef = objRegRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		timeText = timeDisplay.GetComponent<TextMeshPro>();
		penFocusRef.GetPostFXProfile().TryGetSettings<ColorGrading>(out colorGradingRef);
		tutorialArrowGraphic.SetActive(value: false);
		globalClockRef.timeDisplayRef = this;
		CheckClockStateUpdate(fromLoad: true);
	}

	private void Update()
	{
		UpdateTime();
	}

	public void SetTimeAdvancementAllowed(bool val, TimeLockReason lockReason)
	{
		if (val)
		{
			if (timeLocks.Contains(lockReason))
			{
				timeLocks.Remove(lockReason);
				if (timeLocks.Count == 0)
				{
					advanceTimeToDayAtHomeButton.GetComponent<CoreButton>().UnlockScale();
					advanceTimeToNightAtHomeButton.GetComponent<CoreButton>().UnlockScale();
					advanceTimeToEndOfWorkDayButton.GetComponent<CoreButton>().UnlockScale();
					advanceTimeToStartOfWorkDayButton.GetComponent<CoreButton>().UnlockScale();
				}
			}
		}
		else if (!timeLocks.Contains(lockReason))
		{
			timeLocks.Add(lockReason);
			advanceTimeToDayAtHomeButton.GetComponent<CoreButton>().LockScale();
			advanceTimeToNightAtHomeButton.GetComponent<CoreButton>().LockScale();
			advanceTimeToEndOfWorkDayButton.GetComponent<CoreButton>().LockScale();
			advanceTimeToStartOfWorkDayButton.GetComponent<CoreButton>().LockScale();
		}
	}

	public void RequestTutorialArrow(TutorialCallback newCallback)
	{
		tutorialArrowGraphic.SetActive(value: true);
		currentTutorialCallback = newCallback;
	}

	private void CheckTutorialTimeAdvancementCallback()
	{
		if (currentTutorialCallback != null)
		{
			tutorialArrowGraphic.SetActive(value: false);
			TutorialCallback tutorialCallback = currentTutorialCallback;
			currentTutorialCallback = null;
			tutorialCallback();
		}
	}

	public void OnAdvanceToStartOfWorkDayButtonClicked()
	{
		CheckTutorialTimeAdvancementCallback();
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		int days = currentTimespan.GetDays();
		int hours = currentTimespan.GetHours();
		hours = workStartHour;
		TimeSpan currentTimespan2 = new TimeSpan(0f, 0, hours, days, currentTimespan.GetMonths(), currentTimespan.GetYears());
		globalClockRef.SetCurrentTimespan(currentTimespan2);
	}

	public void OnAdvanceToEndOfWorkDayButtonClicked()
	{
		CheckTutorialTimeAdvancementCallback();
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		int days = currentTimespan.GetDays();
		int hours = currentTimespan.GetHours();
		hours = workEndHour;
		TimeSpan currentTimespan2 = new TimeSpan(0f, 0, hours, days, currentTimespan.GetMonths(), currentTimespan.GetYears());
		globalClockRef.SetCurrentTimespan(currentTimespan2);
	}

	public void OnAdvanceToNightAtHomeButtonClicked()
	{
		CheckTutorialTimeAdvancementCallback();
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		int days = currentTimespan.GetDays();
		int hours = currentTimespan.GetHours();
		hours = homeNightHourStart;
		TimeSpan currentTimespan2 = new TimeSpan(0f, 0, hours, days, currentTimespan.GetMonths(), currentTimespan.GetYears());
		globalClockRef.SetCurrentTimespan(currentTimespan2);
	}

	public void OnAdvanceToDayAtHomeButtonClicked()
	{
		CheckTutorialTimeAdvancementCallback();
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		int num = currentTimespan.GetDays();
		int hours = currentTimespan.GetHours();
		if (hours >= homeMorningHourStart)
		{
			num++;
		}
		hours = homeMorningHourStart;
		TimeSpan currentTimespan2 = new TimeSpan(0f, 0, hours, num, currentTimespan.GetMonths(), currentTimespan.GetYears());
		globalClockRef.SetCurrentTimespan(currentTimespan2);
	}

	private void UpdateTime()
	{
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		timeText.text = GetFormattedTime(currentTimespan);
		UpdateTimeCircle(currentTimespan);
		CheckClockStateUpdate();
	}

	private void FinishEases()
	{
		if (currentDayEase != null)
		{
			OnDayEaseFinished();
		}
		if (currentNightEase != null)
		{
			OnNightEaseFinished();
		}
	}

	public float GetClockTimescale()
	{
		switch (currentClockState)
		{
		case ClockState.WORK_HOURS:
			return 0f;
		case ClockState.WORK_END:
			return 0f;
		case ClockState.HOME_EVENING:
			return 0f;
		case ClockState.HOME_NIGHT:
			return 0f;
		case ClockState.HOME_MORNING:
			return 0f;
		case ClockState.TRANSITIONING:
			return 10f;
		default:
			return 1f;
		}
	}

	private void CheckClockStateUpdate(bool fromLoad = false)
	{
		int hour = globalClockRef.GetHour();
		ClockState clockState = currentClockState;
		clockState = ((hour == homeMorningHourStart) ? ClockState.HOME_MORNING : ((hour < workStartHour || hour >= workEndHour) ? ((hour == workEndHour) ? ClockState.WORK_END : ((hour == homeEveningHour) ? ClockState.HOME_EVENING : ((hour != homeNightHourStart) ? ClockState.TRANSITIONING : ClockState.HOME_NIGHT))) : ClockState.WORK_HOURS));
		if (clockState == currentClockState && !fromLoad)
		{
			return;
		}
		if (fromLoad)
		{
			if (clockState == ClockState.HOME_NIGHT)
			{
				SetColorGradingNightValues();
			}
			else
			{
				SetColorGradingDayValues();
			}
		}
		SetClockState(clockState);
	}

	public void SetClockState(ClockState newClockState)
	{
		currentClockState = newClockState;
		switch (newClockState)
		{
		case ClockState.HOME_EVENING:
			OnEnterHomeEvening();
			break;
		case ClockState.HOME_NIGHT:
			OnEnterHomeNight();
			break;
		case ClockState.HOME_MORNING:
			OnEnterHomeMorning();
			break;
		}
	}

	private void OnEnterHomeEvening()
	{
		advanceTimeToEndOfWorkDayButton.SetActive(value: false);
		advanceTimeToNightAtHomeButton.SetActive(value: true);
		advanceTimeToDayAtHomeButton.SetActive(value: false);
		advanceTimeToStartOfWorkDayButton.SetActive(value: false);
	}

	private void OnEnterHomeNight()
	{
		advanceTimeToEndOfWorkDayButton.SetActive(value: false);
		advanceTimeToNightAtHomeButton.SetActive(value: false);
		advanceTimeToDayAtHomeButton.SetActive(value: true);
		advanceTimeToStartOfWorkDayButton.SetActive(value: false);
		OnNight();
	}

	private void OnEnterHomeMorning()
	{
		advanceTimeToEndOfWorkDayButton.SetActive(value: false);
		advanceTimeToNightAtHomeButton.SetActive(value: false);
		advanceTimeToDayAtHomeButton.SetActive(value: false);
		advanceTimeToStartOfWorkDayButton.SetActive(value: false);
		OnDay();
	}

	private void OnNight(bool doEase = true)
	{
		FinishEases();
		if (doEase)
		{
			currentNightEase = StartCoroutine(NightEase());
		}
		else
		{
			OnNightEaseFinished();
		}
	}

	private void OnDay(bool doEase = true)
	{
		FinishEases();
		if (guiRef == null)
		{
			guiRef = objRegRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		guiRef.DisableBG(LockReason.COCOON_HATCHING, blur: false);
		if (doEase)
		{
			currentDayEase = StartCoroutine(DayEase());
		}
		else
		{
			OnDayEaseFinished();
		}
	}

	private IEnumerator NightEase()
	{
		SetTimeAdvancementAllowed(val: false, TimeLockReason.NIGHT_EASE);
		colorGradingRef.active = true;
		float easeTime = 1f;
		float currentTime = 0f;
		colorGradingRef.postExposure.value = postEVDefault;
		while (currentTime < easeTime)
		{
			yield return new WaitForEndOfFrame();
			currentTime += Time.deltaTime;
			float percentageOfRange = MathUtil.GetPercentageOfRange(currentTime, 0f, easeTime);
			colorGradingRef.colorFilter.value = Color.Lerp(colorFilterDefault, colorFilterTarget, percentageOfRange);
			colorGradingRef.postExposure.value = MathUtil.GetDampPercentage(currentTime, 0f, easeTime, postEVDefault, postEVTarget);
		}
		List<GameObject> allDogs = dogRegRef.GetAllInWorldOwnedDogs();
		for (int i = 0; i < allDogs.Count; i++)
		{
			if (!(allDogs[i] == null))
			{
				yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
				allDogs[i].GetComponent<CocoonController>().EnterCocoon();
			}
		}
		OnNightEaseFinished();
	}

	private IEnumerator DayEase()
	{
		SetTimeAdvancementAllowed(val: false, TimeLockReason.DAY_EASE);
		float easeTime = 1f;
		float currentTime = 0f;
		colorGradingRef.postExposure.value = postEVTarget;
		while (currentTime < easeTime)
		{
			yield return new WaitForEndOfFrame();
			currentTime += Time.deltaTime;
			float percentageOfRange = MathUtil.GetPercentageOfRange(currentTime, 0f, easeTime);
			colorGradingRef.colorFilter.value = Color.Lerp(colorFilterTarget, colorFilterDefault, percentageOfRange);
			colorGradingRef.postExposure.value = MathUtil.GetDampPercentage(currentTime, 0f, easeTime, postEVTarget, postEVDefault);
		}
		List<GameObject> cocoons = objRegRef.GetAllObjectsForTag(TagsEnum.COCOON);
		for (int i = 0; i < cocoons.Count; i++)
		{
			if (!(cocoons[i] == null))
			{
				yield return StartCoroutine(SubHatchRoutine(cocoons[i]));
			}
		}
		yield return new WaitForSeconds(1f);
		OnDayEaseFinished();
	}

	private IEnumerator SubHatchRoutine(GameObject cocoon)
	{
		WaitForSeconds hatchWait = new WaitForSeconds(2f);
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		PenFocus focusRef = Camera.main.GetComponent<PenFocus>();
		focusRef.RequestCocoonHatchCam(cocoon);
		Cocoon cocoonRef = cocoon.GetComponent<Cocoon>();
		cocoonRef.StartHatchRoutine();
		Debug.LogWarning("This will probably not work!");
		while (cocoonRef.IsCurrentlyHatching())
		{
			yield return frameWait;
		}
		yield return hatchWait;
		cocoonRef.CreateHatchGUI();
		focusRef.ClearFollowCam(fromRoomFocus: false, playSounds: false);
		while (cocoonRef != null && cocoonRef.HatchUIShowing())
		{
			yield return frameWait;
		}
	}

	private void SetColorGradingNightValues()
	{
		colorGradingRef.postExposure.value = postEVTarget;
		colorGradingRef.colorFilter.value = colorFilterTarget;
	}

	private void SetColorGradingDayValues()
	{
		colorGradingRef.postExposure.value = postEVDefault;
		colorGradingRef.colorFilter.value = colorFilterDefault;
		colorGradingRef.active = false;
	}

	private void OnNightEaseFinished()
	{
		currentNightEase = null;
		SetColorGradingNightValues();
		SetTimeAdvancementAllowed(val: true, TimeLockReason.NIGHT_EASE);
	}

	private void OnDayEaseFinished()
	{
		currentDayEase = null;
		SetColorGradingDayValues();
		TimeSpan currentTimespan = globalClockRef.GetCurrentTimespan();
		TimeSpan currentTimespan2 = new TimeSpan(0f, 0, workStartHour, currentTimespan.GetDays(), currentTimespan.GetMonths(), currentTimespan.GetYears());
		globalClockRef.SetCurrentTimespan(currentTimespan2);
		SetTimeAdvancementAllowed(val: true, TimeLockReason.DAY_EASE);
	}

	private void UpdateTimeCircle(TimeSpan t)
	{
		float percentageOfDay = t.GetPercentageOfDay();
		timeCircle.transform.localRotation = Quaternion.Euler(0f, 0f, percentageOfDay * -360f);
	}

	public static string GetFormattedDate(TimeSpan t)
	{
		dateBuilder.Length = 0;
		dateBuilder.Append(GetFormattedMonth(t.GetMonths()));
		dateBuilder.Append(" ");
		dateBuilder.Append(GetFormattedDay(t.GetDays()));
		dateBuilder.Append(", ");
		dateBuilder.Append(GetFormattedYear(t.GetYears()));
		return dateBuilder.ToString();
	}

	public static string GetFormattedTime(TimeSpan t)
	{
		return GetFormattedHourAndMinute(t.GetHours(), t.GetMinutes());
	}

	private static string GetFormattedYear(int year)
	{
		return year.ToString();
	}

	private static string GetFormattedHourAndMinute(int hour, int minute)
	{
		if ((ulong)minute > 60uL || minute < 0)
		{
			Debug.LogError("Invalid minute " + minute + " submitted for formatting!");
			return "00";
		}
		string text = minute.ToString();
		if (minute < 10)
		{
			text = "0" + text;
		}
		switch (hour)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			return hour + ":" + text + " AM";
		case 0:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
			switch (hour)
			{
			case 12:
				return hour + ":" + text + " PM";
			case 0:
				return hour + 12 + ":" + text + " AM";
			default:
				return hour - 12 + ":" + text + " PM";
			}
		default:
			Debug.LogError("Invalid hour " + hour + " submitted for formatting!");
			return "00";
		}
	}

	private void FormatMinute(int minute, StringBuilder builder)
	{
		if (minute < 10)
		{
			builder.Append("0");
			builder.Append(minute.ToString());
		}
		else
		{
			builder.Append(minute.ToString());
		}
	}

	private static string GetFormattedDay(int day)
	{
		string text = day.ToString();
		if (day == 1 || (text.Length > 1 && text[1] == '\u0001'))
		{
			return "1st";
		}
		if (day == 2 || (text.Length > 1 && text[1] == '\u0002'))
		{
			return "2nd";
		}
		if (day == 3 || (text.Length > 1 && text[1] == '\u0003'))
		{
			return "3rd";
		}
		if (day > 0)
		{
			return day + "th";
		}
		Debug.LogError("Invalid day " + day + " submitted for formatting!");
		return "0th";
	}

	private static string GetFormattedMonth(int month)
	{
		switch (month)
		{
		case 1:
			return "January";
		case 2:
			return "February";
		case 3:
			return "March";
		case 4:
			return "April";
		case 5:
			return "May";
		case 6:
			return "June";
		case 7:
			return "July";
		case 8:
			return "August";
		case 9:
			return "September";
		case 10:
			return "October";
		case 11:
			return "November";
		case 12:
			return "December";
		default:
			Debug.LogError("Invalid month " + month + " submitted for formatting.");
			return "Doguary";
		}
	}
}
