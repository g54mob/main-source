using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_TP_SoulStealLittleHeart : Pickup
{
	public float _Volume = 0.6f;

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
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_SoulSteal0", 4, 8, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		//IL_00c4: Expected O, but got F4
		//IL_005e: Expected F4, but got I4
		//IL_0090: Expected F4, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			_targetPlayer.RecoverHp(1f, showRecovery: true, mulByRegen: true);
			base.SetHasSeenItem();
			base.GetTaken();
			object obj = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Recovery, 200f, 3, 0f, volume, rate, detune, loop, 1f);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Recovery, 200f, 3, 0f, volume, rate, detune, loop, 1f);
		}
	}
}
