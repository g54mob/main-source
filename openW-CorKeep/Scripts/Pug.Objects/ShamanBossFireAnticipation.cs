using UnityEngine;

public class ShamanBossFireAnticipation : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			Manager.effects.PlayPuff(PuffID.SmallFireExplosion, base.transform.position + new Vector3(0f, 0.5f, -0.5f));
			AudioManager.Sfx(SfxID.fireball, base.transform.position, 0.4f, 2f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		}
	}
}
