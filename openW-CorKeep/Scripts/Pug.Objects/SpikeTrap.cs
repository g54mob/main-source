using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class SpikeTrap : EntityMonoBehaviour
{
	private float lastTriggerTime;

	private float timeBetweenAttacks;

	public List<SpriteObject> SpikeSprites;

	private int AttackAnim = Animator.StringToHash("attack");

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID != 1203776827 || !(Time.time - lastTriggerTime > timeBetweenAttacks))
		{
			return;
		}
		lastTriggerTime = Time.time;
		Vector3 position = base.transform.position;
		AudioManager.Sfx(SfxID.slimeImpact, position, 0.5f, 1.3f, 0.1f);
		Manager.effects.PlayPuff(PuffID.BloodSpurt, position, 20);
		Manager.effects.PlayPuff(PuffID.SmallPurplePuff, position);
		foreach (SpriteObject spikeSprite in SpikeSprites)
		{
			spikeSprite.PlayAnimation(AttackAnim);
		}
	}
}
