using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_LEM_Inferno2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__10_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__10_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private int _killsSinceLastNaneinf;

	private int _runEnemiesKilledOnLastNaneinf;

	private LEM_Inferno1_Weapon _baseWeapon;

	private bool _totalDamageCalculated;

	public int KillsRequiredForNaneinf => 3080;

	public float NaneinfPercentage
	{
		get
		{
			//IL_001b: Invalid comparison between I4 and F4
			//IL_005e: Expected F4, but got I4
			float num = (float)_killsSinceLastNaneinf / 3080f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					return 1f;
				}
			}
			else
			{
				num = 0f;
			}
			return num;
		}
	}

	protected override void OnStart()
	{
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1874EAD80\"");
	}

	private void CreateDetachedBaseWeapon()
	{
		//IL_0059: Expected I, but got O
		//IL_0067: Expected I, but got O
		//IL_0077: Expected O, but got I
		//IL_00f7: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_0203: Expected I, but got O
		//IL_0211: Expected I, but got O
		//IL_0221: Expected O, but got I
		//IL_02a1: Expected O, but got I4
		//IL_025d: Expected O, but got I
		//IL_0293: Expected O, but got I4
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.LEM_INFERNO1, ((Equipment)this)._003COwner_003Ek__BackingField);
		Equipment equipment;
		Weapon baseWeapon;
		if ((object)weapon == null)
		{
			equipment = null;
			baseWeapon = null;
			goto IL_031b;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(LEM_Inferno1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v63+FFFFFFF8+v242 @ rax_v58*8]");
			if (0 == (nint)typeof(LEM_Inferno1_Weapon))
			{
				obj3 = 1;
				goto IL_032a;
			}
		}
		obj3 = 0;
		goto IL_032a;
		IL_039c:
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks((Weapon)equipment, _baseWeapon);
		}
		GameManager core2 = GM.Core;
		core2._levelUpFactory.ForceExclude(WeaponType.LEM_INFERNO1);
		return;
		IL_031b:
		_baseWeapon = (LEM_Inferno1_Weapon)baseWeapon;
		LEM_Inferno1_Weapon baseWeapon2 = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon2).m_CachedPtr != (IntPtr)0)
		{
			LEM_Inferno1_Weapon baseWeapon3 = _baseWeapon;
			((Weapon)baseWeapon3)._skipAddingEvolution = true;
			Equipment baseWeapon4 = _baseWeapon;
			while (!baseWeapon4.IsMaxLevel())
			{
				bool flag = _baseWeapon.LevelUp();
				baseWeapon4 = _baseWeapon;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Equipment removedEquipment = characterController._weaponsManager.GetRemovedEquipment(WeaponType.LEM_INFERNO1);
		object obj6;
		if ((object)removedEquipment != null)
		{
			nint num4 = (nint)removedEquipment;
			nint num5 = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v37+FFFFFFF8+v534 @ rax_v33*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj6 = 1;
					goto IL_037a;
				}
			}
			obj6 = 0;
			goto IL_037a;
		}
		goto IL_039c;
		IL_032a:
		bool flag2 = obj3 == null;
		equipment = null;
		baseWeapon = null;
		if (!flag2)
		{
			equipment = null;
			baseWeapon = weapon;
		}
		goto IL_031b;
		IL_037a:
		if (obj6 != null)
		{
			equipment = removedEquipment;
		}
		goto IL_039c;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00c2: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_00e0: Expected O, but got I
		//IL_0160: Expected O, but got I4
		//IL_011c: Expected O, but got I
		//IL_0152: Expected O, but got I4
		//IL_01ee: Expected I, but got O
		//IL_01f6: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_0286: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_0278: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		_killsSinceLastNaneinf = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_runEnemiesKilledOnLastNaneinf = config._003CRunEnemies_003Ek__BackingField;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.75f;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		base._003CTotalTime_003Ek__BackingField = num2;
		CharacterAccessoriesManager accessoriesManager = characterController2._accessoriesManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__10_0;
		if (_003C_003Ec._003C_003E9__10_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__10_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj8 = x._equipmentType - 1700;
				return obj8 == null;
			});
		}
		Equipment equipment = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		AccessoryLEM_ACC_SABOTEUR accessoryLEM_ACC_SABOTEUR;
		if ((object)equipment == null)
		{
			accessoryLEM_ACC_SABOTEUR = null;
			goto IL_03fd;
		}
		nint num3 = (nint)equipment;
		nint num4 = (nint)typeof(AccessoryLEM_ACC_SABOTEUR);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v59+FFFFFFF8+v425 @ rax_v55*8]");
			if (0 == (nint)typeof(AccessoryLEM_ACC_SABOTEUR))
			{
				obj4 = 1;
				goto IL_03d6;
			}
		}
		obj4 = 0;
		goto IL_03d6;
		IL_0446:
		CharacterController_LEM_SABOTEUR characterController_LEM_SABOTEUR;
		if ((object)characterController_LEM_SABOTEUR != null && ((UnityEngine.Object)characterController_LEM_SABOTEUR).m_CachedPtr != (IntPtr)0)
		{
			characterController_LEM_SABOTEUR.Deactivate();
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterAccessoriesManager accessoriesManager2 = characterController3._accessoriesManager;
		bool flag = ((List<object>)(object)((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField).Remove((object)accessoryLEM_ACC_SABOTEUR);
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterAccessoriesManager accessoriesManager3 = characterController4._accessoriesManager;
		bool flag2 = ((EquipmentManager)accessoriesManager3)._003CRemovedEquipment_003Ek__BackingField.Remove(accessoryLEM_ACC_SABOTEUR);
		return;
		IL_03d6:
		bool flag3 = obj4 == null;
		accessoryLEM_ACC_SABOTEUR = null;
		if (!flag3)
		{
			accessoryLEM_ACC_SABOTEUR = (AccessoryLEM_ACC_SABOTEUR)equipment;
		}
		goto IL_03fd;
		IL_041f:
		object obj5;
		bool flag4 = obj5 == null;
		characterController_LEM_SABOTEUR = null;
		if (!flag4)
		{
			characterController_LEM_SABOTEUR = (CharacterController_LEM_SABOTEUR)accessoryLEM_ACC_SABOTEUR.FollowerCharacterController;
		}
		goto IL_0446;
		IL_03fd:
		if ((object)accessoryLEM_ACC_SABOTEUR == null || ((UnityEngine.Object)accessoryLEM_ACC_SABOTEUR).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		accessoryLEM_ACC_SABOTEUR.AddAnimation_Saboteur();
		VampireSurvivors.Objects.Characters.CharacterController followerCharacterController = accessoryLEM_ACC_SABOTEUR.FollowerCharacterController;
		bool flag5 = (object)accessoryLEM_ACC_SABOTEUR.FollowerCharacterController == null;
		characterController_LEM_SABOTEUR = null;
		if (!flag5)
		{
			nint num6 = (nint)typeof(CharacterController_LEM_SABOTEUR);
			nint num7 = (nint)followerCharacterController;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_LEM_SABOTEUR>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_LEM_SABOTEUR>)+130]");
			if (num8 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v48+FFFFFFF8+v646 @ rax_v44*8]");
				if (0 == (nint)typeof(CharacterController_LEM_SABOTEUR))
				{
					obj5 = 1;
					goto IL_041f;
				}
			}
			obj5 = 0;
			goto IL_041f;
		}
		goto IL_0446;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int killsSinceLastNaneinf = config._003CRunEnemies_003Ek__BackingField - _runEnemiesKilledOnLastNaneinf;
		_killsSinceLastNaneinf = killsSinceLastNaneinf;
		float deltaTime = PauseSystem.DeltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (spawnedProjectiles._size <= 0)
		{
			float num3 = base.PInterval();
			if (!(num2 < deltaTime))
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
		LEM_Inferno1_Weapon baseWeapon = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon).m_CachedPtr != (IntPtr)0)
		{
			_baseWeapon.InternalUpdate();
		}
	}

	private void UpdateKillCount()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int killsSinceLastNaneinf = config._003CRunEnemies_003Ek__BackingField - _runEnemiesKilledOnLastNaneinf;
		_killsSinceLastNaneinf = killsSinceLastNaneinf;
	}

	private void ResetKillCount()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_runEnemiesKilledOnLastNaneinf = config._003CRunEnemies_003Ek__BackingField;
	}

	private void UpdateFiringInterval()
	{
		float deltaTime = PauseSystem.DeltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (spawnedProjectiles._size <= 0)
		{
			float num3 = base.PInterval();
			if (!(num2 < deltaTime))
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
	}

	private void UpdateBaseWeapon()
	{
		LEM_Inferno1_Weapon baseWeapon = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon).m_CachedPtr != (IntPtr)0)
		{
			_baseWeapon.InternalUpdate();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0099: Invalid comparison between I4 and F4
		//IL_00a8: Expected F4, but got I4
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01db: Invalid comparison between O and F4
		//IL_00eb: Expected F4, but got I4
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		if (spawnedProjectiles._size > 0)
		{
			return;
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile2 = base.FireOneProjectile(pos, 1, _targetTransform);
		float num = (float)_killsSinceLastNaneinf / 3080f;
		bool flag = 0f > num;
		float num2 = 0f;
		if (!flag)
		{
			if (!(num > 1f))
			{
				bool flag2 = num < 1f;
				num2 = 0f;
				if (flag2)
				{
					goto IL_01a2;
				}
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			((Equipment)this)._003COwner_003Ek__BackingField.IsInvul = true;
			bool flag3 = !(2f > characterController._invincibilityTimer);
			num2 = 2f;
			if (!flag3)
			{
				characterController._invincibilityTimer = 2f;
				num2 = 2f;
			}
		}
		goto IL_01a2;
		IL_01a2:
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = num2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public unsafe void TriggerNaneinf()
	{
		//IL_0064: Expected O, but got I4
		//IL_023d: Expected O, but got F4
		//IL_0106: Expected O, but got I4
		//IL_011d: Expected I, but got O
		//IL_0133: Expected O, but got I
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_01b7: Expected I, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0253: Expected O, but got I4
		//IL_027a: Expected I, but got I8
		//IL_0193: Expected I, but got I8
		Debug.Log("Naneinf");
		bool flag = default(bool);
		GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, flag);
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag2 = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (!flag2)
		{
			while (true)
			{
				List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
				if ((nint)obj < spawnedProjectiles2._size)
				{
					Projectile[] items = spawnedProjectiles2._items;
					Projectile projectile = items[obj];
					projectile.Despawn();
					obj--;
					if ((nint)projectile < 0)
					{
						break;
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
		}
		object obj2;
		if (PauseSystem._paused)
		{
			obj2 = 0;
		}
		else
		{
			object obj3 = Time.deltaTime;
			object obj4 = default(object);
			obj2 = obj4;
		}
		Action action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(Unused_LEM_Inferno2_Weapon.ResetKillCount);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num2;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_024a;
			}
		}
		num2 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_024a;
		IL_024a:
		object obj7 = 24;
		float duration = (float)obj2 * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, action, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			LEM_Inferno1_Weapon baseWeapon = _baseWeapon;
			float num = ((Weapon)baseWeapon)._003CStatsInflictedDamage_003Ek__BackingField + base._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			base._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return base._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public override void Cleanup()
	{
		_baseWeapon.Cleanup();
		base.Cleanup();
	}
}
