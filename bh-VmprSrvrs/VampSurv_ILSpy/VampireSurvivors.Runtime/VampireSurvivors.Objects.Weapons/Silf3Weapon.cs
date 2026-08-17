using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class Silf3Weapon : SilfWeapon
{
	private SpriteRenderer _TargetZone2;

	protected Circle _damageZone2;

	protected WeaponType _counterWeaponType1 = WeaponType.SILF_COUNTER;

	protected WeaponType _counterWeaponType2 = WeaponType.SILF2_COUNTER;

	protected Weapon _counterWeapon1;

	protected Weapon _counterWeapon2;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0038: Expected O, but got I
		_runSpeed = GameManager.PlayerPxSpeed;
		_damageZoneDefaultRadius = 0.75f;
		_RayDuration = 400f;
		_birdSprite = "ProjectileBird7";
		_birdAnimPrefix = "ProjectileBird";
		_birdAnimStartFrame = 7;
		_birdAnimFrameCount = 2;
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_targetZoneCol = (Color)0;
		base.InitWeapon(characterController, weaponType);
		SetupTargetZone(_TargetZone2);
		Circle circle = new Circle();
		circle._radius = _damageZoneDefaultRadius;
		circle._x = 0f;
		_damageZone2 = circle;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00de: Expected O, but got Ref
		//IL_015b: Expected I, but got O
		//IL_0296->IL0260: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		if (!IsHoming)
		{
			float angle = _targetZoneAngle ^ -0f;
			base.UpdateTargetZonePos(_TargetZone2, angle);
			float angle2 = _damageZoneAngle ^ -0f;
			base.UpdateDamageZonePos(_damageZone2, angle2);
			return;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)core._stage != null)
					{
						Vector3 value = default(Vector3);
						EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&value));
						if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						Transform damageZone = (Transform)(object)_damageZone2;
						float2 position = enemyController.position;
						if (_damageZone2 != null)
						{
							((UnityEngine.Object)damageZone).m_CachedPtr = (IntPtr)position;
							if ((object)_TargetZone2 != null)
							{
								Transform transform2 = _TargetZone2.transform;
								float2 position2 = enemyController.position;
								bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		//IL_0100: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0118: Expected O, but got I
		//IL_0198: Expected O, but got I4
		//IL_0154: Expected O, but got I
		//IL_018a: Expected O, but got I4
		//IL_0296: Expected I, but got O
		//IL_029e: Expected I, but got O
		//IL_02ae: Expected O, but got I
		//IL_032e: Expected O, but got I4
		//IL_02ea: Expected O, but got I
		//IL_0320: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			goto IL_041d;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType1, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			goto IL_01e9;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType1, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		nint num = (nint)typeof(SilfWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rcx_v51+FFFFFFF8+v578 @ rcx_v43*8]");
			if (0 == (nint)typeof(SilfWeapon))
			{
				obj4 = 1;
				goto IL_0446;
			}
		}
		obj4 = 0;
		goto IL_0446;
		IL_01e9:
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType2 = characterController2._weaponsManager.GetWeaponByType(_counterWeaponType2, searchHidden: true);
		Weapon weapon2;
		object obj7;
		if ((object)weaponByType2 == null || ((UnityEngine.Object)weaponByType2).m_CachedPtr == (IntPtr)0)
		{
			GameManager core3 = GM.Core;
			weapon2 = core3._weaponsFacade.AddHiddenWeapon(_counterWeaponType2, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
			nint num4 = (nint)typeof(SilfWeapon);
			nint num5 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rcx_v36+FFFFFFF8+v860 @ rcx_v28*8]");
				if (0 == (nint)typeof(SilfWeapon))
				{
					obj7 = 1;
					goto IL_04b0;
				}
			}
			obj7 = 0;
			goto IL_04b0;
		}
		goto IL_04f8;
		IL_04b0:
		bool flag = obj7 == null;
		Weapon weapon3 = null;
		if (!flag)
		{
			weapon3 = weapon2;
		}
		_ = _TotalTime;
		float num7 = _AngleTime + (float)Math.PI;
		_counterWeapon2 = weapon3;
		while (((Equipment)weapon3)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag2 = weapon3.LevelUp();
		}
		goto IL_04f8;
		IL_0446:
		bool flag3 = obj4 == null;
		Weapon weapon4 = null;
		if (!flag3)
		{
			weapon4 = weapon;
		}
		_ = _TotalTime;
		num7 = _AngleTime + (float)Math.PI;
		_counterWeapon1 = weapon4;
		while (((Equipment)weapon4)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag4 = weapon4.LevelUp();
		}
		goto IL_01e9;
		IL_04f8:
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj8 = default(object);
			if ((nint)obj8 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		goto IL_041d;
		IL_041d:
		base.CheckArcanas();
	}

	public override bool LevelUp()
	{
		//IL_013f: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				goto IL_0131;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		Weapon counterWeapon2 = _counterWeapon1;
		if ((object)_counterWeapon1 != null && ((UnityEngine.Object)counterWeapon2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon1 == null)
			{
				goto IL_0131;
			}
			bool flag2 = _counterWeapon1.LevelUp();
		}
		Weapon counterWeapon3 = _counterWeapon2;
		if ((object)_counterWeapon2 != null && ((UnityEngine.Object)counterWeapon3).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon2 == null)
			{
				goto IL_0131;
			}
			bool flag3 = _counterWeapon2.LevelUp();
		}
		return result;
		IL_0131:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_014b: Expected I4, but got O
		bool result = ((Weapon)this).ApplyLimitBreak(weightedLimitBreak);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				goto IL_013d;
			}
			bool flag = _counterWeapon.ApplyLimitBreak(weightedLimitBreak);
		}
		Weapon counterWeapon2 = _counterWeapon1;
		if ((object)_counterWeapon1 != null && ((UnityEngine.Object)counterWeapon2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon1 == null)
			{
				goto IL_013d;
			}
			bool flag2 = _counterWeapon1.ApplyLimitBreak(weightedLimitBreak);
		}
		Weapon counterWeapon3 = _counterWeapon2;
		if ((object)_counterWeapon2 != null && ((UnityEngine.Object)counterWeapon3).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon2 == null)
			{
				goto IL_013d;
			}
			bool flag3 = _counterWeapon2.ApplyLimitBreak(weightedLimitBreak);
		}
		return result;
		IL_013d:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void SetVisible(bool visible)
	{
		base.SetVisible(visible);
		SpriteRenderer targetZone = _TargetZone2;
		if ((object)_TargetZone2 != null && ((UnityEngine.Object)targetZone).m_CachedPtr != (IntPtr)0)
		{
			_TargetZone2.enabled = visible;
		}
	}

	protected override void AddTargets()
	{
		//IL_01e4: Expected O, but got I4
		//IL_003c: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_01a2: Expected O, but got I4
		//IL_00f4: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		object obj = 0;
		bool flag;
		object obj4;
		do
		{
			List<Vector2> targets = _Targets;
			Vector2 randomPoint = _damageZone.GetRandomPoint();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v5+18]");
			if (num >= 0)
			{
				targets.AddWithResize(randomPoint);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			obj++;
			flag = (nint)obj < 12;
			obj4 = 0;
		}
		while (flag);
		do
		{
			List<Vector2> targets2 = _Targets;
			Vector2 randomPoint2 = _damageZone2.GetRandomPoint();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v9+18]");
			if (num2 >= 0)
			{
				targets2.AddWithResize(randomPoint2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj7 = (nint)0 + (nint)1;
			}
			obj4++;
		}
		while ((nint)obj4 < 12);
	}

	protected override void BlockFire()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		float num = base.PDuration();
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = default(object);
		object obj = obj2 ^ 0;
		float num3 = (float)obj * _delayBasedOnDuration;
		_blockFire = true;
		float num4 = (_TotalTime = (float)obj2 * num3);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOff);
		float num5 = base.PDuration();
		if (!(_TotalTime < num4))
		{
			_TotalTime = 0f;
			_blockFire = false;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOn);
		}
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_TargetZone2, _targetZoneAlphaOff);
	}

	protected override void UnblockFire()
	{
		_blockFire = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOn);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_TargetZone2, _targetZoneAlphaOn);
	}
}
