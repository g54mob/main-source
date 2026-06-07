using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionControl : ActiveComponent
{
	public float fadeTimeOn = 1.5f;

	public float fadeTimeOff = 1.5f;

	private List<Image> images = new List<Image>();

	private bool middle;

	private bool end;

	private float stageTimerStart;

	public bool fade = true;

	public GameObject top;

	public GameObject bot;

	private Action curAction;

	private bool cursorActive;

	private float addRate;

	private float timer;

	private void Awake()
	{
		end = true;
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		Image[] componentsInChildren = GetComponentsInChildren<Image>();
		foreach (Image image in componentsInChildren)
		{
			images.Add(image);
			Color white = Color.white;
			white.a = 0f;
			image.color = white;
		}
		end = true;
	}

	public void ActiveOnFade(Action act)
	{
		cursorActive = ActiveComponent.Program.cursor.Visible();
		ActiveComponent.Program.cursor.SetActive(state: false);
		curAction = act;
		stageTimerStart = Time.unscaledTime;
		timer = Time.unscaledTime;
		middle = false;
		end = false;
		addRate += 1f / (float)Application.targetFrameRate;
	}

	private void Update()
	{
		timer += Mathf.Min(addRate, Time.unscaledDeltaTime);
		if (!base.IsInited || end)
		{
			return;
		}
		if (!middle)
		{
			if (!fade)
			{
				return;
			}
			foreach (Image image in images)
			{
				Color color = image.color;
				color.a = (timer - stageTimerStart) / fadeTimeOn;
				image.color = color;
			}
			if (!(timer - stageTimerStart > fadeTimeOn))
			{
				return;
			}
			stageTimerStart = timer;
			middle = true;
			foreach (Image image2 in images)
			{
				Color color2 = image2.color;
				color2.a = 1f;
				image2.color = color2;
			}
			if (curAction != null)
			{
				ActiveComponent.Program.cursor.SetActive(cursorActive);
			}
			curAction();
		}
		else
		{
			if (!fade)
			{
				return;
			}
			foreach (Image image3 in images)
			{
				Color color3 = image3.color;
				color3.a = (fadeTimeOff - (timer - stageTimerStart)) / fadeTimeOff;
				image3.color = color3;
			}
			if (!(timer - stageTimerStart > fadeTimeOff))
			{
				return;
			}
			end = true;
			foreach (Image image4 in images)
			{
				Color white = Color.white;
				white.a = 0f;
				image4.color = white;
			}
			ActiveComponent.Program.cursor.SetActive(cursorActive);
			base.gameObject.SetActive(value: false);
		}
	}
}
