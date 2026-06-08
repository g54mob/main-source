using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanel : PopupPanel
{
	[SerializeField]
	private Slider progressSlider;

	[SerializeField]
	private TextMeshProUGUI timeLeftText;

	[SerializeField]
	private TextMeshProUGUI activityText;

	private int count;

	private float duration;

	private void SetSliderDuration(float duration)
	{
		this.duration = duration;
	}

	public void InitializeSliderPanel(float duration)
	{
		CursorManager.SetLoading();
		SetSliderDuration(duration);
		progressSlider.maxValue = duration;
	}

	public void StartLoading(float duration, string[] messages)
	{
		InitializeSliderPanel(duration);
		StartCoroutine(PlayLoading(messages));
	}

	public void StartLoading(float duration, string[] messages, Action postLoadingAction)
	{
		InitializeSliderPanel(duration);
		StartCoroutine(PlayLoading(messages, postLoadingAction));
	}

	protected virtual IEnumerator PlayLoading(string[] messages)
	{
		Texture2D[] loadingCursors = CursorManager.GetLoadingCursors();
		int cursorIndex = 0;
		bool incrementIndex = true;
		float currentTime = 0f;
		float waitDuration = 0.1f;
		float totalDuration = duration;
		float totalTicks = totalDuration / waitDuration;
		while (currentTime <= totalDuration)
		{
			yield return new WaitForSeconds(waitDuration);
			count++;
			currentTime += waitDuration;
			progressSlider.value = currentTime;
			string text = UIUtils.GeneratePeriods(currentTime, 180f);
			int num = (int)(totalDuration - currentTime);
			if (num > 1)
			{
				timeLeftText.text = $"{num} seconds{text}";
			}
			else
			{
				timeLeftText.text = "Less than 1 second" + text;
			}
			activityText.text = GenerateAction(messages, totalTicks) + text;
			CursorManager.SetCursor(loadingCursors[cursorIndex], forceCursor: true);
			cursorIndex += (incrementIndex ? 1 : (-1));
			if (cursorIndex >= loadingCursors.Length)
			{
				incrementIndex = false;
				cursorIndex = loadingCursors.Length - 1;
			}
			else if (cursorIndex < 0)
			{
				incrementIndex = true;
				cursorIndex = 0;
			}
			yield return null;
		}
	}

	protected virtual IEnumerator PlayLoading(string[] messages, Action postLoadingAction)
	{
		yield return PlayLoading(messages);
		postLoadingAction();
		CursorManager.StopCursorLoading();
		GetComponentInChildren<Toolbar>().Close();
	}

	private string GenerateAction(string[] messages, float totalTicks)
	{
		LevelManager.GetCurrLevel();
		if ((float)count <= totalTicks / 3f)
		{
			return messages[0];
		}
		if ((float)count <= totalTicks * 2f / 3f)
		{
			return messages[1];
		}
		return messages[2];
	}
}
