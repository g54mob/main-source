using System.Collections;
using UnityEngine;

public class AutoDayNight : MonoBehaviour
{
	public bool autoDayLength = true;

	public float dayLength = 15f;

	public bool autoNightLength;

	public float nightLength = 15f;

	public GameObject uiCountdownPrefab;

	private void Start()
	{
		StartCoroutine(Startup());
	}

	private IEnumerator Startup()
	{
		yield return null;
		yield return null;
		if ((bool)DayNightCycle.Instance)
		{
			if (autoDayLength)
			{
				DayNightCycle.Instance.SetToAutoDayLength(dayLength);
			}
			if (autoNightLength)
			{
				DayNightCycle.Instance.SetToAutoNightLength(nightLength);
			}
		}
		Object.Instantiate(uiCountdownPrefab, NightscoreUI.instance.transform);
	}
}
