using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Items;

public class RosaryX : Rosary
{
	private Stage _stage;

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	public override void SetData(ItemType itemType)
	{
		((Pickup)this).SetData(ItemType.ROSARY);
		OnRecycle();
	}

	protected override void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Rosary", 1, 3, "items", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
	}

	public override void GetTaken()
	{
		Stage stage = _stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			stage2._fancyBg.RosaryTriggered();
		}
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			if (!_targetPlayer.HasSeraphicCry(out var seraphicCry))
			{
				bool setDark = default(bool);
				_gameManager.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
			}
			else
			{
				seraphicCry.StartWeirdSoulsPurifier();
			}
			base.AddToRunPickups();
			base.SetHasSeenItem();
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}
}
