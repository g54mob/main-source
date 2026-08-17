using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Guns3Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Guns2CounterWeapon w2;

		internal void _003CCheckArcanas_003Eb__0()
		{
			w2.ResetFiringTimer();
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public float x;

		public float y;

		public float angle;

		public int j;

		public Guns3Weapon _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public float delay;

		public _003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			_003C_003Ec__DisplayClass15_0 obj = CS_0024_003C_003E8__locals1;
			Guns3Weapon guns3Weapon = obj._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)guns3Weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)guns3Weapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				_003C_003Ec__DisplayClass15_0 obj2 = CS_0024_003C_003E8__locals1;
				Guns3Weapon guns3Weapon2 = obj2._003C_003E4__this;
				float2 position = ((Equipment)guns3Weapon2)._003COwner_003Ek__BackingField.position;
				_003C_003Ec__DisplayClass15_0 obj3 = CS_0024_003C_003E8__locals1;
				object obj4 = default(object);
				float y = (float)obj4 + obj3.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,qword ptr [188A10798h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm1\"");
				float x = (float)position + obj3.x;
				double angle = default(double);
				BulletPool pool = default(BulletPool);
				Projectile projectile = obj3._003C_003E4__this.FireOneBullet(x, y, obj3.j, angle, pool);
			}
		}
	}

	private float _rayAngle;

	private float _angleUnit;

	private MultiTargetTween _scaleTween;

	private List<PhaserSprite> _rays;

	private float _pxUnit;

	private MultiTargetTween _permaTween;

	protected WeaponType _counterWeaponType1 = WeaponType.GUNS_COUNTER;

	protected WeaponType _counterWeaponType2 = WeaponType.GUNS2_COUNTER;

	protected Weapon _counterWeapon1;

	protected Weapon _counterWeapon2;

	public override float PAmount()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_01a7: Expected F8, but got I
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0168: Invalid comparison between F8 and I4
		//IL_0155: Expected F8, but got I
		//IL_0192: Expected F8, but got I4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		float num3;
		if (!(num2 > 10f))
		{
			object obj = 10f & -2147483649L;
			bool flag = (nint)obj <= 2139095040;
			num3 = num2;
			if (flag)
			{
				goto IL_01ac;
			}
		}
		num3 = 10f;
		goto IL_01ac;
		IL_01bb:
		WeaponData currentWeaponData;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		double num5;
		return num4 + (float)num5;
		IL_01ac:
		currentWeaponData = _currentWeaponData;
		EggDouble eggDouble = ((Equipment)this)._003COwner_003Ek__BackingField.PRevivals();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
		object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj2 != 9218868437227405312L)
		{
			object obj3 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj3 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018751DF58h\"");
				if ((long)obj3 == 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11858]");
					num5 = 0.0;
				}
				else
				{
					bool flag2 = eggDouble._eggVal < 10.0;
					num5 = eggDouble._eggVal;
					if (!flag2)
					{
						num5 = 10.0;
					}
				}
				goto IL_01bb;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11328]");
		num5 = 0.0;
		goto IL_01bb;
	}

	public override float PPower()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
		float num2 = default(float);
		float num3;
		if (!(num2 > 10f))
		{
			object obj = 10f & -2147483649L;
			bool flag = (nint)obj <= 2139095040;
			num3 = num2;
			if (flag)
			{
				goto IL_01bf;
			}
		}
		num3 = 10f;
		goto IL_01bf;
		IL_01ce:
		double num4;
		float num5;
		if (!(num4 > 10.0))
		{
			object obj2 = 10f & -2147483649L;
			bool flag2 = (nint)obj2 <= 2139095040;
			num5 = (float)num4;
			if (flag2)
			{
				goto IL_01eb;
			}
		}
		num5 = 10f;
		goto IL_01eb;
		IL_01eb:
		float num6 = num5 * 0.1f;
		WeaponData currentWeaponData;
		float num7 = num6 + currentWeaponData._003Cpower_003Ek__BackingField;
		return num7 * num3;
		IL_01bf:
		currentWeaponData = _currentWeaponData;
		EggDouble eggDouble = ((Equipment)this)._003COwner_003Ek__BackingField.PRevivals();
		num4 = eggDouble._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
		object obj3 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj3 != 9218868437227405312L)
		{
			object obj4 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj4 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018751E0C9h\"");
				if ((long)obj4 == 9218868437227405312L)
				{
					num4 = -1.7976931348623157E+308;
				}
				goto IL_01ce;
			}
		}
		num4 = 1.7976931348623157E+308;
		goto IL_01ce;
	}

	public override float PSpeed()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		float num6;
		float num4 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
				float num3 = num4 - 1f;
				float num5 = num3 * 1.5f;
				num6 = num5 + num4;
				if (!(num6 > 5f))
				{
					object obj = 5f & -2147483649L;
					if ((nint)obj <= 2139095040)
					{
						goto IL_018c;
					}
				}
				num6 = 5f;
				goto IL_018c;
			}
		}
		goto IL_0162;
		IL_0162:
		throw new NullReferenceException();
		IL_018c:
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		num4 = 5f;
		if (!flag)
		{
			float num7 = num6 * currentWeaponData._003Cspeed_003Ek__BackingField;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num4 = 5f;
			if (!flag2)
			{
				if (characterController._sineSpeed != null)
				{
					float value = characterController._sineSpeed.Value;
					num7 *= value;
				}
				return num7;
			}
		}
		goto IL_0162;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0084: Expected I, but got O
		//IL_00f3: Expected F8, but got I4
		base.InitWeapon(characterController, weaponType);
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		_angleUnit = -0.0005454154f;
		List<PhaserSprite> rays = new List<PhaserSprite>();
		_rays = rays;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,qword ptr [188A10978h]\"");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		nint num = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,qword ptr [188A10978h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
		double num2;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm6\"");
			num2 = 0.0;
		}
		else
		{
			num2 = Math.Sqrt(renderer.height);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A106E0h]\"");
		_permaTween = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,qword ptr [188A10870h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10508h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		_pxUnit = (float)num2;
	}

	public unsafe override void CheckArcanas()
	{
		//IL_012d: Expected I, but got O
		//IL_013b: Expected I, but got O
		//IL_014b: Expected O, but got I
		//IL_01cb: Expected O, but got I4
		//IL_0553: Expected O, but got I
		//IL_0187: Expected O, but got I
		//IL_052e: Expected O, but got I4
		//IL_01d8: Expected I4, but got O
		//IL_01e0: Expected O, but got I
		//IL_01bd: Expected O, but got I4
		//IL_0307: Expected I, but got O
		//IL_0315: Expected I, but got O
		//IL_0325: Expected O, but got I
		//IL_03a5: Expected O, but got I4
		//IL_0361: Expected O, but got I
		//IL_0590: Expected O, but got I4
		//IL_03b2: Expected I4, but got O
		//IL_0397: Expected O, but got I4
		//IL_044e: Expected I, but got O
		//IL_0464: Expected O, but got I
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04e8: Expected I, but got O
		//IL_05d6: Expected O, but got I4
		//IL_0602: Expected I, but got I8
		//IL_04c4: Expected I, but got I8
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			goto IL_04fb;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType1, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0229;
		}
		GameManager core2 = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType1, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, flag);
		bool flag2;
		if ((object)weapon == null)
		{
			flag2 = false;
			goto IL_0524;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(GunsCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsCounterWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsCounterWeapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v87+FFFFFFF8+v600 @ rax_v83*8]");
			if (0 == (nint)typeof(GunsCounterWeapon))
			{
				obj4 = 1;
				goto IL_0533;
			}
		}
		obj4 = 0;
		goto IL_0533;
		IL_0533:
		bool flag3 = obj4 == null;
		flag2 = false;
		characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)num;
		if (!flag3)
		{
			flag2 = (byte)(int)weapon != 0;
			characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)num;
		}
		goto IL_0524;
		IL_0524:
		_counterWeapon1 = (Weapon)flag2;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v8 (System.Boolean)+4C]");
			if ((nint)0 >= (nint)8)
			{
				break;
			}
			bool value = ((bool*)(flag2 ? 1 : 0))->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v810 @ rax_v77 (System.Boolean)+3C8] (should have been resolved before IL gen)");
		}
		goto IL_0229;
		IL_04fb:
		CheckBeginningArcana();
		return;
		IL_0583:
		_003C_003Ec__DisplayClass14_0 obj5;
		bool flag4;
		obj5.w2 = (Guns2CounterWeapon)flag4;
		_counterWeapon2 = obj5.w2;
		Guns2CounterWeapon w;
		while (true)
		{
			w = obj5.w2;
			if (((Equipment)w)._003CLevel_003Ek__BackingField >= 8)
			{
				break;
			}
			bool flag5 = w.LevelUp();
		}
		WeaponData currentWeaponData = ((Weapon)w)._currentWeaponData;
		Action action = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass14_0._003CCheckArcanas_003Eb__0);
		((Delegate)action).m_target = obj5;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num5;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num5 = unchecked((nint)6447293664L);
				goto IL_05cd;
			}
		}
		num5 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_05cd;
		IL_05cd:
		object obj8 = 24;
		float num6 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * 0.5f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		float duration = num6 * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, action, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		goto IL_04fb;
		IL_0229:
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType2 = characterController3._weaponsManager.GetWeaponByType(_counterWeaponType2, searchHidden: true);
		if ((object)weaponByType2 != null && ((UnityEngine.Object)weaponByType2).m_CachedPtr != (IntPtr)0)
		{
			goto IL_04fb;
		}
		obj5 = new _003C_003Ec__DisplayClass14_0();
		GameManager core3 = GM.Core;
		Weapon weapon2 = core3._weaponsFacade.AddHiddenWeapon(_counterWeaponType2, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, flag);
		if ((object)weapon2 == null)
		{
			flag4 = false;
			goto IL_0583;
		}
		nint num7 = (nint)weapon2;
		nint num8 = (nint)typeof(Guns2CounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2CounterWeapon>)+130]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2CounterWeapon>)+130]");
		object obj11;
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v62+FFFFFFF8+v867 @ rax_v57*8]");
			if (0 == (nint)typeof(Guns2CounterWeapon))
			{
				obj11 = 1;
				goto IL_0595;
			}
		}
		obj11 = 0;
		goto IL_0595;
		IL_0595:
		bool flag6 = obj11 == null;
		flag4 = false;
		if (!flag6)
		{
			flag4 = (byte)(int)weapon2 != 0;
		}
		goto IL_0583;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0c27: Invalid comparison between F4 and I4
		//IL_01f4: Invalid comparison between I4 and F4
		//IL_024a: Invalid comparison between F4 and I4
		//IL_0026: Expected O, but got F4
		//IL_08cb: Expected O, but got I4
		//IL_076d: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_07e7: Expected O, but got I4
		//IL_09cd: Expected O, but got I4
		//IL_09db: Expected O, but got I4
		//IL_09e9: Expected O, but got I4
		//IL_01d4: Expected I4, but got O
		//IL_03d6: Expected O, but got F8
		//IL_06d6: Invalid comparison between F4 and I4
		//IL_0500: Expected O, but got I4
		//IL_0666: Expected I4, but got F4
		//IL_0d38->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_03c4->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_040f->IL0ba2: Incompatible stack heights: 1 vs 0
		//IL_043e->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_0464->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_04c1->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_06ed->IL0cbc: Incompatible stack heights: 1 vs 0
		//IL_06f2->IL06f2: Incompatible stack heights: 1 vs 0
		//IL_0580->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_04e8->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_05b6->IL0c09: Incompatible stack heights: 1 vs 0
		//IL_05e5->IL0c09: Incompatible stack heights: 1 vs 0
		float num = PSpeed();
		object obj = default(object);
		float num2 = (float)obj * -0.0002727077f;
		List<PhaserSprite> rays = _rays;
		_angleUnit = num2;
		if (_rays != null)
		{
			float num4 = default(float);
			float num11 = default(float);
			float num12 = default(float);
			float num16 = default(float);
			PhaserSprite phaserSprite5 = default(PhaserSprite);
			BulletPool bulletPool = default(BulletPool);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				float num3 = PAmount();
				if (num2 > (float)rays._size)
				{
					GameObject gameObject = base.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num4, "vfx", "RaggiBeam");
					if ((object)phaserSprite == null)
					{
						break;
					}
					PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
					if ((object)phaserSprite2 == null)
					{
						break;
					}
					PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
					if ((object)phaserSprite3 == null)
					{
						break;
					}
					PhaserSprite item = phaserSprite3.setAlpha(0.25f);
					List<object> rays2 = (List<object>)(object)_rays;
					if (_rays == null)
					{
						break;
					}
					int version = rays2._version + 1;
					rays2._version = version;
					object[] items = rays2._items;
					if (rays2._items == null)
					{
						break;
					}
					if (rays2._size >= items.Length)
					{
						((List<object>)(object)_rays).AddWithResize((object)item);
					}
					else
					{
						int size = rays2._size + 1;
						rays2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					rays = _rays;
					if (_rays == null)
					{
						break;
					}
					int num5 = (int)rays2._items;
					num2 = num4;
					continue;
				}
				float num6 = PAmount();
				if (0f < num2)
				{
					float num7 = PAmount();
					float num8 = 360f / num2;
					float num9 = num8 * (-(float)Math.PI / 180f);
					float num10 = PAmount();
					if (num2 > 0f)
					{
						bool flag = false;
						num11 = num12;
						while (true)
						{
							_003C_003Ec__DisplayClass15_0 obj2 = new _003C_003Ec__DisplayClass15_0();
							if (obj2 == null)
							{
								break;
							}
							obj2._003C_003E4__this = this;
							float num13 = (float)(flag ? 1 : 0) * num9;
							double num14 = Math.Cos(obj2.angle = num13 + _rayAngle);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
							float x = 0f * _pxUnit;
							obj2.x = x;
							double num15 = Math.Sin(obj2.angle);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
							float y = 0f * _pxUnit;
							obj2.y = y;
							ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
							if ((object)cachedTrans == null)
							{
								break;
							}
							bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
							double ret;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
							if (arcadeSprite.body != null)
							{
								BaseBody body = arcadeSprite.body;
								ArcadeTransform arcadeTransform = body._transform;
								if (body._transform == null)
								{
									break;
								}
								arcadeTransform.position = (float2)ret;
								y = num16;
								num15 = ret;
							}
							List<PhaserSprite> rays3 = _rays;
							if (_rays == null)
							{
								break;
							}
							if ((flag ? 1 : 0) < rays3._size)
							{
								PhaserSprite[] items2 = rays3._items;
								if (rays3._items == null || (object)items2[flag ? 1u : 0u] == null)
								{
									break;
								}
								PhaserSprite phaserSprite4 = items2[flag ? 1u : 0u].setVisible(visible: true);
								if (_permaTween == null)
								{
									if (_rays == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									if ((object)phaserSprite5 == null)
									{
										break;
									}
									PhaserSprite phaserSprite6 = phaserSprite5.setScale(0.1f, (float?)(object)1);
								}
								num2 = obj2.angle;
								Projectile projectile = FireOneBullet(obj2.x, obj2.y, 0, num11, bulletPool);
								obj2.j = 1;
								int num5 = 0;
								while (obj2.j <= 8)
								{
									_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass15_1();
									if (CS_0024_003C_003E8__locals8 == null)
									{
										goto end_IL_0cbc;
									}
									CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj2;
									WeaponData currentWeaponData = _currentWeaponData;
									if (_currentWeaponData == null)
									{
										goto end_IL_0cbc;
									}
									_003C_003Ec__DisplayClass15_0 obj3 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 == null)
									{
										goto end_IL_0cbc;
									}
									float num17 = (CS_0024_003C_003E8__locals8.delay = (float)obj3.j * currentWeaponData._003CrepeatInterval_003Ek__BackingField);
									Action onComplete = delegate
									{
										_003C_003Ec__DisplayClass15_0 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
										Guns3Weapon guns3Weapon = obj4._003C_003E4__this;
										VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)guns3Weapon)._003COwner_003Ek__BackingField;
										if ((object)((Equipment)guns3Weapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
										{
											_003C_003Ec__DisplayClass15_0 obj5 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
											Guns3Weapon guns3Weapon2 = obj5._003C_003E4__this;
											float2 position = ((Equipment)guns3Weapon2)._003COwner_003Ek__BackingField.position;
											_003C_003Ec__DisplayClass15_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
											object obj7 = default(object);
											float y2 = (float)obj7 + obj6.y;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,qword ptr [188A10798h]\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,xmm0\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm1\"");
											float x2 = (float)position + obj6.x;
											double angle = default(double);
											BulletPool pool = default(BulletPool);
											Projectile projectile2 = obj6._003C_003E4__this.FireOneBullet(x2, y2, obj6.j, angle, pool);
										}
									};
									float num18 = num17 * 0.001f;
									Timer lastShotTimer = Timers.Register(num18, onComplete, null, isLooped: false, (byte)(int)num11 != 0, (MonoBehaviour)(object)bulletPool, repeat, type, isOnlineTimer: false, canPause: false);
									_lastShotTimer = lastShotTimer;
									int j = obj2.j + 1;
									obj2.j = j;
									num5 = 0;
									num2 = num18;
								}
								flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
								float num19 = PAmount();
								bool flag3 = num2 > (float)(flag ? 1 : 0);
								num11 = num11;
								if (flag3)
								{
									continue;
								}
								goto IL_06f2;
							}
							goto IL_0ba2;
							continue;
							end_IL_0cbc:
							break;
						}
						break;
					}
					goto IL_06f2;
				}
				List<PhaserSprite> rays4 = _rays;
				bool flag4 = _rays == null;
				bool flag5 = false;
				bool flag6 = false;
				if (flag4)
				{
					break;
				}
				while ((flag6 ? 1 : 0) < rays4._size)
				{
					List<PhaserSprite> rays5 = _rays;
					if (_rays == null)
					{
						goto end_IL_0c10;
					}
					if ((flag5 ? 1 : 0) < rays5._size)
					{
						PhaserSprite[] items3 = rays5._items;
						if (rays5._items == null || (object)items3[flag5 ? 1u : 0u] == null)
						{
							goto end_IL_0c10;
						}
						PhaserSprite phaserSprite7 = items3[flag5 ? 1u : 0u].setVisible(visible: false);
						rays4 = _rays;
						flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
						bool flag7 = _rays != null;
						flag6 = flag5;
						if (!flag7)
						{
							goto end_IL_0c10;
						}
						continue;
					}
					goto IL_0ba2;
				}
				goto IL_0833;
				IL_0ba2:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
				IL_0833:
				float num20 = base.PInterval();
				bool flag8 = _lastFiringInterval == num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018751F56Ah\"");
				if (!flag8)
				{
					float num21 = base.PInterval();
					_lastFiringInterval = num2;
					base.ResetFiringTimer();
				}
				if (!skipTriggers)
				{
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						break;
					}
					((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
				}
				return;
				IL_06f2:
				float num22 = base.PInterval();
				WeaponData currentWeaponData2 = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					break;
				}
				float num23 = currentWeaponData2._003CrepeatInterval_003Ek__BackingField * 8f;
				if (!(num2 > num23))
				{
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 1f;
					soundConfig.Detune = -100f;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Guns3, soundConfig, 100f, 1, num11);
					if (_permaTween == null)
					{
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Volume = (float?)(object)1;
						soundConfig2.Rate = 1f;
						soundConfig2.Detune = -100f;
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Guns2, soundConfig2, 200f, 10, num11);
						PermaTween();
					}
				}
				else
				{
					SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
					soundConfig3.Volume = (float?)(object)1;
					soundConfig3.Rate = 1f;
					soundConfig3.Detune = -100f;
					PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Guns2, soundConfig3, 200f, 10, num11);
					if (_scaleTween != null)
					{
						_scaleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					if (_rays == null)
					{
						break;
					}
					PhaserSprite[] targets = _rays.ToArray();
					if (tweenConfig == null)
					{
						break;
					}
					tweenConfig.targets = targets;
					float num24 = base.PArea();
					tweenConfig.yoyo = true;
					tweenConfig.scaleX = (float?)(object)1;
					tweenConfig.scaleY = (float?)(object)1;
					tweenConfig.alpha = (float?)(object)1;
					WeaponData currentWeaponData3 = _currentWeaponData;
					if (_currentWeaponData == null)
					{
						break;
					}
					num2 = currentWeaponData3._003CrepeatInterval_003Ek__BackingField * 4f;
					tweenConfig.ease = Ease.InOutSine;
					tweenConfig.duration = num2;
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
					_scaleTween = scaleTween;
				}
				goto IL_0833;
				continue;
				end_IL_0c10:
				break;
			}
		}
		throw new NullReferenceException();
	}

	public Projectile FireOneBullet(float x, float y, int index, double angle, BulletPool pool = null)
	{
		//IL_0054: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_00f2: Expected O, but got I4
		//IL_021f: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_00e4: Expected O, but got I4
		//IL_02a9: Expected I, but got O
		//IL_01cc: Expected O, but got F4
		if (_projectilePool == null)
		{
			goto IL_01d6;
		}
		float2 float5 = default(float2);
		Projectile projectile = _projectilePool.SpawnAt(float5, this, index);
		bool flag = (object)projectile == null;
		Weapon weapon = this;
		float2 float6 = float5;
		Projectile projectile2 = null;
		nint num;
		object obj3;
		if (!flag)
		{
			num = (nint)projectile;
			nint num2 = (nint)typeof(Guns3Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Guns3Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Guns3Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v35+FFFFFFF8+v158 @ rax_v31*8]");
				if (0 == (nint)typeof(Guns3Projectile))
				{
					obj3 = 1;
					goto IL_0208;
				}
			}
			obj3 = 0;
			goto IL_0208;
		}
		goto IL_0245;
		IL_01d6:
		return (Projectile)(object)new NullReferenceException();
		IL_0208:
		bool flag2 = obj3 == null;
		weapon = (Weapon)num;
		float6 = (float2)typeof(Guns3Projectile);
		projectile2 = null;
		if (!flag2)
		{
			weapon = (Weapon)num;
			float6 = (float2)typeof(Guns3Projectile);
			projectile2 = projectile;
		}
		goto IL_0245;
		IL_0245:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			nint num4 = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v15 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num5 = 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				BaseBody body = projectile2.body;
				if (projectile2.body != null && (object)s_scene.physics != null)
				{
					float num6 = GameManager.ProjectileSpeed * 10f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					object obj4 = default(object);
					float num7 = (float)obj4 * num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num8 = (float)obj4 * num6;
					body._velocity = (float2)num7;
					goto IL_0262;
				}
			}
			goto IL_01d6;
		}
		goto IL_0262;
		IL_0262:
		return projectile2;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0540: Invalid comparison between I4 and F4
		//IL_039f: Expected O, but got I4
		//IL_03a8: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected O, but got Unknown
		//IL_02c0: Expected O, but got Ref
		//IL_032b: Expected I4, but got O
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_044d->IL04db: Incompatible stack heights: 1 vs 0
		//IL_0473->IL04db: Incompatible stack heights: 1 vs 0
		//IL_04d0->IL03b6: Incompatible stack heights: 1 vs 0
		//IL_04da->IL04db: Incompatible stack heights: 1 vs 0
		//IL_0622->IL04db: Incompatible stack heights: 1 vs 0
		//IL_018e->IL04db: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL04db: Incompatible stack heights: 2 vs 0
		//IL_021a->IL04db: Incompatible stack heights: 2 vs 0
		//IL_02ae->IL04db: Incompatible stack heights: 2 vs 0
		//IL_02d9->IL04db: Incompatible stack heights: 2 vs 0
		//IL_05d5->IL04db: Incompatible stack heights: 2 vs 0
		//IL_0301->IL04db: Incompatible stack heights: 2 vs 0
		//IL_0361->IL04db: Incompatible stack heights: 2 vs 0
		//IL_037b->IL05da: Incompatible stack heights: 2 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * _angleUnit;
		float num2 = num * 1000f;
		float num3 = (_rayAngle = num2 + _rayAngle);
		float num4 = PAmount();
		if (0f < num3)
		{
			float num5 = PAmount();
			List<PhaserSprite> rays = _rays;
			float num6 = 360f / num3;
			float num7 = num6 * (-(float)Math.PI / 180f);
			if (_rays != null)
			{
				object obj = 0;
				object obj2 = 0;
				object obj5 = default(object);
				object obj6 = default(object);
				object obj7 = default(object);
				while (true)
				{
					if ((nint)obj2 >= rays._size)
					{
						return;
					}
					float num8 = (float)obj * num7;
					float num9 = num8 + _rayAngle;
					double num10 = Math.Cos(num9);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm10,xmm0\"");
					object obj3 = 0 * _pxUnit;
					double num11 = Math.Sin(num9);
					ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm9,xmm0\"");
					object obj4 = 0 * _pxUnit;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (arcadeSprite.body != null)
					{
						BaseBody body = arcadeSprite.body;
						ArcadeTransform arcadeTransform = body._transform;
						if (body._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
					}
					List<PhaserSprite> rays2 = _rays;
					if (_rays == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= rays2._size;
					PhaserSprite[] items = rays2._items;
					if (rays2._items == null || (object)items[obj] == null)
					{
						break;
					}
					PhaserSprite phaserSprite = items[obj].setVisible(visible: true);
					float y = (float)obj5 + (float)obj4;
					float x = (float)ret + (float)obj3;
					PhaserSprite phaserSprite2 = items[obj].setPosition(x, y);
					Transform transform = items[obj].transform;
					if ((object)transform == null)
					{
						break;
					}
					transform.localEulerAngles = (Vector3)(&obj6);
					if ((object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene._renderer == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
					PhaserSprite phaserSprite3 = items[obj].setDepth((int)s_scene._renderer);
					rays = _rays;
					obj++;
					if (_rays == null)
					{
						break;
					}
					obj6 = obj7;
					obj2 = obj;
				}
			}
		}
		else
		{
			List<PhaserSprite> rays3 = _rays;
			bool flag3 = _rays == null;
			object obj8 = 0;
			object obj9 = 0;
			if (!flag3)
			{
				bool flag5;
				do
				{
					if ((nint)obj9 < rays3._size)
					{
						List<PhaserSprite> rays4 = _rays;
						if (_rays == null)
						{
							break;
						}
						bool flag4 = (nint)obj8 >= rays4._size;
						PhaserSprite[] items2 = rays4._items;
						if (rays4._items == null || (object)items2[obj8] == null)
						{
							break;
						}
						PhaserSprite phaserSprite4 = items2[obj8].setVisible(visible: false);
						rays3 = _rays;
						obj8++;
						flag5 = _rays != null;
						obj9 = obj8;
						continue;
					}
					return;
				}
				while (flag5);
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		base.Cleanup();
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_permaTween != null)
		{
			_permaTween.Kill();
		}
		_permaTween = null;
		List<PhaserSprite> rays = _rays;
		MultiTargetTween multiTargetTween = null;
		MultiTargetTween multiTargetTween2 = null;
		while (true)
		{
			if ((nint)multiTargetTween2 < rays._size)
			{
				List<PhaserSprite> rays2 = _rays;
				if ((nint)multiTargetTween >= rays2._size)
				{
					break;
				}
				PhaserSprite[] items = rays2._items;
				PhaserSprite phaserSprite = items[(object)multiTargetTween].setVisible(visible: false);
				rays = _rays;
				multiTargetTween = (MultiTargetTween)(multiTargetTween + 1);
				multiTargetTween2 = multiTargetTween;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override bool LevelUp()
	{
		//IL_00db: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon1;
		if ((object)_counterWeapon1 != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon1 == null)
			{
				goto IL_00cd;
			}
			bool flag = _counterWeapon1.LevelUp();
		}
		Weapon counterWeapon2 = _counterWeapon2;
		if ((object)_counterWeapon2 != null && ((UnityEngine.Object)counterWeapon2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon2 == null)
			{
				goto IL_00cd;
			}
			bool flag2 = _counterWeapon2.LevelUp();
		}
		return result;
		IL_00cd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_00e3: Expected I4, but got O
		bool result = base.ApplyLimitBreak(weightedLimitBreak);
		Weapon counterWeapon = _counterWeapon1;
		if ((object)_counterWeapon1 != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon1 == null)
			{
				goto IL_00d5;
			}
			bool flag = _counterWeapon1.ApplyLimitBreak(weightedLimitBreak);
		}
		Weapon counterWeapon2 = _counterWeapon2;
		if ((object)_counterWeapon2 != null && ((UnityEngine.Object)counterWeapon2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon2 == null)
			{
				goto IL_00d5;
			}
			bool flag2 = _counterWeapon2.ApplyLimitBreak(weightedLimitBreak);
		}
		return result;
		IL_00d5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void SetVisible(bool visible)
	{
		//IL_00ac: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		List<PhaserSprite> rays = _rays;
		_isVisible = visible;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < rays._size)
			{
				List<PhaserSprite> rays2 = _rays;
				if ((nint)obj >= rays2._size)
				{
					break;
				}
				PhaserSprite[] items = rays2._items;
				PhaserSprite phaserSprite = items[obj].setVisible(visible);
				rays = _rays;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void PermaTween()
	{
		//IL_0082: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		List<PhaserSprite> rays = _rays;
		if (rays._size == 0)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _rays.ToArray();
		tweenConfig.targets = targets;
		float num = base.PArea();
		tweenConfig.yoyo = true;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		WeaponData currentWeaponData = _currentWeaponData;
		float duration = currentWeaponData._003CrepeatInterval_003Ek__BackingField * 4f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.duration = duration;
		TweenCallback onStart = delegate
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected O, but got I4
			//IL_00fb: Expected O, but got I4
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			List<PhaserSprite> rays2 = _rays;
			object obj = 0;
			object obj2 = 0;
			float num3 = default(float);
			while (true)
			{
				if ((nint)obj2 >= rays2._size)
				{
					return;
				}
				List<PhaserSprite> rays3 = _rays;
				if ((nint)obj >= rays3._size)
				{
					break;
				}
				PhaserSprite[] items = rays3._items;
				PhaserSprite phaserSprite = items[obj].setAlpha(1f);
				List<PhaserSprite> rays4 = _rays;
				if ((nint)obj >= rays4._size)
				{
					break;
				}
				PhaserSprite[] items2 = rays4._items;
				float num2 = base.PArea();
				num3 *= 0.5f;
				PhaserSprite phaserSprite2 = items2[obj].setScale(num3, (float?)(object)1);
				rays2 = _rays;
				obj++;
				obj2 = obj;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PermaTween();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween permaTween = Tweens.Add(tweenConfig);
		_permaTween = permaTween;
	}

	private void _003CPermaTween_003Eb__22_0()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		List<PhaserSprite> rays = _rays;
		object obj = 0;
		object obj2 = 0;
		float num2 = default(float);
		while (true)
		{
			if ((nint)obj2 < rays._size)
			{
				List<PhaserSprite> rays2 = _rays;
				if ((nint)obj >= rays2._size)
				{
					break;
				}
				PhaserSprite[] items = rays2._items;
				PhaserSprite phaserSprite = items[obj].setAlpha(1f);
				List<PhaserSprite> rays3 = _rays;
				if ((nint)obj >= rays3._size)
				{
					break;
				}
				PhaserSprite[] items2 = rays3._items;
				float num = base.PArea();
				num2 *= 0.5f;
				PhaserSprite phaserSprite2 = items2[obj].setScale(num2, (float?)(object)1);
				rays = _rays;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CPermaTween_003Eb__22_1()
	{
		PermaTween();
	}
}
