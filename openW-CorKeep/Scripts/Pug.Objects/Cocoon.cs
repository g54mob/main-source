using Pug.Sprite;
using UnityEngine;

public class Cocoon : EntityMonoBehaviour
{
	[Header("Custom Hatch-sfx table id")]
	public SFXTableIDField hatchSfxTable;

	private readonly int m_WobbleLEvent = SpriteAsset.StringToHash("wobbleLeft");

	private readonly int m_WobbleREvent = SpriteAsset.StringToHash("wobbleRight");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		spriteObjects[0].PlayAnimation(-601574123);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1296348555)
		{
			if (hatchSfxTable.value != 0)
			{
				AudioManager.Sfx(hatchSfxTable.value, base.transform.position);
			}
			else
			{
				AudioManager.Sfx(SfxID.cocoonHatch, base.transform.position);
			}
			Manager.effects.PlayPuff(PuffID.MediumPurplePuff, base.transform.position, 60);
		}
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_WobbleLEvent == hash)
		{
			spriteObjects[0].PlayTransformAnimation(435238892);
		}
		if (m_WobbleREvent == hash)
		{
			spriteObjects[0].PlayTransformAnimation(-469890417);
		}
	}
}
