using System;
using System.Collections;
using Pug.UnityExtensions;

public class CraftMiningPickTutorial : TutorialSequence
{
	public float emoteRepeatIntervalSeconds = 60f;

	public override bool ReadyToRun()
	{
		return Manager.saves.HasCompletedTutorial(TutorialID.CraftTorch);
	}

	public override bool HasBeenBypassed()
	{
		if (Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.bossesKilled <= 0 && !Manager.saves.HasDiscoveredObject(ObjectID.WoodMiningPick))
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.CopperMiningPick);
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
		while (!Manager.saves.HasDiscoveredObject(ObjectID.WoodMiningPick))
		{
			Manager.ui.ShowBagLightUpHint();
			while (!Manager.ui.playerInventoryUI.isShowing)
			{
				if (!emoteTimer.isRunning || emoteTimer.isTimerElapsed)
				{
					Emote.SpawnEmoteText(Manager.main.player.transform.position, Emote.EmoteType.TutorialCraftMiningPick);
					emoteTimer.Start();
				}
				yield return null;
			}
			Manager.ui.ShowRecipeLightUpHint(ObjectID.WoodMiningPick);
			while (Manager.ui.playerInventoryUI.isShowing)
			{
				Manager.main.player.UpdateDiscoveredItems();
				if (Manager.saves.HasDiscoveredObject(ObjectID.WoodMiningPick))
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
