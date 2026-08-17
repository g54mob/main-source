using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class Ex_Ammo1Weapon : Weapon
{
	private bool _multitickDamage;

	private float _rapidFireDamageInterval = 0.7f;

	private int _ticksPerRapidFire = 10;

	private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

	private Weapon _counterWeapon;

	private readonly List<RapidDamageInstance> _rapidDamageInstances;

	public virtual bool FireInTheFacedDirection => true;

	public override void DealDamage(IDamageable other, float damage)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		EnemyController enemyController;
		if (other == null)
		{
			enemyController = null;
			goto IL_01e4;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v8 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v8 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v30+FFFFFFF8+v57 @ rax_v26*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_01bd;
			}
		}
		obj3 = 0;
		goto IL_01bd;
		IL_01bd:
		bool flag = obj3 == null;
		enemyController = null;
		if (!flag)
		{
			enemyController = (EnemyController)other;
		}
		goto IL_01e4;
		IL_01e4:
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0 && _multitickDamage)
		{
			float damagePerHit = default(float);
			float damageInterval = default(float);
			RapidDamageInstance rapidDamageInstance = new RapidDamageInstance(this, enemyController, damage, damagePerHit, damageInterval);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F8F20");
		}
		else
		{
			if (other == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj4 = default(object);
			if (obj4 == null)
			{
				if (_currentWeaponData != null)
				{
				}
				float knockback = base.Knockback;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD810");
				float num4 = damage + base._003CStatsInflictedDamage_003Ek__BackingField;
				base._003CStatsInflictedDamage_003Ek__BackingField = num4;
			}
		}
	}

	public override void InternalUpdate()
	{
		//IL_0200: Expected O, but got I
		//IL_0036: Expected O, but got I4
		//IL_0072: Expected O, but got I
		//IL_0245: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_03f0: Expected O, but got F4
		//IL_0400: Expected F4, but got I
		//IL_00a0: Expected F4, but got I4
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_0382: Expected O, but got I4
		//IL_02d3: Expected O, but got I
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_0303: Expected O, but got I
		//IL_0142: Expected O, but got I
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		base.InternalUpdate();
		List<RapidDamageInstance> rapidDamageInstances = _rapidDamageInstances;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_01ca;
		}
		object obj = 0;
		RapidDamageInstance rapidDamageInstance2 = default(RapidDamageInstance);
		bool showDamageNumbers = default(bool);
		while (true)
		{
			List<RapidDamageInstance> rapidDamageInstances2 = _rapidDamageInstances;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbp_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbp_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
			object obj3 = 0;
			object obj4 = obj * 4;
			object obj5 = obj + obj4;
			float deltaTime;
			if (PauseSystem._paused)
			{
				deltaTime = 0f;
			}
			else
			{
				object obj6 = Time.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v18+40+v682 @ rcx_v19*8]");
				deltaTime = 0f;
			}
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._onlineClientWithRunDataConfig == null && playerOptions._hostGameConfig == null && playerOptions._currentAdventureSaveData != null)
			{
				PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
				if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
				{
				}
			}
			RapidDamageInstance rapidDamageInstance = rapidDamageInstance2.Update(deltaTime, _signalBus, showDamageNumbers);
			object obj7 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbp_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			if ((nint)obj7 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbp_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
			object obj8 = 0;
			object obj9 = obj * 4;
			object obj10 = obj + obj9;
			_ = rapidDamageInstance.RemainingDamage;
			_ = rapidDamageInstance.Target;
			_ = rapidDamageInstance._timeUntilNextDamage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbp_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+1C]");
			_ = (nint)0 + (nint)1;
			obj++;
			object obj11 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			if ((nint)obj11 < 0)
			{
				continue;
			}
			goto IL_01ca;
		}
		goto IL_0391;
		IL_0391:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_01ca:
		List<RapidDamageInstance> rapidDamageInstances3 = _rapidDamageInstances;
		bool flag = (nint)_rapidDamageInstances < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
		object obj12 = -1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<RapidDamageInstance> rapidDamageInstances4 = _rapidDamageInstances;
			object obj13 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			if ((nint)obj13 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
			object obj14 = 0;
			object obj15 = obj12 * 4;
			object obj16 = obj12 + obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v10+20+v208 @ rcx_v12*8]");
			bool flag2;
			if ((nint)0 < (nint)0)
			{
				List<RapidDamageInstance> rapidDamageInstances5 = _rapidDamageInstances;
				object obj17 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
				if ((nint)obj17 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
				object obj18 = 0;
				object obj19 = obj12 * 4;
				object obj20 = obj12 + obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v15+30+v209 @ rcx_v16*8]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v20+260]");
				flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v20+260]");
				if ((nint)0 == 0)
				{
					goto IL_0369;
				}
			}
			flag2 = (nint)_rapidDamageInstances < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F9370");
			goto IL_0369;
			IL_0369:
			obj12--;
			object obj22 = !flag2;
			if (obj22 == null)
			{
				return;
			}
		}
		goto IL_0391;
	}

	public override void CheckArcanas()
	{
		//IL_011d: Expected I, but got O
		//IL_012b: Expected I, but got O
		//IL_013b: Expected O, but got I
		//IL_01bb: Expected O, but got I4
		//IL_0177: Expected O, but got I
		//IL_01ad: Expected O, but got I4
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected I4, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected I4, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_01f8: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			goto IL_021b;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.EX_AMMO1_COUNTER, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(WeaponType.EX_AMMO1_COUNTER, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		Weapon counterWeapon;
		if ((object)weapon == null)
		{
			counterWeapon = null;
			goto IL_0257;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(Ex_Ammo1Weapon_Counter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rax_v43+FFFFFFF8+v420 @ rax_v38*8]");
			if (0 == (nint)typeof(Ex_Ammo1Weapon_Counter))
			{
				obj4 = 1;
				goto IL_0266;
			}
		}
		obj4 = 0;
		goto IL_0266;
		IL_0266:
		bool flag = obj4 == null;
		counterWeapon = null;
		if (!flag)
		{
			counterWeapon = weapon;
		}
		goto IL_0257;
		IL_021b:
		CheckBeginningArcana();
		return;
		IL_0257:
		_counterWeapon = counterWeapon;
		while (true)
		{
			Weapon weapon2 = (((object)_counterWeapon == null) ? null : ((Weapon)1));
			object obj5 = (object)weapon2 >> 32;
			object obj6 = obj5 - ((Equipment)this)._003CLevel_003Ek__BackingField;
			int num4 = obj5 ^ ((Equipment)this)._003CLevel_003Ek__BackingField;
			object obj7 = obj5 ^ obj6;
			int num5 = num4 & obj7;
			bool flag2 = num5 < 0;
			bool flag3 = (nint)obj6 < 0;
			bool flag4 = flag3 != flag2;
			object obj8 = weapon2 & flag4;
			if (obj8 == null)
			{
				break;
			}
			bool flag5 = _counterWeapon.LevelUp();
		}
		goto IL_021b;
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public Ex_Ammo1Weapon()
	{
		List<RapidDamageInstance> rapidDamageInstances = new List<RapidDamageInstance>();
		_rapidDamageInstances = rapidDamageInstances;
		base._002Ector();
	}
}
