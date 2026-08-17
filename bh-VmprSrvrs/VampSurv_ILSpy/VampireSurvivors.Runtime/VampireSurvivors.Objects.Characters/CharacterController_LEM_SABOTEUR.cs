using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_LEM_SABOTEUR : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__1_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CAfterFullInitialization_003Eb__1_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 507;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private Ex_CoinToss1_Weapon coinTossWeapon;

	public override void AfterFullInitialization()
	{
		//IL_0052: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0070: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		//IL_00ac: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		base.AfterFullInitialization();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__1_0;
		if (_003C_003Ec._003C_003E9__1_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__1_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj4 = x._equipmentType - 507;
				return obj4 == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag = (object)equipment == null;
		Equipment equipment2 = equipment;
		if (flag)
		{
			goto IL_01f8;
		}
		nint num = (nint)equipment;
		nint num2 = (nint)typeof(Ex_CoinToss1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_CoinToss1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_CoinToss1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v36+FFFFFFF8+v262 @ rax_v31*8]");
			if (0 == (nint)typeof(Ex_CoinToss1_Weapon))
			{
				obj3 = 1;
				goto IL_0207;
			}
		}
		obj3 = 0;
		goto IL_0207;
		IL_0207:
		bool flag2 = obj3 == null;
		equipment2 = null;
		if (!flag2)
		{
			equipment2 = equipment;
		}
		goto IL_01f8;
		IL_01f8:
		coinTossWeapon = (Ex_CoinToss1_Weapon)equipment2;
		Ex_CoinToss1_Weapon ex_CoinToss1_Weapon = coinTossWeapon;
		if ((object)coinTossWeapon != null && ((UnityEngine.Object)ex_CoinToss1_Weapon).m_CachedPtr != (IntPtr)0)
		{
			Ex_CoinToss1_Weapon ex_CoinToss1_Weapon2 = coinTossWeapon;
			ex_CoinToss1_Weapon2._003CIsAutoFiring_003Ek__BackingField = true;
		}
		HealthBar healthBar = RenderingExtensions.SetScale(base._healthBar, 0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 419 Invalid \"Jump target not found in method: 0x1876578A0\"");
		throw new NullReferenceException();
	}

	private void LevelUpCoinTossWeapon()
	{
		Action onComplete = delegate
		{
			Ex_CoinToss1_Weapon ex_CoinToss1_Weapon = coinTossWeapon;
			if ((object)coinTossWeapon != null && ((UnityEngine.Object)ex_CoinToss1_Weapon).m_CachedPtr != (IntPtr)0 && coinTossWeapon.isActiveAndEnabled)
			{
				Ex_CoinToss1_Weapon ex_CoinToss1_Weapon2 = coinTossWeapon;
				if (((Weapon)ex_CoinToss1_Weapon2)._isVisible && !base._isDead && !base.IsDisconnectedFromOnlinePlay)
				{
					Ex_CoinToss1_Weapon ex_CoinToss1_Weapon3 = coinTossWeapon;
					if (((Equipment)ex_CoinToss1_Weapon3)._003CLevel_003Ek__BackingField < 8)
					{
						bool flag = ex_CoinToss1_Weapon3.LevelUp();
					}
					Ex_CoinToss1_Weapon ex_CoinToss1_Weapon4 = coinTossWeapon;
					if (((Equipment)ex_CoinToss1_Weapon4)._003CLevel_003Ek__BackingField < 8)
					{
						LevelUpCoinTossWeapon();
					}
				}
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(60.000004f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void Deactivate()
	{
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		weaponsManager._maxActiveCount = 0;
		weaponsManager.SetMaxWeaponCount(0, 0);
		base._isDead = true;
		_damageVfx.Stop();
		Ex_CoinToss1_Weapon ex_CoinToss1_Weapon = coinTossWeapon;
		if ((object)coinTossWeapon != null && ((UnityEngine.Object)ex_CoinToss1_Weapon).m_CachedPtr != (IntPtr)0)
		{
			coinTossWeapon.enabled = false;
			coinTossWeapon.Cleanup();
		}
		if (_deficiencyControl != null)
		{
			CharacterADControl deficiencyControl = _deficiencyControl;
			CharacterController followedCharacter = deficiencyControl._followedCharacter;
			if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
			{
				CharacterADControl deficiencyControl2 = _deficiencyControl;
				GM.Core.RefreshEnemyFollowersList(deficiencyControl2._followedCharacter);
			}
		}
		_deficiencyControl = null;
		GameManager core = GM.Core;
		PhysicsManager physicsManager = core._physicsManager;
		physicsManager._playerGroup.remove(this);
		GameManager core2 = GM.Core;
		PhysicsManager physicsManager2 = core2._physicsManager;
		physicsManager2._playersWithWallCollisionGroup.remove(this);
		if (body != null)
		{
			body.destroy();
			body = null;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void _003CLevelUpCoinTossWeapon_003Eb__2_0()
	{
		Ex_CoinToss1_Weapon ex_CoinToss1_Weapon = coinTossWeapon;
		if ((object)coinTossWeapon == null || ((UnityEngine.Object)ex_CoinToss1_Weapon).m_CachedPtr == (IntPtr)0 || !coinTossWeapon.isActiveAndEnabled)
		{
			return;
		}
		Ex_CoinToss1_Weapon ex_CoinToss1_Weapon2 = coinTossWeapon;
		if (((Weapon)ex_CoinToss1_Weapon2)._isVisible && !base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			Ex_CoinToss1_Weapon ex_CoinToss1_Weapon3 = coinTossWeapon;
			if (((Equipment)ex_CoinToss1_Weapon3)._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = ex_CoinToss1_Weapon3.LevelUp();
			}
			Ex_CoinToss1_Weapon ex_CoinToss1_Weapon4 = coinTossWeapon;
			if (((Equipment)ex_CoinToss1_Weapon4)._003CLevel_003Ek__BackingField < 8)
			{
				LevelUpCoinTossWeapon();
			}
		}
	}
}
