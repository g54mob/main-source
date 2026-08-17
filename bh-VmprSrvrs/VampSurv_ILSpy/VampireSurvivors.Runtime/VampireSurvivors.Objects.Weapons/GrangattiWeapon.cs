using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GrangattiWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public float value;

		internal void _003CTurnToGold_003Eb__0(Pickup c)
		{
			if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
			{
				c.Time = 1f;
				c.GoToPlayer = true;
				c._003CValue_003Ek__BackingField = value;
				c._003CFeverMS_003Ek__BackingField = 50f;
			}
		}
	}

	private List<float> _RANDOMS;

	private int _randomIndex;

	private int _plusMinusIndex;

	private List<float> _PLUSMINUS;

	private double _chanceBonus;

	private int _success = 1;

	private int _fail = 1;

	private static ItemType[] _gold = new ItemType[3]
	{
		ItemType.COIN,
		ItemType.COINBAG1,
		ItemType.COINBAGMAX
	};

	private static ItemType[] _edible = new ItemType[7]
	{
		ItemType.ROAST,
		ItemType.CLOVER,
		ItemType.OROLOGION,
		ItemType.ROSARY,
		ItemType.NFT,
		ItemType.GEM,
		ItemType.VACUUM
	};

	private static ItemType[] _ignore;

	protected WeaponType _counterWeaponType = WeaponType.GATTI_COUNTER;

	protected Weapon _counterWeapon;

	public double goldChance = 0.005;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_001d: Expected O, but got I4
		//IL_00b4: Expected O, but got I
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_010d: Expected O, but got I4
		//IL_0135: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		_randomIndex = 0;
		List<float> rANDOMS = new List<float>();
		_RANDOMS = rANDOMS;
		object obj = 0;
		float item;
		do
		{
			List<float> rANDOMS2 = _RANDOMS;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num = 0;
			item = (float)obj / 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r8_v7 (Il2CppMethodInfo)+18]");
			if (num2 >= 0)
			{
				rANDOMS2.AddWithResize(item);
				num = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = (nint)0 + (nint)1;
			}
			obj++;
		}
		while ((nint)obj < 1000);
		VampireSurvivors.App.Tools.Extensions.Shuffle(_RANDOMS);
		_plusMinusIndex = 0;
		List<float> list = null;
		list.Add(item);
		_PLUSMINUS = list;
		object obj3 = 0;
		do
		{
			List<float> pLUSMINUS = _PLUSMINUS;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj5 = 0;
			float item2 = (float)obj3 / 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v10+18]");
			if (num3 >= 0)
			{
				pLUSMINUS.AddWithResize(item2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
			}
			obj3++;
		}
		while ((nint)obj3 < 1000);
		VampireSurvivors.App.Tools.Extensions.Shuffle(_PLUSMINUS);
		goldChance = 0.005;
		_chanceBonus = 0.0;
	}

	public override void CheckArcanas()
	{
		//IL_034c: Expected I, but got O
		//IL_035a: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_03ea: Expected O, but got I4
		//IL_03a6: Expected O, but got I
		//IL_03dc: Expected O, but got I4
		//IL_01c0: Expected I, but got O
		//IL_01c8: Expected I, but got O
		//IL_01d8: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_0251: Expected O, but got I
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_07f8: Expected I, but got O
		//IL_0800: Expected I, but got O
		//IL_0810: Expected O, but got I
		//IL_02a4: Expected O, but got I
		//IL_02e8: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		object obj9;
		if ((nint)obj2 > -1)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				List<string> list3 = new List<string>();
				list3.Add("cat_i0");
				list3.Add("cat3_i0");
				list3.Add("cat2_i0");
				list3.Add("cat4_i0");
				list3.Add("cat6_i0");
				list3.Add("cat5_i0");
				nint num = (nint)typeof(GattiCounterWeapon);
				nint num2 = (nint)weaponByType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v91+FFFFFFF8+v148 @ rax_v90*8]");
					if (0 == (nint)typeof(GattiCounterWeapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v91+FFFFFFF8+v860 @ rcx_v65*8]");
						object obj6 = 0 - typeof(GattiCounterWeapon);
						bool flag = obj6 == null;
						bool flag2 = !flag;
						Weapon weapon = null;
						if (flag2)
						{
							nint num4 = (nint)typeof(GattiCounterWeapon);
							nint num5 = (nint)weaponByType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
							if (num6 < 0)
							{
								goto IL_02df;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v915 @ rax_v103+FFFFFFF8+v890 @ rax_v93*8]");
						if (0 != (nint)typeof(GattiCounterWeapon))
						{
							goto IL_02df;
						}
						obj9 = 1;
						goto IL_083c;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_02ed;
		}
		goto IL_07a2;
		IL_0863:
		object obj10;
		bool flag3 = obj10 == null;
		Weapon weapon2 = null;
		Weapon weapon3;
		if (!flag3)
		{
			weapon2 = weapon3;
		}
		goto IL_0854;
		IL_02ed:
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		weapon3 = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag4 = (object)weapon3 == null;
		weapon2 = null;
		if (flag4)
		{
			goto IL_0854;
		}
		nint num7 = (nint)weapon3;
		nint num8 = (nint)typeof(GattiCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiCounterWeapon>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rax_v79+FFFFFFF8+v712 @ rax_v75*8]");
			if (0 == (nint)typeof(GattiCounterWeapon))
			{
				obj10 = 1;
				goto IL_0863;
			}
		}
		obj10 = 0;
		goto IL_0863;
		IL_083c:
		if (obj9 == null)
		{
			goto IL_02ed;
		}
		goto IL_0854;
		IL_07a2:
		CheckBeginningArcana();
		return;
		IL_0854:
		List<string> list4 = new List<string>();
		int version = list4._version + 1;
		list4._version = version;
		string[] items = list4._items;
		if (list4._size >= items.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat_i0");
		}
		else
		{
			int size = list4._size + 1;
			list4._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list4._version + 1;
		list4._version = version2;
		string[] items2 = list4._items;
		if (list4._size >= items2.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat3_i0");
		}
		else
		{
			int size2 = list4._size + 1;
			list4._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list4._version + 1;
		list4._version = version3;
		string[] items3 = list4._items;
		if (list4._size >= items3.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat2_i0");
		}
		else
		{
			int size3 = list4._size + 1;
			list4._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list4._version + 1;
		list4._version = version4;
		string[] items4 = list4._items;
		if (list4._size >= items4.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat4_i0");
		}
		else
		{
			int size4 = list4._size + 1;
			list4._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list4._version + 1;
		list4._version = version5;
		string[] items5 = list4._items;
		if (list4._size >= items5.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat6_i0");
		}
		else
		{
			int size5 = list4._size + 1;
			list4._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list4._version + 1;
		list4._version = version6;
		string[] items6 = list4._items;
		if (list4._size >= items6.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"cat5_i0");
		}
		else
		{
			int size6 = list4._size + 1;
			list4._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < 7)
		{
			bool flag5 = weapon2.LevelUp();
		}
		goto IL_07a2;
		IL_02df:
		obj9 = 0;
		goto IL_083c;
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

	public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_007b: Expected I4, but got O
		bool result = base.ApplyLimitBreak(weightedLimitBreak);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.ApplyLimitBreak(weightedLimitBreak);
		}
		return result;
	}

	public float GetRandom()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> rANDOMS = _RANDOMS;
		int randomIndex = _randomIndex + 1;
		_randomIndex = randomIndex;
		int randomIndex2 = _randomIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)randomIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public float GetPlusMinus()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> pLUSMINUS = _PLUSMINUS;
		int plusMinusIndex = _plusMinusIndex + 1;
		_plusMinusIndex = plusMinusIndex;
		int plusMinusIndex2 = _plusMinusIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)plusMinusIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	protected override void OnStart()
	{
		//IL_00f4: Expected I, but got O
		base.ResetFiringTimer();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyNoKB;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		Collider collider2 = collider.setName("Grangatti>Enemies");
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.GrangattiWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider3 = physics2.add.overlap(_projectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			Collider collider4 = collider3.setName("Grangatti>Destructibles");
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				PhysicsManager physicsManager2 = core3._physicsManager;
				ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsPickup;
				Collider collider5 = physics3.add.overlap(_projectilePool, physicsManager2._pickupGroup, collideCallback3, processCallback, callbackContext);
				Collider collider6 = collider5.setName("Grangatti>Pickups");
				return;
			}
		}
		throw new NullReferenceException();
	}

	public bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00d5: Expected I, but got O
		//IL_00dd: Expected I, but got O
		//IL_00ed: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0129: Expected O, but got I
		//IL_0166: Expected O, but got I
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0268: Invalid comparison between F4 and I
		//IL_0360: Expected O, but got I4
		//IL_03a9: Expected I, but got O
		//IL_02e5: Invalid comparison between I and F4
		IDamageable damageable;
		if (right == null)
		{
			damageable = null;
			goto IL_00c7;
		}
		nint num = (nint)typeof(Pickup);
		nint num2 = (nint)right;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v23 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v23 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v66+FFFFFFF8+v57 @ rax_v62*8]");
			if (0 == (nint)typeof(Pickup))
			{
				obj3 = 1;
				goto IL_0438;
			}
		}
		obj3 = 0;
		goto IL_0438;
		IL_0349:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 2f;
		float time;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 200f, 2, time);
		nint num4 = (nint)damageable;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v794 @ rax_v44 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+368] (should have been resolved before IL gen)");
		goto IL_0479;
		IL_0479:
		return false;
		IL_00c7:
		nint num5 = (nint)typeof(Projectile);
		nint num6 = (nint)left;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v22+FFFFFFF8+v148 @ rax_v21*8]");
			if (0 == (nint)typeof(Projectile))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v22+FFFFFFF8+v273 @ rcx_v20*8]");
				object obj7 = 0 - typeof(Projectile);
				bool flag = obj7 == null;
				bool flag2 = !flag;
				Projectile projectile = null;
				if (!flag2)
				{
					projectile = (Projectile)left;
				}
				if (!projectile.HasAlreadyHitObject(damageable))
				{
					ItemType[] gold = _gold;
					if (_gold == null)
					{
						ArgumentNullException ex = new ArgumentNullException("array");
						ex._002Ector("array");
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
					object obj8 = default(object);
					if ((nint)obj8 <= -1)
					{
						ItemType[] edible = _edible;
						if (_edible == null)
						{
							goto IL_04ae;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
						object obj9 = default(object);
						if ((nint)obj9 > -1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v1 (VampireSurvivors.Interfaces.IDamageable)+FC]");
							float num9 = default(float);
							bool flag3;
							if (!(2f < 0f))
							{
								List<float> pLUSMINUS = _PLUSMINUS;
								int plusMinusIndex = _plusMinusIndex + 1;
								_plusMinusIndex = plusMinusIndex;
								int plusMinusIndex2 = _plusMinusIndex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+18]");
								int num8 = (int)((nint)plusMinusIndex2 % (nint)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+18]");
								if ((nint)num8 >= (nint)0)
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									goto IL_04ae;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+10]");
								flag3 = false;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ r8_v17 (System.Boolean)+20+v182 @ rdx_v23 (System.Int32)*4]");
								bool flag4 = 0f < 0.25f;
								bool flag5 = !flag4;
								time = num9;
								if (flag5)
								{
									goto IL_0349;
								}
							}
							bool flag6 = TurnToGold((ArcadeSprite)damageable, certain: true);
							bool flag7 = !flag6;
							flag3 = true;
							time = num9;
							if (!flag7)
							{
								goto IL_0349;
							}
						}
					}
					else
					{
						_ = 1065353216;
						((Pickup)damageable).GoToPlayer = true;
					}
				}
				goto IL_0479;
			}
		}
		throw new NullReferenceException();
		IL_04ae:
		ArgumentNullException ex2 = new ArgumentNullException("array");
		ex2._002Ector("array");
		throw ex2;
		IL_0438:
		bool flag8 = obj3 == null;
		damageable = null;
		if (!flag8)
		{
			damageable = (IDamageable)right;
		}
		goto IL_00c7;
	}

	public bool OnBulletOverlapsEnemyNoKB(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_029b: Expected I4, but got O
		//IL_00ac: Expected O, but got I4
		//IL_00df: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_00f7: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_021b: Expected I, but got O
		IDamageable damageable;
		ArcadeColliderType arcadeColliderType;
		if (first == null)
		{
			damageable = null;
			arcadeColliderType = null;
			goto IL_02bb;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v25+FFFFFFF8+v56 @ rax_v21*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_02d8;
			}
		}
		obj3 = 0;
		goto IL_02d8;
		IL_02d8:
		bool flag = obj3 == null;
		damageable = null;
		arcadeColliderType = null;
		if (!flag)
		{
			damageable = (IDamageable)first;
			arcadeColliderType = null;
		}
		goto IL_02bb;
		IL_02bb:
		if (second != null)
		{
			nint num4 = (nint)typeof(Projectile);
			nint num5 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v3 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v6+FFFFFFF8+v143 @ rax_v5*8]");
				if (0 == (nint)typeof(Projectile))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v6+FFFFFFF8+v219 @ rdx_v4*8]");
					object obj7 = 0 - typeof(Projectile);
					if (obj7 == null)
					{
						arcadeColliderType = second;
					}
					if (!((Projectile)arcadeColliderType).HasAlreadyHitObject(damageable))
					{
						float num7 = base.PPower();
						WeaponData currentWeaponData = _currentWeaponData;
						if (_currentWeaponData != null)
						{
							HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
						}
						else
						{
							HitVfxType hitVfxType = HitVfxType.Default;
						}
						float knockback = base.Knockback;
						if (damageable == null)
						{
							goto IL_028d;
						}
						nint num8 = (nint)damageable;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v357 @ rdx_v10 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
						float num9 = base.PPower();
						float num10 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
						base._003CStatsInflictedDamage_003Ek__BackingField = num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
						if ((nint)0 != 0)
						{
							bool flag2 = TurnToGold((ArcadeSprite)damageable);
						}
					}
					return false;
				}
			}
		}
		goto IL_028d;
		IL_028d:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool TurnToGold(ArcadeSprite target, bool certain = false)
	{
		//IL_0159: Expected I, but got O
		//IL_0187: Expected O, but got I
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected I4, but got Unknown
		List<float> rANDOMS = _RANDOMS;
		int randomIndex = _randomIndex + 1;
		_randomIndex = randomIndex;
		int randomIndex2 = _randomIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)randomIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			bool flag = (nint)((Equipment)this)._003COwner_003Ek__BackingField < 0;
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,xmm7\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm6\"");
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			if (!flag5)
			{
				int fail = _fail + 1;
				_fail = fail;
			}
			else
			{
				_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass22_0();
				CS_0024_003C_003E8__locals2.value = 1f;
				float2 position = target.position;
				Action<Pickup> callback = delegate(Pickup c)
				{
					if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
					{
						c.Time = 1f;
						c.GoToPlayer = true;
						c._003CValue_003Ek__BackingField = CS_0024_003C_003E8__locals2.value;
						c._003CFeverMS_003Ek__BackingField = 50f;
					}
				};
				Vector2 pos = default(Vector2);
				GM.Core.MakeCoin(pos, 1f, callback);
				_003C_003Ec__DisplayClass22_0 obj = (_003C_003Ec__DisplayClass22_0)(object)((Equipment)this)._003COwner_003Ek__BackingField;
				nint num3 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v485 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GrangattiWeapon+<>c__DisplayClass22_0>)+4F8] (should have been resolved before IL gen)");
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GrangattiWeapon+<>c__DisplayClass22_0>)+500]");
				obj._003CTurnToGold_003Eb__0((Pickup)0);
				PlayerOptionsData config = characterController._playerOptions.Config;
				object obj2 = default(object);
				int num4 = config._003CRunHunger_003Ek__BackingField + obj2;
				config._003CRunHunger_003Ek__BackingField = num4;
				int success = _success + 1;
				_success = success;
			}
			return flag5;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	protected unsafe override void MakeLevelOne()
	{
		//IL_017a: Expected F8, but got I4
		//IL_01b8: Expected I4, but got O
		//IL_0120: Expected I4, but got O
		//IL_02f4: Expected I4, but got O
		//IL_031b: Invalid comparison between F4 and I
		//IL_035c: Expected I, but got O
		//IL_0228: Expected O, but got I
		//IL_0494: Expected O, but got I4
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_0533: Expected I, but got O
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_04a6: Expected O, but got I4
		//IL_02c5: Expected F8, but got I4
		//IL_02cd: Expected F8, but got I4
		//IL_04c6: Expected O, but got I4
		((Equipment)this)._003CLevel_003Ek__BackingField = 0;
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		base._003CCanCrit_003Ek__BackingField = false;
		JToken newLevelData;
		if (!base.GetDataForLevel(((Equipment)this)._equipmentType, ((Equipment)this)._003CLevel_003Ek__BackingField, out *(JObject*)(&newLevelData), upgradeExistingData: false))
		{
			return;
		}
		object currentWeaponData = newLevelData.ToObject<object>();
		_currentWeaponData = (WeaponData)currentWeaponData;
		if (_currentWeaponData == null)
		{
			return;
		}
		WeaponData currentWeaponData2 = _currentWeaponData;
		((Equipment)this)._003CLevel_003Ek__BackingField = currentWeaponData2._003Clevel_003Ek__BackingField;
		if ((object)currentWeaponData2._003CpoolLimit_003Ek__BackingField != null)
		{
			BulletPool projectilePool = _projectilePool;
			if ((object)currentWeaponData2._003CpoolLimit_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new NullReferenceException();
			}
			int upperLimit = (object?)currentWeaponData2._003CpoolLimit_003Ek__BackingField >> 32;
			projectilePool.UpperLimit = upperLimit;
		}
		_chanceBonus = 0.0;
		goldChance = 0.005;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.GATTI);
		WeaponData currentWeaponData3 = _currentWeaponData;
		bool flag = currentWeaponData3._003CevolvesFrom_003Ek__BackingField == null;
		double num = 0.0;
		Weapon weapon = weaponByType;
		bool flag2 = false;
		bool flag3 = false;
		WeaponType weaponType = WeaponType.GATTI;
		double num3;
		if (!flag)
		{
			flag2 = (byte)(int)currentWeaponData3._003CevolvesFrom_003Ek__BackingField != 0;
			weapon = weaponByType;
			object obj = default(object);
			WeaponType weaponType2 = default(WeaponType);
			object obj3 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ stack_-60_v14+1C]");
					if ((nint)weaponType2 != (nint)0)
					{
						break;
					}
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ stack_-60_v14+18]");
					if ((nint)obj2 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ stack_-60_v14+10]");
					object obj4 = 0;
					obj3++;
					GameManager core = GM.Core;
					WeaponsFacade weaponsFacade = core._weaponsFacade;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v32+20+v1260 @ rcx_v49*4]");
					Weapon weapon2 = weaponsFacade.RemoveWeapon(WeaponType.VOID, ((Equipment)this)._003COwner_003Ek__BackingField);
					weapon = weapon2;
					flag2 = true;
					continue;
				}
				throw new NullReferenceException();
			}
			weaponType = weaponType2;
			bool flag4 = obj == null;
			nint num2 = 0;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ stack_-60_v14+1C]");
				if ((nint)weaponType2 == (nint)0)
				{
					num3 = 0.0;
					num = (flag2 ? 1 : 0);
					flag3 = false;
					goto IL_059c;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num2 = unchecked((nint)null);
			}
			throw new NullReferenceException();
		}
		goto IL_059c;
		IL_0613:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10490h]\"");
		_chanceBonus = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rdi+190h]\"");
		goldChance = num;
		num3 = 1.0;
		WeaponType weaponType3;
		weaponType = weaponType3;
		goto IL_0604;
		IL_059c:
		if ((object)weapon != null)
		{
			WeaponData currentWeaponData4 = weapon._currentWeaponData;
			weaponType3 = (WeaponType)_currentWeaponData;
			num = currentWeaponData4._003Cpower_003Ek__BackingField;
			float num4 = currentWeaponData4._003Cpower_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v37 (VampireSurvivors.Data.WeaponType)+B0]");
			if (num4 > 0f)
			{
				_ = currentWeaponData4._003Cpower_003Ek__BackingField;
				WeaponData currentWeaponData5 = weapon._currentWeaponData;
				nint num5 = (nint)typeof(Math);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,qword ptr [188A10828h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rcx_v39 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 <= (nint)0)
				{
					object obj5 = 1.0 & 0x7FFFFFFFFFFFFFFFL;
					bool flag5 = (long)obj5 <= 9218868437227405312L;
					num = currentWeaponData5._003Cpower_003Ek__BackingField;
					if (flag5)
					{
						goto IL_0613;
					}
				}
				num = 1.0;
				goto IL_0613;
			}
		}
		goto IL_0604;
		IL_0604:
		WeaponData currentWeaponData6 = _currentWeaponData;
		string text = currentWeaponData6._003Cbgm_003Ek__BackingField;
		if (currentWeaponData6._003Cbgm_003Ek__BackingField != null && text._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.StopMusic(bgmType);
			WeaponData currentWeaponData7 = _currentWeaponData;
			BgmType bgmType2 = Enum.Parse<BgmType>(currentWeaponData7._003Cbgm_003Ek__BackingField);
			BgmType bgmType3 = Enum.Parse<BgmType>((string)bgmType2);
			BgmType bgmType4 = Enum.Parse<BgmType>((string)bgmType2);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Loop = true;
			soundConfig.Rate = 1f;
			SoundManager.PlayMusic(bgmType4, soundConfig);
		}
		CheckArcanas();
		float num6 = base.PInterval();
		_lastFiringInterval = (float)num;
	}

	static GrangattiWeapon()
	{
		ItemType[] ignore = new ItemType[1];
		_ = 40;
		_ignore = ignore;
	}
}
