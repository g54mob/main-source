using UnityEngine;

public class FuryForge : Furnace
{
	public SpriteRenderer glowSR;

	public SpriteRenderer doorSR;

	private PoolableAudioSource audioLoop;

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.isHidden)
		{
			return;
		}
		int amount = craftingHandler.inventoryHandler.GetObjectData(0).amount;
		doorSR.gameObject.SetActive(base.CurrentBarAmount > 0 || base.IsActive);
		glowSR.gameObject.SetActive(base.IsActive);
		if (amount > 0)
		{
			if (!audioLoop)
			{
				audioLoop = AudioManager.SfxFollowTransform(SfxID.beamLoop, base.transform, 0.3f, 0.3f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 16f, 8f);
			}
		}
		else
		{
			FadeOutAudioLoop();
		}
	}

	private void FadeOutAudioLoop()
	{
		if ((bool)audioLoop)
		{
			audioLoop.FadeOutAndStop(0.2f);
			audioLoop = null;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		FadeOutAudioLoop();
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
