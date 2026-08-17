using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Keremet_Character : TP_Character
{
	private float OverhealDelay = 100f;

	private float OverhealTriggerValue2 = 8f;

	private bool _canOverheal;

	private Timer _overHealTimer;

	private Weapon keremetWeapon;

	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_011d: Expected I4, but got O
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 17;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T17_PAINTING);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
		Action<float, float> action = null;
		((List<ArcanaType>)(object)action).Add((ArcanaType)this);
		Delegate obj3 = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, action);
		if ((object)obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj3 == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj3;
		_canOverheal = true;
		base.SetBloodColor(2788134u);
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_ACID2);
		keremetWeapon = weaponByType;
	}

	private unsafe void FireMorbus(float value, float rawValue)
	{
		//IL_0338: Expected O, but got I4
		//IL_00c9: Expected I, but got O
		//IL_00f2: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_022b: Expected I, but got O
		//IL_0241: Expected O, but got I
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_02bd: Expected I, but got O
		//IL_0133: Expected I, but got O
		//IL_0149: Expected O, but got I
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_04ce: Expected I, but got I8
		//IL_0290: Expected I, but got I8
		//IL_01d7: Expected I, but got O
		//IL_020b: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		//IL_03a3: Expected I, but got I8
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_03fe: Expected O, but got I4
		//IL_01c0: Expected I, but got I8
		float num = rawValue - value;
		if (num < OverhealTriggerValue2 || !_canOverheal)
		{
			return;
		}
		Weapon weapon = keremetWeapon;
		if ((object)keremetWeapon == null || ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0)
		{
			Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_ACID2);
			keremetWeapon = weaponByType;
			WeaponType weaponType = WeaponType.TP_ACID2;
		}
		Weapon weapon2 = keremetWeapon;
		if ((object)keremetWeapon != null)
		{
			nint num2 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v52 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+4C0]");
			WeaponType weaponType = WeaponType.VOID;
			keremetWeapon.Fire();
		}
		float num3 = num / OverhealTriggerValue2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		object obj = 24;
		object obj2 = default(object);
		if ((nint)obj2 > 10)
		{
			obj2 = 10;
		}
		else if ((nint)obj2 <= 1)
		{
			goto IL_0358;
		}
		object obj3 = 100;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		object obj6;
		do
		{
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(TP_Keremet_Character._003CFireMorbus_003Eb__6_1);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			bool flag = obj5 == null;
			nint num5;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r10_v5 (Il2CppMethodInfo)+52]");
				flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_038c;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_038c;
			IL_038c:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)obj3 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			obj3 += 100;
			obj6 = !flag;
		}
		while (obj6 != null);
		goto IL_0358;
		IL_04a5:
		float duration2 = OverhealDelay * 0.001f;
		Action action2;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer overHealTimer = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_overHealTimer = overHealTimer;
		return;
		IL_0358:
		Timer overHealTimer2 = _overHealTimer;
		_canOverheal = false;
		if (_overHealTimer != null && !_overHealTimer.IsDone)
		{
			float timeElapsed = _overHealTimer.GetTimeElapsed();
			overHealTimer2._timeElapsedBeforeCancel = (float?)(object)1;
			overHealTimer2._timeElapsedBeforePause = (float?)(object)0;
		}
		action2 = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(TP_Keremet_Character._003CFireMorbus_003Eb__6_0);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num7;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+52]");
			bool flag2 = (nint)0 == 0;
			num7 = unchecked((nint)6447293664L);
			if (flag2)
			{
				goto IL_04a5;
			}
		}
		num7 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_04a5;
	}

	private void _003CFireMorbus_003Eb__6_1()
	{
		//IL_0078: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null && (object)keremetWeapon != null)
		{
			keremetWeapon.Fire();
		}
	}

	private void _003CFireMorbus_003Eb__6_0()
	{
		_canOverheal = true;
	}
}
