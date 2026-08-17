using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class PrismaticMissileWeapon : Weapon
{
	private int _currentIndex;

	[NonSerialized]
	public float FiredTimes;

	[NonSerialized]
	public ArcanaType FirstArcana;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_000f: Expected I4, but got I8
		FirstArcana = ArcanaType.VOID;
		base.InitWeapon(characterController, weaponType);
		_currentIndex = 0;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		float firedTimes = FiredTimes + 1f;
		FiredTimes = firedTimes;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0068: Expected O, but got I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c5: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				return null;
			}
			object obj = _currentIndex + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r9d\"");
			object obj2 = (object)((Equipment)this)._003COwner_003Ek__BackingField + obj;
			object obj3 = obj2 >> 2;
			object obj4 = obj3 >> 31;
			object obj5 = obj3 + obj4;
			object obj6 = obj5 * 7;
			int index2 = (_currentIndex = obj - obj6);
			if (_projectilePool != null)
			{
				float2 pos2 = default(float2);
				Projectile projectile = _projectilePool.SpawnAt(pos2, this, index2);
				if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0 && (object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					projectile.SetTarget(target);
					return projectile;
				}
				if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					projectile.SetNullTarget();
				}
				return projectile;
			}
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		if (FirstArcana == ArcanaType.VOID)
		{
			GameManager core = GM.Core;
			object obj = 0;
			object obj2 = 0;
			float newWeaponPower = default(float);
			while (true)
			{
				ArcanaManager arcanaManager = core._arcanaManager;
				List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager2 = core2._arcanaManager;
				List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)obj4 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17+20+v74 @ rdi_v7*4]");
					if ((nint)0 != 19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17+20+v74 @ rdi_v7*4]");
						if ((nint)0 != 14)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17+20+v74 @ rdi_v7*4]");
							if ((nint)0 == 2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17+20+v74 @ rdi_v7*4]");
								FirstArcana = ArcanaType.T00_KILLER;
								_explosionType = WeaponType.RAYEXPLOSION;
								_explodeOnExpire = true;
							}
						}
						else
						{
							FirstArcana = ArcanaType.T14_JEWELS;
							base._003CFreezeChance_003Ek__BackingField = 0.25f;
						}
					}
					else
					{
						GameManager gameMan = _gameMan;
						FirstArcana = ArcanaType.T19_FIRE;
						_explosionType = WeaponType.FIREEXPLOSION;
						float heartOfFirePower = base.HeartOfFirePower;
						gameMan._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
					}
					obj2++;
					core = GM.Core;
					obj = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan2._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	public PrismaticMissileWeapon()
	{
		//IL_001b: Expected I4, but got I8
		FirstArcana = ArcanaType.VOID;
		base._002Ector();
	}
}
