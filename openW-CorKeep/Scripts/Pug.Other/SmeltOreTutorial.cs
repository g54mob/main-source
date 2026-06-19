using System;
using System.Collections;
using Pug.UnityExtensions;

public class SmeltOreTutorial : TutorialSequence
{
	public float emoteRepeatIntervalSeconds = 180f;

	public override bool ReadyToRun()
	{
		if (Manager.saves.HasCompletedTutorial(TutorialID.CraftWorkbench))
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.CopperOre);
		}
		return false;
	}

	public override bool HasBeenBypassed()
	{
		if (Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.bossesKilled <= 0 && !Manager.saves.HasDiscoveredObject(ObjectID.CopperBar) && !Manager.saves.HasDiscoveredObject(ObjectID.CopperMiningPick))
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.CopperSword);
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
		while (!Manager.saves.HasDiscoveredObject(ObjectID.CopperBar))
		{
			if (!emoteTimer.isRunning || emoteTimer.isTimerElapsed)
			{
				Emote.SpawnEmoteText(Manager.main.player.transform.position, Emote.EmoteType.TutorialSmeltOre);
				emoteTimer.Start();
			}
			yield return null;
		}
		onFinished(obj: true);
	}
}
