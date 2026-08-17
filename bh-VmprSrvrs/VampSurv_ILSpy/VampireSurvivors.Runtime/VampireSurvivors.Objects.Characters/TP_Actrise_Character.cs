using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class TP_Actrise_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__7_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 11;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public TP_Actrise_Character _003C_003E4__this;

		public Equipment statue;

		internal unsafe void _003CLevelUp_003Eb__1()
		{
			Equipment equipment = statue;
			if (equipment._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = equipment.LevelUp();
				Action onComplete = delegate
				{
					//IL_002d: Expected O, but got Ref
					GameManager core = GM.Core;
					object obj = default(object);
					CharacterController character = default(CharacterController);
					float displayTimeMultiplier = default(float);
					Vector2 vOffset = default(Vector2);
					core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.DIAMOND, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisUI(60f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
			}
		}
	}

	private TP_Earth2_Weapon _003CStartingWeapon_003Ek__BackingField;

	private float _baseWeaponPower;

	private List<WeaponType> adeptSpells;

	public TP_Earth2_Weapon StartingWeapon
	{
		get
		{
			return _003CStartingWeapon_003Ek__BackingField;
		}
		set
		{
			_003CStartingWeapon_003Ek__BackingField = value;
		}
	}

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(type);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				WeaponData currentWeaponData = weaponByType._currentWeaponData;
				weaponByType.IsAdept = true;
				float num = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
				currentWeaponData._003Cinterval_003Ek__BackingField = num;
			}
		}
	}

	public unsafe override void LevelUp()
	{
		//IL_0033: Expected O, but got I4
		//IL_012f: Expected I, but got O
		//IL_0137: Expected I, but got O
		//IL_0147: Expected O, but got I
		//IL_01c7: Expected O, but got I4
		//IL_0183: Expected O, but got I
		//IL_01d9: Expected I4, but got O
		//IL_01b9: Expected O, but got I4
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		base.LevelUp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj = 0 * 4;
		bool flag;
		bool canPause;
		object obj4;
		if (((CharacterController)this)._level == (nint)obj)
		{
			CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
			Predicate<Equipment> match = _003C_003Ec._003C_003E9__7_0;
			if (_003C_003Ec._003C_003E9__7_0 == null)
			{
				match = (_003C_003Ec._003C_003E9__7_0 = delegate(Equipment x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj6 = x._equipmentType - 11;
					return obj6 == null;
				});
			}
			Equipment statue = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.Find(match);
			CS_0024_003C_003E8__locals9.statue = statue;
			Equipment statue2 = CS_0024_003C_003E8__locals9.statue;
			if ((object)CS_0024_003C_003E8__locals9.statue != null && ((UnityEngine.Object)statue2).m_CachedPtr != (IntPtr)0)
			{
				Equipment statue3 = CS_0024_003C_003E8__locals9.statue;
				if ((object)CS_0024_003C_003E8__locals9.statue == null)
				{
					flag = false;
					canPause = false;
					goto IL_0474;
				}
				nint num = (nint)typeof(Weapon);
				nint num2 = (nint)statue3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rax_v64+FFFFFFF8+v875 @ rax_v60*8]");
					if (0 == (nint)typeof(Weapon))
					{
						obj4 = 1;
						goto IL_0440;
					}
				}
				obj4 = 0;
				goto IL_0440;
			}
		}
		goto IL_029a;
		IL_0474:
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rbx_v8 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				_ = 1;
			}
		}
		Equipment statue4 = CS_0024_003C_003E8__locals9.statue;
		if (statue4._003CLevel_003Ek__BackingField < 8)
		{
			Action onComplete = delegate
			{
				Equipment statue5 = CS_0024_003C_003E8__locals9.statue;
				if (statue5._003CLevel_003Ek__BackingField < 8)
				{
					bool flag3 = statue5.LevelUp();
					Action onComplete2 = delegate
					{
						//IL_002d: Expected O, but got Ref
						GameManager core = GM.Core;
						object obj6 = default(object);
						CharacterController character = default(CharacterController);
						float displayTimeMultiplier = default(float);
						Vector2 vOffset = default(Vector2);
						core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.DIAMOND, "1", (Color?)(object)(&obj6), character, displayTimeMultiplier, vOffset);
					};
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					Timer timer2 = TimerHelper.RegisterMillisUI(60f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2);
				}
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		}
		goto IL_029a;
		IL_0440:
		bool flag2 = obj4 == null;
		flag = false;
		canPause = false;
		if (!flag2)
		{
			flag = (byte)(int)CS_0024_003C_003E8__locals9.statue != 0;
			canPause = false;
		}
		goto IL_0474;
		IL_029a:
		TP_Earth2_Weapon tP_Earth2_Weapon = _003CStartingWeapon_003Ek__BackingField;
		if ((object)_003CStartingWeapon_003Ek__BackingField == null || ((UnityEngine.Object)tP_Earth2_Weapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		TP_Earth2_Weapon tP_Earth2_Weapon2 = _003CStartingWeapon_003Ek__BackingField;
		float num4 = (float)((CharacterController)this)._level * 0.1f;
		float num5 = num4 + _baseWeaponPower;
		LimitBreakData accumulatedLimitBreaks = tP_Earth2_Weapon2.accumulatedLimitBreaks;
		if ((object)accumulatedLimitBreaks._003Cpower_003Ek__BackingField != null)
		{
			TP_Earth2_Weapon tP_Earth2_Weapon3 = _003CStartingWeapon_003Ek__BackingField;
			LimitBreakData accumulatedLimitBreaks2 = tP_Earth2_Weapon3.accumulatedLimitBreaks;
			if ((object)accumulatedLimitBreaks2._003Cpower_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			object obj5 = default(object);
			num5 += (float)obj5;
		}
		TP_Earth2_Weapon tP_Earth2_Weapon4 = _003CStartingWeapon_003Ek__BackingField;
		WeaponData currentWeaponData = ((Weapon)tP_Earth2_Weapon4)._currentWeaponData;
		currentWeaponData._003Cpower_003Ek__BackingField = num5;
	}

	public override void AfterFullInitialization()
	{
		//IL_004b: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_0069: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_00a5: Expected O, but got I
		//IL_00db: Expected O, but got I4
		base.AfterFullInitialization();
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_EARTH2);
		bool flag = (object)weaponByType == null;
		Weapon weapon = weaponByType;
		if (flag)
		{
			goto IL_017b;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(TP_Earth2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v30+FFFFFFF8+v114 @ rax_v25*8]");
			if (0 == (nint)typeof(TP_Earth2_Weapon))
			{
				obj3 = 1;
				goto IL_018a;
			}
		}
		obj3 = 0;
		goto IL_018a;
		IL_017b:
		_003CStartingWeapon_003Ek__BackingField = (TP_Earth2_Weapon)weapon;
		TP_Earth2_Weapon tP_Earth2_Weapon = _003CStartingWeapon_003Ek__BackingField;
		if ((object)_003CStartingWeapon_003Ek__BackingField != null && ((UnityEngine.Object)tP_Earth2_Weapon).m_CachedPtr != (IntPtr)0)
		{
			TP_Earth2_Weapon tP_Earth2_Weapon2 = _003CStartingWeapon_003Ek__BackingField;
			WeaponData currentWeaponData = ((Weapon)tP_Earth2_Weapon2)._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = _baseWeaponPower;
		}
		return;
		IL_018a:
		bool flag2 = obj3 == null;
		weapon = null;
		if (!flag2)
		{
			weapon = weaponByType;
		}
		goto IL_017b;
	}

	public unsafe void ShowIcons()
	{
		Action onComplete = delegate
		{
			//IL_002d: Expected O, but got Ref
			GameManager core = GM.Core;
			object obj = default(object);
			CharacterController character = default(CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.DIAMOND, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(60f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
	}

	public TP_Actrise_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0219: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0241: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0269: Expected O, but got I
		//IL_01c0: Expected O, but got I
		_baseWeaponPower = 1f;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1462);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1462;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)163);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 163;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)164);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 164;
		}
		adeptSpells = list;
		((CharacterController)this)._002Ector();
	}

	private unsafe void _003CShowIcons_003Eb__9_0()
	{
		//IL_002d: Expected O, but got Ref
		GameManager core = GM.Core;
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.DIAMOND, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}
}
