using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SantasLittleHelper : CraftingBuilding
{
	public Transform particleSpawnLocation;

	private int previousPresentAmount;

	private TimerSimple idleEmoteTimer;

	private readonly float maxEmoteCooldown = 50f;

	private readonly float minEmoteCooldown = 10f;

	private bool isShowingPresent;

	private bool isIdle;

	private readonly List<AudioManager.RunningSfxReference> audioLoop = new List<AudioManager.RunningSfxReference>();

	public override void OnOccupied()
	{
		base.OnOccupied();
		previousPresentAmount = 0;
		isShowingPresent = false;
		isIdle = false;
		idleEmoteTimer.Stop();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		isIdle = !craftingHandler.IsAnySlotCrafting() && !isShowingPresent;
		if (!idleEmoteTimer.isRunning)
		{
			StartSantasLittleHelperTimer();
		}
		if (idleEmoteTimer.isTimerElapsed)
		{
			StartSantasLittleHelperTimer();
			if (isIdle)
			{
				animator.SetTrigger(-689712656);
			}
		}
		if (craftingHandler.IsAnySlotCrafting())
		{
			if (audioLoop.Count == 0)
			{
				AudioManager.Sfx(SfxTableID.santasHelperCraftingPresent_loop, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, audioLoop);
			}
		}
		else
		{
			FadeOutAudioLoop();
		}
		ObjectDataCD objectDataCD = craftingHandler.outputInventoryHandler.GetObjectData(0);
		int amount = objectDataCD.amount;
		if (amount == 0 && isShowingPresent)
		{
			RandomStartIdle();
			isShowingPresent = false;
			isIdle = true;
		}
		if (amount > 0 && !craftingHandler.IsAnySlotCrafting() && !isShowingPresent)
		{
			if (objectDataCD.objectID == ObjectID.ChristmasLuxuryPresent)
			{
				animator.SetTrigger(806946379);
			}
			else
			{
				animator.SetTrigger(-1458546703);
			}
			isShowingPresent = true;
		}
		else if (amount == 0 || craftingHandler.IsAnySlotCrafting() || isIdle)
		{
			isShowingPresent = false;
		}
		if (amount > previousPresentAmount)
		{
			previousPresentAmount = amount;
			if (Manager.main.player != null && craftingHandler == Manager.main.player.activeCraftingHandler && Manager.ui.isCraftingUIShowing)
			{
				AudioManager.Sfx(SfxID.grassImpactHard, base.transform.position, 0.5f, 0.8f, 0.2f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: false);
			}
		}
	}

	protected override void OnActive()
	{
		base.OnActive();
	}

	protected override void OnInactive()
	{
		RandomStartIdle();
	}

	protected void StartSantasLittleHelperTimer()
	{
		float newLifespan = Random.Range(minEmoteCooldown, maxEmoteCooldown);
		idleEmoteTimer.Start(newLifespan);
	}

	protected void RandomStartIdle()
	{
		animator.SetTrigger(-601574123);
		float normalizedTime = Random.Range(0f, 1f);
		animator.Play("Idle", 2, normalizedTime);
	}

	protected void FadeOutAudioLoop()
	{
		foreach (AudioManager.RunningSfxReference item in audioLoop)
		{
			item.FadeOutAndStop(0.2f);
		}
		audioLoop.Clear();
	}

	public void AE_PresentDone()
	{
		AudioManager.Sfx(SfxTableID.santasHelperFinishPresent, base.transform.position);
		Vector3 position = particleSpawnLocation.position;
		Manager.effects.PlayPuff(PuffID.Snowflakes, position);
		Manager.effects.PlayPuff(PuffID.SnowLinger, position, 30);
		Manager.effects.PlayPuff(PuffID.SnowItemDust, position);
	}

	public void AE_IdleWiggle()
	{
		AudioManager.Sfx(SfxTableID.santasHelperIdleWiggle, base.transform.position);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		FadeOutAudioLoop();
		Manager.effects.PlayPuff(PuffID.SnowItemDust, base.transform.position);
	}

	protected override void OnHide()
	{
		base.OnHide();
		FadeOutAudioLoop();
	}

	public override void OnFree()
	{
		base.OnFree();
		FadeOutAudioLoop();
	}
}
