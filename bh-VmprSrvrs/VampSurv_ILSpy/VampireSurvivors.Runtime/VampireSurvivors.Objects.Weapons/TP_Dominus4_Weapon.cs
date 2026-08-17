using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Dominus4_Weapon : Weapon
{
	private bool _totalDamageCalculated;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private TP_Dominus1_Weapon _weaponDominus1;

	private TP_Dominus2_Weapon _weaponDominus2;

	private TP_Dominus3_Weapon _weaponDominus3;

	private BulletPool invisPool;

	private Projectile _invisProjectilePrefab;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	protected override void Awake()
	{
		base.Awake();
		_totalDamageCalculated = false;
	}

	public override float PInterval()
	{
		//IL_0043: Invalid comparison between F4 and I
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A101C8]");
			float num2 = default(float);
			WeaponData currentWeaponData = default(WeaponData);
			if (!(num2 < 0f))
			{
				currentWeaponData = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					goto IL_0076;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A101C8]");
			return 0f * currentWeaponData._003Cinterval_003Ek__BackingField;
		}
		goto IL_0076;
		IL_0076:
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_0076: Expected I, but got O
		//IL_0106: Expected I, but got O
		//IL_0114: Expected I, but got O
		//IL_0124: Expected O, but got I
		//IL_01a4: Expected O, but got I4
		//IL_0160: Expected O, but got I
		//IL_0196: Expected O, but got I4
		//IL_02bf: Expected I, but got O
		//IL_02cd: Expected I, but got O
		//IL_02dd: Expected O, but got I
		//IL_035d: Expected O, but got I4
		//IL_0319: Expected O, but got I
		//IL_034f: Expected O, but got I4
		//IL_04ba: Expected I, but got O
		//IL_04c8: Expected I, but got O
		//IL_04d8: Expected O, but got I
		//IL_0558: Expected O, but got I4
		//IL_0514: Expected O, but got I
		//IL_054a: Expected O, but got I4
		//IL_0693: Expected I, but got O
		//IL_06a1: Expected I, but got O
		//IL_06b1: Expected O, but got I
		//IL_0731: Expected O, but got I4
		//IL_06ed: Expected O, but got I
		//IL_0723: Expected O, but got I4
		//IL_078c: Expected I, but got O
		//IL_079a: Expected I, but got O
		//IL_07aa: Expected O, but got I
		//IL_082a: Expected O, but got I4
		//IL_07e6: Expected O, but got I
		//IL_081c: Expected O, but got I4
		//IL_087d: Expected I, but got O
		//IL_088b: Expected I, but got O
		//IL_089b: Expected O, but got I
		//IL_091b: Expected O, but got I4
		//IL_08d7: Expected O, but got I
		//IL_090d: Expected O, but got I4
		base.OnStart();
		BulletPool bulletPool = new BulletPool(_invisProjectilePrefab);
		invisPool = bulletPool;
		BulletPool bulletPool2 = invisPool;
		bulletPool2.UpperLimit = 200;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus4_Weapon>)+5E0]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(invisPool, core.Enemies, collideCallback, processCallback, callbackContext);
		GameManager core2 = GM.Core;
		Weapon weapon = core2._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_DOMINUS1, ((Equipment)this)._003COwner_003Ek__BackingField);
		Weapon weaponDominus;
		if ((object)weapon == null)
		{
			weaponDominus = null;
			goto IL_0a8a;
		}
		nint num2 = (nint)weapon;
		nint num3 = (nint)typeof(TP_Dominus1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v194+FFFFFFF8+v760 @ rax_v189*8]");
			if (0 == (nint)typeof(TP_Dominus1_Weapon))
			{
				obj3 = 1;
				goto IL_0a99;
			}
		}
		obj3 = 0;
		goto IL_0a99;
		IL_0c15:
		object obj4;
		bool flag = obj4 == null;
		Weapon weapon2 = null;
		Equipment removedEquipment;
		if (!flag)
		{
			weapon2 = (Weapon)removedEquipment;
		}
		goto IL_0c3c;
		IL_0b13:
		object obj5;
		bool flag2 = obj5 == null;
		Weapon weaponDominus2 = null;
		Weapon weapon3;
		if (!flag2)
		{
			weaponDominus2 = weapon3;
		}
		goto IL_0b04;
		IL_0bdf:
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		removedEquipment = characterController._weaponsManager.GetRemovedEquipment(WeaponType.TP_DOMINUS3);
		bool flag3 = (object)removedEquipment == null;
		weapon2 = null;
		if (!flag3)
		{
			nint num5 = (nint)removedEquipment;
			nint num6 = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1821 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1821 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ rax_v105+FFFFFFF8+v1822 @ rax_v101*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj4 = 1;
					goto IL_0c15;
				}
			}
			obj4 = 0;
			goto IL_0c15;
		}
		goto IL_0c3c;
		IL_0b68:
		object obj8;
		bool flag4 = obj8 == null;
		Weapon weaponDominus3 = null;
		Weapon weapon4;
		if (!flag4)
		{
			weaponDominus3 = weapon4;
		}
		goto IL_0b59;
		IL_0a99:
		bool flag5 = obj3 == null;
		weaponDominus = null;
		if (!flag5)
		{
			weaponDominus = weapon;
		}
		goto IL_0a8a;
		IL_0c3c:
		Weapon weapon5;
		if ((object)weapon5 != null && ((UnityEngine.Object)weapon5).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks(weapon5, _weaponDominus1);
		}
		Weapon weapon6;
		if ((object)weapon6 != null && ((UnityEngine.Object)weapon6).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks(weapon6, _weaponDominus2);
		}
		if ((object)weapon2 != null && ((UnityEngine.Object)weapon2).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks(weapon2, _weaponDominus3);
		}
		GameManager core3 = GM.Core;
		core3._levelUpFactory.ForceExclude(WeaponType.TP_DOMINUS1);
		GameManager core4 = GM.Core;
		core4._levelUpFactory.ForceExclude(WeaponType.TP_DOMINUS2);
		GameManager core5 = GM.Core;
		core5._levelUpFactory.ForceExclude(WeaponType.TP_DOMINUS3);
		return;
		IL_0a55:
		throw new NullReferenceException();
		IL_0a8a:
		_weaponDominus1 = (TP_Dominus1_Weapon)weaponDominus;
		TP_Dominus1_Weapon weaponDominus4 = _weaponDominus1;
		if ((object)_weaponDominus1 != null && ((UnityEngine.Object)weaponDominus4).m_CachedPtr != (IntPtr)0)
		{
			TP_Dominus1_Weapon weaponDominus5 = _weaponDominus1;
			weaponDominus5._003CInverted_003Ek__BackingField = true;
			TP_Dominus1_Weapon weaponDominus6 = _weaponDominus1;
			((Weapon)weaponDominus6)._skipAddingEvolution = true;
			TP_Dominus1_Weapon weaponDominus7 = _weaponDominus1;
			while (((Equipment)weaponDominus7)._003CLevel_003Ek__BackingField < 6)
			{
				bool flag6 = _weaponDominus1.LevelUp();
				weaponDominus7 = _weaponDominus1;
			}
		}
		GameManager core6 = GM.Core;
		weapon3 = core6._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_DOMINUS2, ((Equipment)this)._003COwner_003Ek__BackingField);
		if ((object)weapon3 == null)
		{
			weaponDominus2 = null;
			goto IL_0b04;
		}
		nint num8 = (nint)weapon3;
		nint num9 = (nint)typeof(TP_Dominus2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		if (num10 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ rax_v168+FFFFFFF8+v1039 @ rax_v163*8]");
			if (0 == (nint)typeof(TP_Dominus2_Weapon))
			{
				obj5 = 1;
				goto IL_0b13;
			}
		}
		obj5 = 0;
		goto IL_0b13;
		IL_0bee:
		object obj11;
		bool flag7 = obj11 == null;
		weapon6 = null;
		Equipment removedEquipment2;
		if (!flag7)
		{
			weapon6 = (Weapon)removedEquipment2;
		}
		goto IL_0bdf;
		IL_0b59:
		_weaponDominus3 = (TP_Dominus3_Weapon)weaponDominus3;
		TP_Dominus3_Weapon weaponDominus8 = _weaponDominus3;
		if ((object)_weaponDominus3 != null && ((UnityEngine.Object)weaponDominus8).m_CachedPtr != (IntPtr)0)
		{
			TP_Dominus3_Weapon weaponDominus9 = _weaponDominus3;
			((Weapon)weaponDominus9)._skipAddingEvolution = true;
			TP_Dominus3_Weapon weaponDominus10 = _weaponDominus3;
			while (((Equipment)weaponDominus10)._003CLevel_003Ek__BackingField < 6)
			{
				bool flag8 = _weaponDominus3.LevelUp();
				weaponDominus10 = _weaponDominus3;
				if ((object)_weaponDominus3 != null)
				{
					continue;
				}
				goto IL_0a55;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Equipment removedEquipment3 = characterController2._weaponsManager.GetRemovedEquipment(WeaponType.TP_DOMINUS1);
		if ((object)removedEquipment3 == null)
		{
			weapon5 = null;
			goto IL_0bae;
		}
		nint num11 = (nint)removedEquipment3;
		nint num12 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1631 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj14;
		if (num13 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1631 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v117+FFFFFFF8+v1633 @ rax_v113*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj14 = 1;
				goto IL_0bbd;
			}
		}
		obj14 = 0;
		goto IL_0bbd;
		IL_0bbd:
		bool flag9 = obj14 == null;
		weapon5 = null;
		if (!flag9)
		{
			weapon5 = (Weapon)removedEquipment3;
		}
		goto IL_0bae;
		IL_0b04:
		_weaponDominus2 = (TP_Dominus2_Weapon)weaponDominus2;
		TP_Dominus2_Weapon weaponDominus11 = _weaponDominus2;
		if ((object)_weaponDominus2 != null && ((UnityEngine.Object)weaponDominus11).m_CachedPtr != (IntPtr)0)
		{
			TP_Dominus2_Weapon weaponDominus12 = _weaponDominus2;
			weaponDominus12._003CInverted_003Ek__BackingField = true;
			TP_Dominus2_Weapon weaponDominus13 = _weaponDominus2;
			((Weapon)weaponDominus13)._skipAddingEvolution = true;
			TP_Dominus2_Weapon weaponDominus14 = _weaponDominus2;
			while (((Equipment)weaponDominus14)._003CLevel_003Ek__BackingField < 6)
			{
				bool flag10 = _weaponDominus2.LevelUp();
				weaponDominus14 = _weaponDominus2;
				if ((object)_weaponDominus2 != null)
				{
					continue;
				}
				goto IL_0a55;
			}
		}
		GameManager core7 = GM.Core;
		weapon4 = core7._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_DOMINUS3, ((Equipment)this)._003COwner_003Ek__BackingField);
		if ((object)weapon4 == null)
		{
			weaponDominus3 = null;
			goto IL_0b59;
		}
		nint num14 = (nint)weapon4;
		nint num15 = (nint)typeof(TP_Dominus3_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1331 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus3_Weapon>)+130]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1330 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1331 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus3_Weapon>)+130]");
		if (num16 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1330 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1396 @ rax_v142+FFFFFFF8+v1332 @ rax_v137*8]");
			if (0 == (nint)typeof(TP_Dominus3_Weapon))
			{
				obj8 = 1;
				goto IL_0b68;
			}
		}
		obj8 = 0;
		goto IL_0b68;
		IL_0bae:
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		removedEquipment2 = characterController3._weaponsManager.GetRemovedEquipment(WeaponType.TP_DOMINUS2);
		if ((object)removedEquipment2 == null)
		{
			weapon6 = null;
			goto IL_0bdf;
		}
		nint num17 = (nint)removedEquipment2;
		nint num18 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1727 @ r9_v21 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		if (num19 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1727 @ r9_v21 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1769 @ rax_v111+FFFFFFF8+v1729 @ rax_v107*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj11 = 1;
				goto IL_0bee;
			}
		}
		obj11 = 0;
		goto IL_0bee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
		TP_Dominus1_Weapon weaponDominus = _weaponDominus1;
		if ((object)_weaponDominus1 != null && ((UnityEngine.Object)weaponDominus).m_CachedPtr != (IntPtr)0)
		{
			_weaponDominus1.InternalUpdate();
		}
		TP_Dominus2_Weapon weaponDominus2 = _weaponDominus2;
		if ((object)_weaponDominus2 != null && ((UnityEngine.Object)weaponDominus2).m_CachedPtr != (IntPtr)0)
		{
			_weaponDominus2.InternalUpdate();
		}
		TP_Dominus3_Weapon weaponDominus3 = _weaponDominus3;
		if ((object)_weaponDominus3 != null && ((UnityEngine.Object)weaponDominus3).m_CachedPtr != (IntPtr)0)
		{
			_weaponDominus3.InternalUpdate();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		((Equipment)this)._003COwner_003Ek__BackingField.IsInvul = true;
		if (7.0000005f > characterController._invincibilityTimer)
		{
			characterController._invincibilityTimer = 7.0000005f;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!characterController2.DrainWeaponsImmunity)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num = characterController3.MaxHp();
			VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num2 = 7.0000005f - 1f;
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			float num4 = num3 + 1f;
			if (characterController4._currentHp > num4)
			{
				characterController4.TriggerGetDamagedByOwnWeapon(num3);
			}
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Transform target = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, target);
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Transform target = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, target);
	}

	public void FireDominusWeapons()
	{
		_weaponDominus1.Fire();
		_weaponDominus2.Fire();
		_weaponDominus3.Fire();
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
		if (_secondaryPool != null)
		{
			_secondaryPool.Cleanup();
		}
		_weaponDominus1.Cleanup();
		_weaponDominus2.Cleanup();
		_weaponDominus3.Cleanup();
		base.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		TP_Dominus1_Weapon weaponDominus = _weaponDominus1;
		_isVisible = visible;
		TP_Dominus3_Weapon weaponDominus7;
		bool visible2;
		if (!visible)
		{
			if ((object)_weaponDominus1 != null && ((UnityEngine.Object)weaponDominus).m_CachedPtr != (IntPtr)0)
			{
				TP_Dominus1_Weapon weaponDominus2 = _weaponDominus1;
				if (((Weapon)weaponDominus2)._firingTimer != null)
				{
					((Weapon)weaponDominus2)._firingTimer.Cancel();
				}
				if (((Weapon)weaponDominus2)._firingAnimEvent != null)
				{
					((Weapon)weaponDominus2)._firingAnimEvent.Cancel();
				}
				_weaponDominus1.SetVisible(visible: false);
			}
			TP_Dominus2_Weapon weaponDominus3 = _weaponDominus2;
			if ((object)_weaponDominus2 != null && ((UnityEngine.Object)weaponDominus3).m_CachedPtr != (IntPtr)0)
			{
				TP_Dominus2_Weapon weaponDominus4 = _weaponDominus2;
				if (((Weapon)weaponDominus4)._firingTimer != null)
				{
					((Weapon)weaponDominus4)._firingTimer.Cancel();
				}
				if (((Weapon)weaponDominus4)._firingAnimEvent != null)
				{
					((Weapon)weaponDominus4)._firingAnimEvent.Cancel();
				}
				_weaponDominus2.SetVisible(visible: false);
			}
			TP_Dominus3_Weapon weaponDominus5 = _weaponDominus3;
			if ((object)_weaponDominus3 == null || ((UnityEngine.Object)weaponDominus5).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			TP_Dominus3_Weapon weaponDominus6 = _weaponDominus3;
			if (((Weapon)weaponDominus6)._firingTimer != null)
			{
				((Weapon)weaponDominus6)._firingTimer.Cancel();
			}
			if (((Weapon)weaponDominus6)._firingAnimEvent != null)
			{
				((Weapon)weaponDominus6)._firingAnimEvent.Cancel();
			}
			weaponDominus7 = _weaponDominus3;
			visible2 = false;
		}
		else
		{
			if ((object)_weaponDominus1 != null && ((UnityEngine.Object)weaponDominus).m_CachedPtr != (IntPtr)0)
			{
				_weaponDominus1.ResetFiringTimer();
				_weaponDominus1.SetVisible(visible: true);
			}
			TP_Dominus2_Weapon weaponDominus8 = _weaponDominus2;
			if ((object)_weaponDominus2 != null && ((UnityEngine.Object)weaponDominus8).m_CachedPtr != (IntPtr)0)
			{
				_weaponDominus2.ResetFiringTimer();
				_weaponDominus2.SetVisible(visible: true);
			}
			TP_Dominus3_Weapon weaponDominus9 = _weaponDominus3;
			if ((object)_weaponDominus3 == null || ((UnityEngine.Object)weaponDominus9).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			_weaponDominus3.ResetFiringTimer();
			weaponDominus7 = _weaponDominus3;
			visible2 = true;
		}
		weaponDominus7.SetVisible(visible2);
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			TP_Dominus1_Weapon weaponDominus = _weaponDominus1;
			TP_Dominus2_Weapon weaponDominus2 = _weaponDominus2;
			TP_Dominus3_Weapon weaponDominus3 = _weaponDominus3;
			float num = ((Weapon)weaponDominus2)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)weaponDominus)._003CStatsInflictedDamage_003Ek__BackingField;
			float num2 = num + ((Weapon)weaponDominus3)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num3;
		}
		return base._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public void FireInvisibleProjectiles()
	{
		//IL_0057: Expected O, but got I
		//IL_00cc: Expected I, but got O
		//IL_00da: Expected I, but got O
		//IL_00ea: Expected O, but got I
		//IL_016a: Expected O, but got I4
		//IL_0126: Expected O, but got I
		//IL_015c: Expected O, but got I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		BulletPool bulletPool = invisPool;
		ObjectPool pool = bulletPool._pool;
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num - 0;
		if ((nint)obj >= 100)
		{
			return;
		}
		Projectile projectile = null;
		do
		{
			Projectile projectile2 = invisPool.SpawnAt(position, this);
			Projectile projectile3;
			if ((object)projectile2 == null)
			{
				projectile3 = null;
				goto IL_01ff;
			}
			nint num2 = (nint)projectile2;
			nint num3 = (nint)typeof(InvisibleProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
			object obj4;
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v29+FFFFFFF8+v261 @ rax_v25*8]");
				if (0 == (nint)typeof(InvisibleProjectile))
				{
					obj4 = 1;
					goto IL_01d8;
				}
			}
			obj4 = 0;
			goto IL_01d8;
			IL_01d8:
			bool flag = obj4 == null;
			projectile3 = null;
			if (!flag)
			{
				projectile3 = projectile2;
			}
			goto IL_01ff;
			IL_01ff:
			if ((object)projectile3 != null && ((UnityEngine.Object)projectile3).m_CachedPtr != (IntPtr)0)
			{
				projectile3.AimForRandomDirection();
			}
			projectile = (Projectile)(projectile + 1);
		}
		while ((nint)projectile < 12);
	}

	protected virtual bool OnBulletOverlapsEnemyOHKO(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01a8: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (!component._003CIsDead_003Ek__BackingField)
					{
						object obj = default(object);
						if ((object)component._003CResRosary_003Ek__BackingField != null && (nint)obj > 0)
						{
							if (second != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								GameObject gameObject2 = default(GameObject);
								if ((object)gameObject2 != null)
								{
									Projectile component2 = gameObject2.GetComponent<Projectile>();
									if ((object)component2 != null)
									{
										if (!component2.HasAlreadyHitObject(component))
										{
											base.DealDamage(component);
											return false;
										}
										goto IL_01c5;
									}
								}
							}
							goto IL_019a;
						}
						bool flag = !(66f < component._maxHp);
						float num = 66f;
						if (!flag)
						{
							num = component._maxHp;
						}
						component.GetDamaged(num, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
						float num2 = num + base._003CStatsInflictedDamage_003Ek__BackingField;
						base._003CStatsInflictedDamage_003Ek__BackingField = num2;
					}
					goto IL_01c5;
				}
			}
		}
		goto IL_019a;
		IL_01c5:
		return false;
		IL_019a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
