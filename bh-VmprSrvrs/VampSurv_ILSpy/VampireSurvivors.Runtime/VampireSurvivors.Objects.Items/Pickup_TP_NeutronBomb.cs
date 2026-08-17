using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Items;

public class Pickup_TP_NeutronBomb : NetworkPickup
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
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_NEUTRON_BOMB_PICKUP_", 1, 3, _textureName, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			Weapon weaponByType = targetPlayer._weaponsManager.GetWeaponByType(WeaponType.TP_NEUTRON_PICKUP, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				weaponByType.Fire(skipTriggers: true);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
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

	private void TryAddWeapon()
	{
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
		Weapon weaponByType = targetPlayer._weaponsManager.GetWeaponByType(WeaponType.TP_NEUTRON_PICKUP, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			weaponByType.Fire(skipTriggers: true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
		}
	}
}
