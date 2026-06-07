using I2.Loc;
using PajamaLlama.Math;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayClock : SceneBehaviour
{
	[SerializeField]
	private Image _nightCycleImage;

	[SerializeField]
	private Image _dayCycleImage;

	[SerializeField]
	private RectTransform _needleTransform;

	[SerializeField]
	private TextMeshProUGUI _dayText;

	[SerializeField]
	private LocalizedString _dayTextLoc = null;

	private void Start()
	{
		Day currentDay = GameManager.TimeManager.CurrentDay;
		float daytimeLength = currentDay.DaytimeLength;
		float nighttimeLength = currentDay.NighttimeLength;
		float dayLength = currentDay.DayLength;
		_nightCycleImage.fillAmount = nighttimeLength / dayLength;
		_dayCycleImage.fillAmount = daytimeLength / dayLength;
		GameEventDispatcher.AddListener(GameEventType.DayStarted, OnDayStarted);
		OnDayStarted(null);
	}

	private void Update()
	{
		float z = Mathf.Lerp(0f, -360f, GameManager.TimeManager.CurrentDay.NormalizedDayProgress);
		Vector3 euler = _needleTransform.rotation.eulerAngles.SetZ(z);
		_needleTransform.rotation = Quaternion.Euler(euler);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayStarted, OnDayStarted);
	}

	private void OnDayStarted(GameEvent gameEvent)
	{
		_dayText.text = _dayTextLoc;
	}
}
