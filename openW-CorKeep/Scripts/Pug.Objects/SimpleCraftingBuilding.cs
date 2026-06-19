using UnityEngine;

public class SimpleCraftingBuilding : CraftingBuilding
{
	public SpriteRenderer SRShadow;

	private Sprite defaultShadowSprite;

	public Transform particleSpawnLocation;

	private bool isWideCraftingBuilding => this is SimpleWideCraftingBuilding;

	protected override void Awake()
	{
		base.Awake();
		if ((bool)SRShadow)
		{
			defaultShadowSprite = SRShadow.sprite;
		}
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		if ((bool)SRShadow)
		{
			if (!isWideCraftingBuilding && info.additionalSprites.Count > 0)
			{
				SRShadow.sprite = info.additionalSprites[0];
			}
			else
			{
				SRShadow.sprite = defaultShadowSprite;
			}
		}
		base.UpdateGraphicsFromObjectInfo(info);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, particleSpawnLocation.position, 5);
	}
}
