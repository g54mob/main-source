using System;
using UnityEngine;

public class BaseGameEvent : IDifficulty
{
	private bool isCoolingDown;

	private float eventTimerCurrent;

	protected System.Random rnd;

	public float Probability { get; protected set; }

	public float CheckFrequency { get; protected set; }

	public float Cooldown { get; protected set; }

	public bool OneTimeEvent { get; protected set; }

	public virtual bool IgnoreInTutorial
	{
		get
		{
			return true;
		}
	}

	public float DifficultyFactor { get; private set; }

	private BaseGameEvent()
	{
	}

	public BaseGameEvent(int seed)
	{
		if (seed == -1)
		{
			seed = (int)DateTime.Now.Ticks;
		}
		rnd = new System.Random(seed);
	}

	public virtual void Initalize()
	{
	}

	public virtual void Update()
	{
		if (!GlobalSettings.MissionStarted || GlobalSettings.IsGamePaused || GlobalSettings.GameIsOver)
		{
			return;
		}
		eventTimerCurrent += Time.deltaTime;
		if (isCoolingDown)
		{
			if (eventTimerCurrent > Cooldown)
			{
				isCoolingDown = false;
				eventTimerCurrent = 0f;
			}
		}
		else
		{
			if (!(eventTimerCurrent > CheckFrequency))
			{
				return;
			}
			eventTimerCurrent = 0f;
			if (rnd.NextFloat(0f, 1f) < Probability)
			{
				ExecuteEvent();
				if (!OneTimeEvent)
				{
					isCoolingDown = true;
				}
				else
				{
					GameEventManager.Instance.RemoveEvent(this);
				}
			}
		}
	}

	public virtual void ExecuteEvent()
	{
		Debug.Log("well nothing is going to happen all event-like here. I'm the base class");
	}

	public virtual void SetDifficulty(float difficultyFactor)
	{
		DifficultyFactor = difficultyFactor;
	}
}
