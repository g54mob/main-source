using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class SilfCounterWeapon : SilfWeapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_birdSprite = "ProjectileBird_C2";
		_birdAnimPrefix = "ProjectileBird_C";
		_offsetY = 0.24f;
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		_damageZoneDistance = 1.5f;
		_damageZoneDefaultRadius = 0.5f;
		SetupTargetZone(_TargetZone);
		Circle circle = new Circle();
		circle._radius = _damageZoneDefaultRadius;
		circle._x = 0f;
		_damageZone = circle;
	}

	protected override float OffsetX()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._isFlipped)
		{
			return 0.36f;
		}
		return -0.36f;
	}

	protected override void UpdateTargetZonePos(SpriteRenderer targetZone, float angle)
	{
		//IL_00ea->IL0086: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				if ((object)targetZone != null)
				{
					Transform transform2 = targetZone.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void UpdateDamageZonePos(Circle damageZone, float angle)
	{
		//IL_0118->IL00c9: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (damageZone != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num = angle * _damageZoneDistance;
					float x = num + (float)ret;
					damageZone._x = x;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num2 = angle * _damageZoneDistance;
					object obj = default(object);
					float y = num2 + (float)obj;
					damageZone._y = y;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}
}
