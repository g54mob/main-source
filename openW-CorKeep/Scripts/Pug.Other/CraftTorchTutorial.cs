using System;
using System.Collections;
using Pug.UnityExtensions;

public class CraftTorchTutorial : TutorialSequence
{
	public float emoteRepeatIntervalSeconds = 60f;

	public override bool ReadyToRun()
	{
		return Manager.saves.HasCompletedTutorial(TutorialID.GatherWood);
	}

	public override bool HasBeenBypassed()
	{
		if (Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.bossesKilled <= 0)
		{
			return Manager.saves.HasDiscoveredObject(ObjectID.Torch);
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
		while (!Manager.saves.HasDiscoveredObject(ObjectID.Torch))
		{
			Manager.ui.ShowBagLightUpHint();
			while (!Manager.ui.playerInventoryUI.isShowing)
			{
				if (!emoteTimer.isRunning || emoteTimer.isTimerElapsed)
				{
					Emote.SpawnEmoteText(Manager.main.player.transform.position, Emote.EmoteType.TutorialCraftTorch);
					emoteTimer.Start();
				}
				yield return null;
			}
			Manager.ui.ShowRecipeLightUpHint(ObjectID.Torch);
			while (Manager.ui.playerInventoryUI.isShowing)
			{
				Manager.main.player.UpdateDiscoveredItems();
				if (Manager.saves.HasDiscoveredObject(ObjectID.Torch))
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
