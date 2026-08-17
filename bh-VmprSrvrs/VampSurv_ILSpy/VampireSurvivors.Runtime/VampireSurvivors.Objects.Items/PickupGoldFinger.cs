using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupGoldFinger : NetworkPickup
{
	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("goldenFinger", 0, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			base.SetHasSeenItem();
			base.AddToRunPickups();
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
			GameManager core = GM.Core;
			core._003CGoldFingerManager_003Ek__BackingField.ActivateGoldFinger(_targetPlayer);
		}
	}
}
