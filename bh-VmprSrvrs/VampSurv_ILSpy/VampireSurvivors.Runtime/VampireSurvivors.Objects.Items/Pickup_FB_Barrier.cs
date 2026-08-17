using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_FB_Barrier : NetworkPickup
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
		OnRecycle();
	}

	protected virtual void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fb_barrier", 1, 3, _textureName, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		//IL_0038: Expected F4, but got I4
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Powerup, 100f, 1, 0f, volume, rate, detune, loop, 1f);
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if (10f > targetPlayer.Barrier_Number)
			{
				float barrier_Number = targetPlayer.Barrier_Number + 1f;
				targetPlayer.Barrier_Number = barrier_Number;
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
