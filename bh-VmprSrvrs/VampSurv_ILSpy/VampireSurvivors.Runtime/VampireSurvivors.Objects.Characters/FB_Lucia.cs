using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class FB_Lucia : CharacterController_FirstBlood
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public FB_Lucia _003C_003E4__this;

		public List<Tuple<WeaponType, float>> attributeData;
	}

	private sealed class _003C_003Ec__DisplayClass0_1
	{
		public float delay;

		public int index;

		public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CDoPostRevivalActions_003Eb__0()
		{
			//IL_016e: Expected O, but got I4
			//IL_01b7: Expected F4, but got I
			//IL_0111: Expected F4, but got I
			//IL_0148: Expected O, but got F4
			//IL_0148: Expected O, but got Ref
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = delay;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, num);
			_003C_003Ec__DisplayClass0_0 obj = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass0_0 obj2 = CS_0024_003C_003E8__locals1;
			List<Tuple<WeaponType, float>> attributeData = obj2.attributeData;
			int num2 = index;
			if (index < attributeData._size)
			{
				Tuple<WeaponType, float>[] items = attributeData._items;
				Tuple<WeaponType, float> tuple = items[num2];
				_003C_003Ec__DisplayClass0_0 obj3 = CS_0024_003C_003E8__locals1;
				List<Tuple<WeaponType, float>> attributeData2 = obj3.attributeData;
				int num3 = index;
				Tuple<WeaponType, float>[] items2 = attributeData2._items;
				Tuple<WeaponType, float> tuple2 = items2[num3];
				FB_Lucia fB_Lucia = obj._003C_003E4__this;
				FB_Lucia character = obj._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v5 (System.Tuple`2<VampireSurvivors.Data.WeaponType, System.Single>)+10]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v15 (System.Tuple`2<VampireSurvivors.Data.WeaponType, System.Single>)+14]");
				fB_Lucia.AddValueToAttribute(character, (WeaponType)num4, 0f);
				GameManager core = GM.Core;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v15 (System.Tuple`2<VampireSurvivors.Data.WeaponType, System.Single>)+14]");
				string value = System.Number.FormatSingle(0f, null, currentInfo);
				GizmoManager gizmoManager = core._gizmoManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v5 (System.Tuple`2<VampireSurvivors.Data.WeaponType, System.Single>)+10]");
				object obj4 = default(object);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				gizmoManager.DisplayWeaponIconOverhead(WeaponType.VOID, value, (Color?)(object)(&obj4), (CharacterController)num, displayTimeMultiplier, vOffset);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	public unsafe override void DoPostRevivalActions(CharacterController revived, bool instantRevival)
	{
		//IL_04e7: Expected O, but got I4
		//IL_0501: Expected O, but got I4
		//IL_0562: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_040c: Expected I, but got O
		//IL_0422: Expected O, but got I
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0499: Expected I, but got O
		//IL_0579: Expected O, but got I4
		//IL_05a0: Expected I, but got I8
		//IL_0482: Expected I, but got I8
		_003C_003Ec__DisplayClass0_0 obj = new _003C_003Ec__DisplayClass0_0();
		obj._003C_003E4__this = this;
		bool flag = default(bool);
		if (!flag)
		{
			return;
		}
		bool flag2 = (object)this == null;
		bool flag3 = (object)revived == null;
		object obj2 = flag3 & flag2;
		bool flag4 = obj2 == null;
		object obj3 = !flag4;
		if (obj3 == null)
		{
			bool flag5;
			if ((object)this != null)
			{
				if ((object)revived != null)
				{
					object obj4 = (object)revived - (object)this;
					flag5 = obj4 == null;
				}
				else
				{
					flag5 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag5 = ((UnityEngine.Object)revived).m_CachedPtr == (IntPtr)0;
			}
			if (!flag5)
			{
				return;
			}
		}
		bool flag6 = revived._deficiencyControl == null;
		bool flag7 = true;
		if (!flag6)
		{
			CharacterADControl deficiencyControl = revived._deficiencyControl;
			object obj5 = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag8 = obj5 == null;
			flag7 = !flag8;
		}
		int num = revived._PlayerIndex >> 31;
		int num2 = (flag7 ? 1 : 0) & num;
		bool flag9 = num2 == 0;
		object obj6 = !flag9;
		if (obj6 != null)
		{
			return;
		}
		List<Tuple<WeaponType, float>> attributeData = new List<Tuple<WeaponType, float>>();
		Tuple<WeaponType, float> tuple = null;
		_ = 65;
		_ = 1036831949;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple2 = null;
		_ = 57;
		_ = 1045220557;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple3 = null;
		_ = 56;
		_ = 1101004800;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple4 = null;
		_ = 58;
		_ = 1034147594;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple5 = null;
		_ = 53;
		_ = 3170222735L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple6 = null;
		_ = 55;
		_ = 1045220557;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple7 = null;
		_ = 63;
		_ = 1045220557;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple8 = null;
		_ = 59;
		_ = 1056964608;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple9 = null;
		_ = 61;
		_ = 1028443341;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple10 = null;
		_ = 60;
		_ = 1028443341;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple11 = null;
		_ = 50;
		_ = 1025758986;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple12 = null;
		_ = 52;
		_ = 1025758986;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple13 = null;
		_ = 54;
		_ = 1025758986;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple14 = null;
		_ = 51;
		_ = 1025758986;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		Tuple<WeaponType, float> tuple15 = null;
		_ = 62;
		_ = 1008981770;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB20A0");
		obj.attributeData = attributeData;
		bool flag10 = false;
		bool flag11 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			List<Tuple<WeaponType, float>> attributeData2 = obj.attributeData;
			if ((flag10 ? 1 : 0) >= attributeData2._size)
			{
				break;
			}
			_003C_003Ec__DisplayClass0_1 obj7 = new _003C_003Ec__DisplayClass0_1();
			obj7.CS_0024_003C_003E8__locals1 = obj;
			obj7.index = (flag11 ? 1 : 0);
			float num3 = (obj7.delay = (float)(flag11 ? 1 : 0) * 400f);
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass0_1._003CDoPostRevivalActions_003Eb__0);
			((Delegate)action).m_target = obj7;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj8 = (nint)0 >> 4;
			object obj9 = obj8 & 1;
			nint num5;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0570;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_0570;
			IL_0570:
			object obj10 = 24;
			float duration = num3 * 0.001f;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag11 = (byte)((flag11 ? 1u : 0u) + 1u) != 0;
			flag10 = flag11;
		}
	}

	private unsafe void HandleEquipment(WeaponType weaponType, float value)
	{
		//IL_0047: Expected O, but got Ref
		AddValueToAttribute(this, weaponType, value);
		GameManager core = GM.Core;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string value2 = System.Number.FormatSingle(value, null, currentInfo);
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core._gizmoManager.DisplayWeaponIconOverhead(weaponType, value2, (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}
}
