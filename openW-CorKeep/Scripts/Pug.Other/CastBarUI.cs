using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class CastBarUI : UIelement
{
	public GameObject root;

	public Transform castBarMaskPivot;

	public SpriteRenderer castBar;

	public Flashable flashable;

	public Flashable backgroundFlashable;

	public List<SpriteRenderer> lines;

	public SpriteRenderer minLine;

	private TimerSimple backgroundFlashTimer = new TimerSimple(0.4f);

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (!(Manager.main.player != null))
		{
			root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
			DisplayNothing();
			backgroundFlashable.CancelAndStopEffect();
		}
	}

	public void DisplayNormal(float elapsedRatio)
	{
		castBarMaskPivot.localScale = new Vector3(elapsedRatio, 1f, 1f);
		root.SetActive(value: true);
		backgroundFlashable.CancelAndStopEffect();
	}

	public void DisplayWindup(float lifespan, float elapsed, int tiers, bool windupTimerRunning, bool windupTimerElapsed)
	{
		foreach (SpriteRenderer line in lines)
		{
			line.enabled = false;
		}
		float x = castBar.size.x;
		float num = x / 2f;
		minLine.enabled = false;
		for (int i = 1; i < tiers; i++)
		{
			lines[i].enabled = true;
			float x2 = x * (float)i / (float)tiers - num;
			lines[i].transform.localPosition = new Vector3(x2, 0f, 0f);
		}
		float val = (windupTimerRunning ? (elapsed / lifespan) : 0f);
		castBarMaskPivot.localScale = new Vector3(Math.Min(1f, val), 1f, 1f);
		if (windupTimerRunning && windupTimerElapsed && (!backgroundFlashTimer.isRunning || backgroundFlashTimer.isTimerElapsed))
		{
			backgroundFlashable.FlashLinearNoCurve(Color.white, 0.3f);
			backgroundFlashTimer.Start();
		}
		root.SetActive(value: true);
	}

	public void DisplayNothing()
	{
		foreach (SpriteRenderer line in lines)
		{
			line.enabled = false;
		}
		minLine.enabled = false;
		root.SetActive(value: false);
		backgroundFlashable.CancelAndStopEffect();
	}
}
