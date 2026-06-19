using Unity.Mathematics;
using UnityEngine;

public class InfoBoardSmall : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	public Sprite[] spriteVariations;

	public Sprite[] spriteEmissiveVariations;

	public SpriteRenderer SR;

	public SpriteRenderer SREmissive;

	public SpriteRenderer shadowSR;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		int num = Unity.Mathematics.Random.CreateFromIndex((uint)(base.WorldPosition.GetHashCode() + 1)).NextInt(0, spriteVariations.Length);
		SR.sprite = spriteVariations[num];
		if (SREmissive != null)
		{
			SREmissive.sprite = spriteEmissiveVariations[num];
		}
		base.UpdateGraphicsFromObjectInfo(info);
	}
}
