using Pug.Sprite;
using UnityEngine;

public class GalaxiteTrap : EntityMonoBehaviour
{
	private float lastTriggerTime;

	private float timeBetweenAttacks;

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
		AudioManager.Sfx(SfxID.fireball, position, 0.5f, 1.25f, 0.1f);
		Manager.effects.PlayPuff(PuffID.SmallColorfulExplosion, position);
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			spriteObject.PlayAnimation(AttackAnim);
		}
	}
}
