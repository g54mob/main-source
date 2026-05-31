using System;
using DG.Tweening;
using UnityEngine;

public class NightCycle : MonoBehaviour
{
	private SpriteRenderer sr;

	private int sysHour;

	private int night = 22;

	private int morn = 7;

	[SerializeField]
	private bool previousHourWasNight;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		InitialCheck();
		InvokeRepeating("CheckIfNight", 0f, 1800f);
	}

	private void InitialCheck()
	{
		sysHour = DateTime.Now.Hour;
		if (sysHour >= night || sysHour < morn)
		{
			previousHourWasNight = true;
			sr.color = new Color(0f, 0f, 0f, 0.3f);
		}
		if (sysHour >= morn && sysHour < night)
		{
			previousHourWasNight = false;
			sr.color = new Color(0f, 0f, 0f, 0f);
		}
	}

	private void CheckIfNight()
	{
		if (!SaveData.ins.nightMode)
		{
			return;
		}
		sysHour = DateTime.Now.Hour;
		if (sysHour >= night || sysHour < morn)
		{
			GameManager.ins.isNight = true;
		}
		if (sysHour >= morn && sysHour < night)
		{
			GameManager.ins.isNight = false;
		}
		sr.enabled = GameManager.ins.isNight;
		if (previousHourWasNight != GameManager.ins.isNight)
		{
			if (GameManager.ins.isNight)
			{
				sr.DOFade(0.3f, 60f);
			}
			else
			{
				sr.DOFade(0f, 60f);
			}
		}
		previousHourWasNight = GameManager.ins.isNight;
	}

	public void TurnOnNightCycle()
	{
		CheckIfNight();
	}

	public void TurnOffNightCycle()
	{
		GameManager.ins.isNight = false;
		sr.enabled = GameManager.ins.isNight;
	}
}
