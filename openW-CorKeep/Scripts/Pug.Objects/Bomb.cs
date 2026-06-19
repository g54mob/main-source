using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class Bomb : EntityMonoBehaviour
{
	[Serializable]
	public class TickEvent
	{
		public float timeToNextTick;

		public int eventIndex;
	}

	public ParticleEffectSpawner sparks;

	public ParticleSystem tickPuff;

	public bool skipFuseSound;

	public List<TickEvent> TickEvents;

	private TimerSimple nextTickTimer;

	private bool timerStarted;

	private bool eventsFinished;

	private int currentTickEvent;

	public override void OnOccupied()
	{
		base.OnOccupied();
		currentTickEvent = 0;
		timerStarted = false;
		eventsFinished = false;
		UpdateTickEvent(currentTickEvent);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (timerStarted && nextTickTimer.isTimerElapsed && !base.isHidden)
		{
			UpdateTickEvent(currentTickEvent);
		}
	}

	protected virtual void DisableSparkParticles()
	{
		if ((bool)sparks)
		{
			sparks.enabled = false;
		}
	}

	protected virtual void EnableSparkParticles()
	{
		if ((bool)sparks)
		{
			sparks.enabled = true;
		}
	}

	protected virtual void PlayWobbleEffect()
	{
		PlaySpriteObjectAnimation(-1838420484);
		flashable.FlashLinearNoCurve();
		if ((bool)tickPuff)
		{
			tickPuff.Play();
		}
		AudioManager.SfxFollowTransform(SfxID.bubble, base.transform, 0.4f, 1f, 0.1f);
	}

	private void UpdateTickEvent(int currentEvent)
	{
		if (TickEvents.Count > currentTickEvent)
		{
			timerStarted = true;
			float timeToNextTick = TickEvents[currentEvent].timeToNextTick;
			int eventIndex = TickEvents[currentEvent].eventIndex;
			if (timeToNextTick > 0f)
			{
				nextTickTimer.Start(timeToNextTick);
			}
			PlayTickEvent(eventIndex);
		}
		else
		{
			timerStarted = false;
			eventsFinished = true;
		}
		currentTickEvent++;
	}

	protected virtual void PlayTickEvent(int index)
	{
		switch (index)
		{
		default:
			Debug.LogError("Bomb is attempting to play an unknown or missing event.");
			break;
		case 0:
			EnableSparkParticles();
			if (!skipFuseSound)
			{
				AudioManager.SfxFollowTransform(SfxID.bombFuse, base.transform, 0.5f, 0.9f, 0.15f);
			}
			break;
		case 1:
			PlayWobbleEffect();
			break;
		case 2:
			PlayWobbleEffect();
			DisableSparkParticles();
			break;
		}
	}
}
