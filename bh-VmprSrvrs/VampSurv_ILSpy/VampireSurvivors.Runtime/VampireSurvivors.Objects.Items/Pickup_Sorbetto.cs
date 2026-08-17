using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Items;

public class Pickup_Sorbetto : Pickup
{
	private void Construct(GameSessionData gameSessionData)
	{
		_gameSessionData = gameSessionData;
	}

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
		List<Sprite> animation = SpriteManager.GetAnimation("sorbetto", 1, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	private void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("sorbetto", 1, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		//IL_0150: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			TryAddSorbetto();
			base.AddToRunPickups();
			base.SetHasSeenItem();
			GameManager gameManager = _gameManager;
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			bool flag = targetPlayer._deficiencyControl == null;
			bool flag2 = true;
			if (!flag)
			{
				CharacterADControl deficiencyControl = targetPlayer._deficiencyControl;
				object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
				bool flag3 = obj == null;
				flag2 = !flag3;
			}
			int num = targetPlayer._PlayerIndex >> 31;
			int num2 = (flag2 ? 1 : 0) & num;
			bool flag4 = num2 == 0;
			object obj2 = !flag4;
			if (obj2 == null && arcanaManager._hasBreadAnathema)
			{
				arcanaManager.arcanaManager_Support.OnFoodPickedUp(targetPlayer, base._003CPickupType_003Ek__BackingField, base._003CValue_003Ek__BackingField);
			}
			base.GetTaken();
		}
	}

	private void TryAddSorbetto()
	{
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
		Weapon weaponByType = targetPlayer._weaponsManager.GetWeaponByType(WeaponType.CONEOFCOLD, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			float num = weaponByType._003CTotalTime_003Ek__BackingField - 10000f;
			bool flag = 1f > num;
			float num2 = 1f;
			if (!flag)
			{
				num2 = num;
			}
			weaponByType._003CTotalTime_003Ek__BackingField = num2;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			Weapon weaponByType2 = activeCharacter._weaponsManager.GetWeaponByType(WeaponType.CONEOFCOLD_COUNTER, searchHidden: true);
			if ((object)weaponByType2 != null && ((UnityEngine.Object)weaponByType2).m_CachedPtr != (IntPtr)0)
			{
				weaponByType2._003CTotalTime_003Ek__BackingField = weaponByType._003CTotalTime_003Ek__BackingField;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
		}
	}
}
