using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_TP_MirrorOfTruth : NetworkPickup
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
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_MIRROR_OF_TRUTH", 1, 3, _textureName, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public unsafe override void GetTaken()
	{
		//IL_0049: Expected F4, but got I4
		//IL_0086: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_01de: Expected F4, but got I4
		//IL_01e6: Expected O, but got Ref
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Powerup, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		CharacterController_Support targetPlayer = (CharacterController_Support)(object)_targetPlayer;
		if ((object)_targetPlayer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rcx_v6 (VampireSurvivors.Objects.Characters.CharacterController_Support)+90]");
			targetPlayer = (CharacterController_Support)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rcx_v6 (VampireSurvivors.Objects.Characters.CharacterController_Support)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rcx_v6 (VampireSurvivors.Objects.Characters.CharacterController_Support)+90]");
				((CharacterController_Support)0).AddActiveMirrorOfTruth(1f, 0f, 10000f);
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				bool flag = (object)_targetPlayer == null;
				targetPlayer = (CharacterController_Support)(object)_targetPlayer;
				if (!flag)
				{
					if (targetPlayer2._isDead || _targetPlayer.IsDisconnectedFromOnlinePlay)
					{
						goto IL_0342;
					}
					VampireSurvivors.Objects.Characters.CharacterController targetPlayer3 = _targetPlayer;
					if ((object)_targetPlayer != null)
					{
						CharacterWeaponsManager weaponsManager = targetPlayer3._weaponsManager;
						if ((object)targetPlayer3._weaponsManager != null)
						{
							List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
							if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
							{
								int num = 1;
								List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
								if (enumerator.MoveNext())
								{
									float num2 = 0f;
									CharacterWeaponsManager characterWeaponsManager = (CharacterWeaponsManager)(&enumerator);
									throw new NullReferenceException();
								}
								goto IL_0342;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0342:
		base.AddToRunPickups();
		base.SetHasSeenItem();
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
	}
}
