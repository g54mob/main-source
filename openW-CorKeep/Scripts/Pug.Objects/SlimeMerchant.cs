using Pug.UnityExtensions;
using UnityEngine;

public class SlimeMerchant : NPC
{
	private TimerSimple waveTimer;

	public override void Interact()
	{
		PlayerController player = Manager.main.player;
		if (player != null && EntityUtility.GetComponentData<MerchantCD>(base.entity, base.world).hasNewItems)
		{
			player.playerCommandSystem.ResetMerchantHasNewItems(base.entity);
			animator.SetTrigger(-601574123);
		}
		base.Interact();
	}

	public override void PlayInteractSound()
	{
		base.PlayInteractSound();
		AudioManager.Sfx(SfxID.merchantCaveling, base.transform.position, 1f, 0.8f, 0.1f);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -601574123 && EntityUtility.HasComponentData<MerchantCD>(base.entity, base.world) && EntityUtility.GetComponentData<MerchantCD>(base.entity, base.world).hasNewItems && (!waveTimer.isRunning || waveTimer.isTimerElapsed))
		{
			waveTimer.Start(Random.Range(3, 5));
			animID = -637227639;
		}
		base.HandleAnimationTrigger(animID);
	}

	public void AE_ShakeSlime()
	{
		AudioManager.Sfx(SfxID.slimeFootstep, base.transform.position, 0.3f, 1.2f, 0.2f);
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, base.transform.position, 20);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		bool flag = lastAnim == -637227639 && animID == -601574123;
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return !flag;
		}
		return false;
	}
}
