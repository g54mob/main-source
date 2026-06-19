using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;

public class TickTockSound : PoolableSimple
{
	private float playTime;

	private float timeBetweenTicks;

	private Coroutine tickTockCoroutine;

	private int tickCount;

	public static TickTockSound SpawnTickTockSound(float _playTime, float _timeBetweenTicks, Transform parent, Vector3 localPosition)
	{
		TickTockSound freeComponent = Manager.memory.GetFreeComponent<TickTockSound>(deferOnOccupied: true);
		freeComponent.transform.parent = parent;
		freeComponent.transform.localPosition = localPosition;
		freeComponent.playTime = _playTime;
		freeComponent.timeBetweenTicks = _timeBetweenTicks;
		freeComponent.tickTockCoroutine = freeComponent.PlayTickTockSound();
		freeComponent.OnOccupied();
		freeComponent.tickCount = 0;
		return freeComponent;
	}

	private Coroutine PlayTickTockSound()
	{
		return StartCoroutine(Co_TickTockSound());
	}

	private IEnumerator Co_TickTockSound()
	{
		TimerSimple timerSimple = new TimerSimple(playTime);
		timerSimple.Start();
		while (!timerSimple.isTimerElapsed)
		{
			if (Manager.camera.IsPointInViewport(base.transform.position))
			{
				AudioManager.SfxFollowTransform(SfxID.tock, base.transform, 0.65f, (float)tickCount * 0.1f + 1f);
				tickCount++;
			}
			yield return Yielders.Pause(timeBetweenTicks);
			if (Manager.camera.IsPointInViewport(base.transform.position))
			{
				AudioManager.SfxFollowTransform(SfxID.tock, base.transform, 0.57f, (float)tickCount * 0.1f + 2f);
				tickCount++;
			}
			yield return Yielders.Pause(timeBetweenTicks);
		}
		Free();
	}

	public void Stop()
	{
		StopCoroutine(tickTockCoroutine);
		Free();
	}

	public void SetTimeBetweenTicks(float _timeBetweenTicks)
	{
		timeBetweenTicks = _timeBetweenTicks;
	}
}
