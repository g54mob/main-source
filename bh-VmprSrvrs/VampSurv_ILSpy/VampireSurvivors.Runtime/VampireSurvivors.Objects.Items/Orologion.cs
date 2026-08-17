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

public class Orologion : NetworkPickup
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
		List<Sprite> animation = SpriteManager.GetAnimation("PocketWatch", 1, 3, "items", flag);
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
		List<Sprite> animation = SpriteManager.GetAnimation("PocketWatch", 1, 3, "items", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		//IL_006b: Expected I, but got O
		//IL_0079: Expected I, but got O
		//IL_0089: Expected O, but got I
		//IL_0109: Expected O, but got I4
		//IL_00c5: Expected O, but got I
		//IL_00fb: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
		Weapon weaponByType = targetPlayer._weaponsManager.GetWeaponByType(WeaponType.ICELANCE2);
		GlassFandango2Weapon glassFandango2Weapon;
		bool flag;
		if ((object)weaponByType == null)
		{
			glassFandango2Weapon = null;
			flag = false;
			goto IL_0218;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(GlassFandango2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v31+FFFFFFF8+v214 @ rax_v27*8]");
			if (0 == (nint)typeof(GlassFandango2Weapon))
			{
				obj3 = 1;
				goto IL_01e9;
			}
		}
		obj3 = 0;
		goto IL_01e9;
		IL_0218:
		bool flag2 = (object)glassFandango2Weapon == null;
		object obj4 = 0;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)glassFandango2Weapon).m_CachedPtr == (IntPtr)0;
			obj4 = 0;
			if (!flag3)
			{
				glassFandango2Weapon.StartStarryHeavens();
				obj4 = 1;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
		base.AddToRunPickups();
		base.SetHasSeenItem();
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
		return;
		IL_01e9:
		bool flag4 = obj3 == null;
		glassFandango2Weapon = null;
		flag = (byte)num != 0;
		if (!flag4)
		{
			glassFandango2Weapon = (GlassFandango2Weapon)weaponByType;
			flag = (byte)num != 0;
		}
		goto IL_0218;
	}
}
