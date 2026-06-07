using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private bool autoUpdate = true;

	private TimeSpan timeSpan;

	private void OnEnable()
	{
		if (autoUpdate)
		{
			StartCoroutine(UpdateTimeCoroutine());
		}
	}

	private IEnumerator UpdateTimeCoroutine()
	{
		while (true)
		{
			UpdateTime(LTFunctionLibrary.GetTimeManager().GetTimeMilliseconds());
			yield return null;
		}
	}

	public void UpdateTime(long milliseconds)
	{
		timeSpan = TimeSpan.FromMilliseconds(milliseconds);
		text.text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
	}
}
