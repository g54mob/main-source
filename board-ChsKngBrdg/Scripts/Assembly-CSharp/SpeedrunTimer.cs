using TMPro;
using UnityEngine;

public class SpeedrunTimer : MonoBehaviour
{
	public static SpeedrunTimer instance;

	public TMP_Text speedrunText;

	public static bool doSpeedrunTimer;

	public static bool doCountTime;

	public void Awake()
	{
		Object.DontDestroyOnLoad(this);
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Update()
	{
		if (doCountTime)
		{
			SaveSystem.currentPlayerSaveData.totalGameTime += Time.deltaTime;
		}
		if (!doSpeedrunTimer)
		{
			if (speedrunText.gameObject.activeSelf)
			{
				speedrunText.gameObject.SetActive(value: false);
			}
		}
		else if (!speedrunText.gameObject.activeSelf)
		{
			speedrunText.gameObject.SetActive(value: true);
		}
		float totalGameTime = SaveSystem.currentPlayerSaveData.totalGameTime;
		speedrunText.text = TimeToDisplayTime(totalGameTime);
	}

	public static string TimeToDisplayTime(float time)
	{
		float num = Mathf.Floor(time / 3600f);
		float num2 = Mathf.Floor(time / 60f) - num * 60f;
		float num3 = Mathf.Floor(time % 60f);
		string arg = num.ToString("00");
		string arg2 = num2.ToString("00");
		string arg3 = num3.ToString("00");
		return $"{arg:00}:{arg2:00}:{arg3:00}";
	}
}
