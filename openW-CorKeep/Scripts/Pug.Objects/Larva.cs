using UnityEngine;

public class Larva : EntityMonoBehaviour
{
	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateGraphicsFromObjectInfo(base.objectInfo);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.SmallPurplePuff, base.transform.position, 30);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
		int num = 1;
		if (Random.value < 0.5f)
		{
			num = -1;
		}
		Manager.effects.PlayTempSprite(SpriteTempEffectID.HitEffect, center + new Vector3(0f, 2f, -2f) + offset, (float)num * 0.8f);
	}

	protected override void DeathEffect()
	{
		Manager.effects.ExploDisc(center, 0.25f);
	}
}
