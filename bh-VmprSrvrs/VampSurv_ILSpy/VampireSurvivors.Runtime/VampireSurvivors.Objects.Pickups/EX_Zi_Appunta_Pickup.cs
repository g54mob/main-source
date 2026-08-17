using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Pickups;

public class EX_Zi_Appunta_Pickup : Pickup
{
	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("ziappunta_pickup_", 1, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idol", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("Idol");
	}

	private void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("ziappunta_pickup_", 1, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idol", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("Idol");
	}
}
