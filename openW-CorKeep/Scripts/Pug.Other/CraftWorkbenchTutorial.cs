using System;
using System.Collections;
using Pug.UnityExtensions;

public class CraftWorkbenchTutorial : TutorialSequence
{
	public float emoteRepeatIntervalSeconds = 60f;

	public override bool ReadyToRun()
	{
		return Manager.saves.HasCompletedTutorial(TutorialID.CraftMiningPick);
	}

	public override bool HasBeenBypassed()
	{
		if (Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.bossesKilled <= 0 && !Manager.saves.HasDiscoveredObject(ObjectID.WoodenWorkBench) && !Manager.saves.HasDiscoveredObject(ObjectID.WoodSword) && !Manager.saves.HasDiscoveredObject(ObjectID.CookingPot))
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.CopperBar);
		}
		return true;
	}

	public override void StartTutorialSequence(Action<bool> onFinished)
	{
		StartCoroutine(RunTutorial(onFinished));
	}

	public override void AbortTutorialSequence()
	{
		Manager.ui.ClearRecipeHighlights();
		Manager.ui.HideBagLightUpHint();
		base.AbortTutorialSequence();
	}

	private IEnumerator RunTutorial(Action<bool> onFinished)
	{
		TimerSimple emoteTimer = new TimerSimple(emoteRepeatIntervalSeconds);
		while (!Manager.saves.HasDiscoveredObject(ObjectID.WoodenWorkBench))
		{
			Manager.ui.ShowBagLightUpHint();
			while (!Manager.ui.playerInventoryUI.isShowing)
			{
				if (!emoteTimer.isRunning || emoteTimer.isTimerElapsed)
				{
					Emote.SpawnEmoteText(Manager.main.player.transform.position, Emote.EmoteType.TutorialCraftWorkbench);
					emoteTimer.Start();
				}
				yield return null;
			}
			Manager.ui.ShowRecipeLightUpHint(ObjectID.WoodenWorkBench);
			while (Manager.ui.playerInventoryUI.isShowing)
			{
				Manager.main.player.UpdateDiscoveredItems();
				if (Manager.saves.HasDiscoveredObject(ObjectID.WoodenWorkBench))
				{
					break;
				}
				yield return null;
			}
			Manager.ui.ClearRecipeHighlights();
		}
		onFinished(obj: true);
	}
}
