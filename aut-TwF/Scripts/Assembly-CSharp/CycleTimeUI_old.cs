using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CycleTimeUI_old : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI cycleText;

	[SerializeField]
	private TextMeshProUGUI timeText;

	[SerializeField]
	private Color timeDefaultColor;

	[SerializeField]
	private Color timeWaveColor;

	private TimeSpan timeSpan;

	private Coroutine updateTimeCoroutine;

	private void OnEnable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		OnCycleChanged(LTFunctionLibrary.GetCyclesManager().CurrentCycle, LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
	}

	private void OnDisable()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Remove(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
	}

	private IEnumerator UpdateTimeCoroutine()
	{
		while (true)
		{
			UpdateTime(LTFunctionLibrary.GetDayRemainingMilliseconds());
			yield return null;
		}
	}

	public void UpdateTime(long milliseconds)
	{
		timeSpan = TimeSpan.FromMilliseconds(milliseconds + 1000);
		timeText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		cycleText.text = (cycle + 1).ToString() ?? "";
		if (mode == ECycleMode.Neutral)
		{
			timeText.color = timeDefaultColor;
			this.StartCoroutineCheckingVar(UpdateTimeCoroutine(), ref updateTimeCoroutine, stopCoroutineIfRunning: true);
		}
		else
		{
			this.StopCoroutineCheckingVar(ref updateTimeCoroutine);
			timeText.text = "???";
			timeText.color = timeWaveColor;
		}
	}
}
