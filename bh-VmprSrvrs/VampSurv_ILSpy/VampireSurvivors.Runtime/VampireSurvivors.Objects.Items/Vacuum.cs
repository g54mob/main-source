using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Vacuum : NetworkPickup
{
	public override void SetData(ItemType itemType)
	{
		//IL_0075: Expected O, but got I4
		//IL_0075: Expected I4, but got O
		base.SetData(itemType);
		_spriteAnimation.CleanAnimations();
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Vacuum", 1, 3, pivot, text, num, flag);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 10, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		_spriteAnimation.SetAnimation("Idle");
	}

	private void OnRecycle()
	{
		//IL_006b: Expected O, but got I4
		//IL_006b: Expected I4, but got O
		_spriteAnimation.CleanAnimations();
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Vacuum", 1, 3, pivot, text, num, flag);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 10, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		_spriteAnimation.SetAnimation("Idle");
	}

	public override void GetTaken()
	{
		//IL_003e: Expected O, but got I4
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			_gameManager.TurnOnVacuum(_targetPlayer);
			base.AddToRunPickups();
			base.SetHasSeenItem();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 0f, 10, time);
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}
}
