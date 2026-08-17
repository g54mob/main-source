using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class Silf2Weapon : SilfWeapon
{
	protected override float OffsetX()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._isFlipped)
		{
			return -0.24f;
		}
		return 0.24f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0066: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5910]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_counterWeaponType = WeaponType.SILF2_COUNTER;
		_birdSprite = "ProjectileBird4";
		_birdAnimPrefix = "ProjectileBird";
		_birdAnimStartFrame = 4;
		_birdAnimFrameCount = 2;
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12480]");
		_targetZoneCol = (Color)0;
		base.InitWeapon(characterController, weaponType);
	}

	protected override void UpdateTargetZonePos(SpriteRenderer targetZone, float angle)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0114->IL0086: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = angle ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj2 = angle ^ 0;
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
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_013e->IL00ef: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (damageZone != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj = angle ^ 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					object obj2 = obj * _damageZoneDistance;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj3 = angle ^ 0;
					float x = (float)obj2 + (float)ret;
					damageZone._x = x;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					object obj4 = obj3 * _damageZoneDistance;
					object obj5 = default(object);
					float y = (float)obj4 + (float)obj5;
					damageZone._y = y;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
