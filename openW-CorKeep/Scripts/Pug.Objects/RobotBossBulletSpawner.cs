using Pug.Sprite;

public class RobotBossBulletSpawner : EntityMonoBehaviour
{
	private static readonly int wobbleEvent = SpriteAsset.StringToHash("wobble");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
		HandleAnimationTrigger(-1878077465);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		Manager.effects.PlayPuff(PuffID.VoidMortarExplosion, base.transform.position, 1);
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		HandleAnimationTrigger(-1533413595);
	}

	protected override void DeathEffect()
	{
		base.DeathEffect();
	}

	private void HandleAnimationEvent(int hash)
	{
		if (hash == wobbleEvent)
		{
			spriteObjects[0].PlayTransformAnimation(-1838420484);
		}
	}
}
