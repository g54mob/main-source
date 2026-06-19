using System.Collections.Generic;
using Interaction;
using UnityEngine;

public class BiomeBossStatueUI : SimpleCraftingUI
{
	public SpriteRenderer bossIcon;

	public List<Sprite> bossSprites;

	protected override void Awake()
	{
		recipeUI.Init();
		root.SetActive(value: false);
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		RenderBossIcon();
	}

	public void RenderBossIcon()
	{
		PlayerController player = Manager.main.player;
		EntityUtility.TryGetComponentData<InteractorCD>(player.entity, player.world, out var value);
		EntityUtility.TryGetComponentData<TitanShrineCD>(value.currentClosestInteractable, player.world, out var value2);
		switch (value2.titanObjectID)
		{
		case ObjectID.NatureBossStatue:
			bossIcon.sprite = bossSprites[0];
			break;
		case ObjectID.SeaBossStatue:
			bossIcon.sprite = bossSprites[1];
			break;
		case ObjectID.DesertBossStatue:
			bossIcon.sprite = bossSprites[2];
			break;
		case ObjectID.PassageBossStatue:
			bossIcon.sprite = bossSprites[3];
			break;
		case ObjectID.ExcavationBossStatue:
			bossIcon.sprite = bossSprites[4];
			break;
		case ObjectID.HydraBossStatue:
			break;
		}
	}
}
