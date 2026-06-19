using System;
using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;

public class GatherWoodTutorial : TutorialSequence
{
	public float emoteRepeatIntervalSeconds = 60f;

	public override bool HasBeenBypassed()
	{
		if (Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.bossesKilled <= 0)
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.Wood);
		}
		return true;
	}

	public override void StartTutorialSequence(Action<bool> onFinished)
	{
		StartCoroutine(RunTutorial(onFinished));
	}

	private IEnumerator RunTutorial(Action<bool> onFinished)
	{
		TimerSimple emoteTimer = new TimerSimple(emoteRepeatIntervalSeconds);
		while (!Manager.saves.HasDiscoveredObject(ObjectID.Wood))
		{
			if (!emoteTimer.isRunning || emoteTimer.isTimerElapsed)
			{
				Emote.SpawnEmoteText(base.transform.position, Emote.EmoteType.TutorialBreakWood);
				emoteTimer.Start();
			}
			yield return new WaitForSeconds(1f);
		}
		onFinished(obj: true);
	}
}
