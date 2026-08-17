using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_FakeGrant_Solo_Character : TP_Character
{
	private bool _canRetaliate;

	private float RetaliationDelay;

	private float OverhealDelay;

	private float OverhealTriggerValue;

	private bool _canOverheal;

	private Timer _overHealTimer;

	private List<WeaponType> knives;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj;
		_canOverheal = true;
	}

	private void FireAllKnives()
	{
		//IL_0044: Expected O, but got I4
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list2 = knives;
				if (knives != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj3 = default(object);
					object obj2 = obj3 >> 31;
					return (byte)(obj2 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
	}

	public override bool GetDamaged(float damageAmount)
	{
		//IL_00ab: Invalid comparison between F4 and I
		//IL_0066: Expected F4, but got I
		if (_canRetaliate)
		{
			_canRetaliate = false;
			FireAllKnives();
			float num = base.PSpeed();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			float num4 = RetaliationDelay / num3;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
			if (num5 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
				num4 = 0f;
			}
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = num4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		return base.GetDamaged(damageAmount);
	}

	private void OverhealTrigger(float value, float rawValue)
	{
		float num = rawValue - value;
		if (!(num < OverhealTriggerValue) && _canOverheal)
		{
			_canOverheal = false;
			if (_overHealTimer != null)
			{
				_overHealTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canOverheal = true;
			};
			float duration = OverhealDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer overHealTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_overHealTimer = overHealTimer;
			FireAllKnives();
		}
	}

	public TP_FakeGrant_Solo_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_03ab: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_03d3: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_03fb: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0423: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_02fe: Expected O, but got I
		_canRetaliate = true;
		RetaliationDelay = 4000f;
		OverhealDelay = 1000f;
		OverhealTriggerValue = 8f;
		_canOverheal = true;
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1423);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1423;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1424);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1424;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1615);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1615;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1616);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1616;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1606);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1606;
		}
		knives = list;
		((CharacterController)this)._002Ector();
	}

	private bool _003CFireAllKnives_003Eb__8_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = knives;
			if (knives != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void _003CGetDamaged_003Eb__9_0()
	{
		_canRetaliate = true;
	}

	private void _003COverhealTrigger_003Eb__10_0()
	{
		_canOverheal = true;
	}
}
