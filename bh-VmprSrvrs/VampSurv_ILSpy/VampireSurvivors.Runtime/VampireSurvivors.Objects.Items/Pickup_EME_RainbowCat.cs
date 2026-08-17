using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_EME_RainbowCat : Pickup_EME_Cat
{
	private List<Sprite> _idleAnimation;

	private const string BlackIdle = "eme_cat_black_i04";

	private const string RedIdle = "eme_cat_red_i04";

	private const string YellowIdle = "eme_cat_yellow_i04";

	private const string BlueIdle = "eme_cat_blue_i04";

	protected override ItemType GetCatType()
	{
		return ItemType.EME_CAT_RAINBOW;
	}

	protected unsafe override void GetCatAnimations(out List<Sprite> idle, out List<Sprite> flee, out List<Sprite> dragged)
	{
		if (_idleAnimation == null)
		{
			List<Sprite> idleAnimation = new List<Sprite>();
			Sprite sprite = SpriteManager.GetSprite("eme_cat_black_i04", "character_eme_witch");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite2 = SpriteManager.GetSprite("eme_cat_red_i04", "character_eme_witch");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite3 = SpriteManager.GetSprite("eme_cat_yellow_i04", "character_eme_witch");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite4 = SpriteManager.GetSprite("eme_cat_blue_i04", "character_eme_witch");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			_idleAnimation = idleAnimation;
		}
		ref List<Sprite> reference = ref *(List<Sprite>*)_idleAnimation;
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("eme_cat_rainbow_i0", 1, 4, "character_eme_witch", zeroPad);
		ref List<Sprite> reference2 = ref *(List<Sprite>*)animationFrames;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("eme_cat_rainbow_d0", 1, 4, "character_eme_witch", zeroPad);
		ref List<Sprite> reference3 = ref *(List<Sprite>*)animationFrames2;
	}

	protected unsafe override void OnCatPickedUp()
	{
		//IL_0030: Expected O, but got I4
		//IL_0038: Expected O, but got Ref
		base.OnCatPickedUp();
		ItemType[] types = new ItemType[1];
		_ = 101;
		List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(types);
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public Pickup_EME_RainbowCat()
	{
		base._randomiseColour = true;
		base._runSpeed = 1f;
		base._detuneValues = new float[64]
		{
			0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
			0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
			-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
			1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
			5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
			7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
			2f, 14f, 5f, 17f
		};
		((NetworkPickup)this)._002Ector();
	}
}
