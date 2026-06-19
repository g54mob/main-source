using System.Collections.Generic;

public class CavelingShaman : EntityMonoBehaviour
{
	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		AudioManager.SfxFollowTransform(SfxTableID.cavelingShamanIdleSfx, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
	}

	protected override void OnDeath()
	{
		soundOptions.deathSfx.value = ((base.objectData.objectID == ObjectID.VoidCavelingShaman) ? SfxTableID.voidCavelingDeathSfx : SfxTableID.cavelingShamanDeath);
		base.OnDeath();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	protected override void OnTakeDamage()
	{
		soundOptions.takeDamageSfx.value = ((base.objectData.objectID == ObjectID.VoidCavelingShaman) ? SfxTableID.voidCavelingTakeDamageSfx : SfxTableID.cavelingShamanTakeDamage);
		base.OnTakeDamage();
	}
}
