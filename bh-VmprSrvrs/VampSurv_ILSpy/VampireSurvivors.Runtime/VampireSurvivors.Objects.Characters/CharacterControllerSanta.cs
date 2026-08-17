using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSanta : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__7_0;

		public static Predicate<Equipment> _003C_003E9__7_1;

		public static Predicate<Equipment> _003C_003E9__7_2;

		public static Predicate<Equipment> _003C_003E9__7_3;

		public static Predicate<Equipment> _003C_003E9__7_4;

		public static Predicate<Equipment> _003C_003E9__7_5;

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
				object obj = x._equipmentType - 16;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__7_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 14;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__7_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 9;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__7_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 17;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__7_4(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 10;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__7_5(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 15;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WeaponType type;

		internal bool _003CAddHiddenWeaponAndRemoveEvolution_003Eb__0(WeaponType t)
		{
			//IL_000f: Expected O, but got I4
			object obj = t - type;
			return obj == null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public SpriteRenderer spr;

		public int index;

		public TweenCallback _003C_003E9__2;

		internal void _003CShowRings_003Eb__0()
		{
			spr.enabled = true;
		}

		internal void _003CShowRings_003Eb__1()
		{
			//IL_002c: Expected I, but got O
			//IL_0096: Expected I, but got O
			//IL_00fa: Expected O, but got I4
			//IL_0108: Expected O, but got I4
			//IL_0116: Expected O, but got I4
			//IL_0124: Expected O, but got I4
			//IL_0132: Expected O, but got I4
			//IL_014e: Expected O, but got I4
			//IL_015e: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			if ((object)spr != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Transform transform = spr.transform;
			if ((object)transform != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 500f;
			tweenConfig.localAngle = (float?)(object)1;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.scaleY = (float?)(object)1;
			tweenConfig.localX = (float?)(object)1;
			tweenConfig.localY = (float?)(object)1;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.alpha = (float?)(object)1;
			object obj3 = index + 10;
			float delay = (float)obj3 * 100f;
			tweenConfig.delay = delay;
			TweenCallback onComplete = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onComplete = (_003C_003E9__2 = delegate
				{
					SpriteRenderer spriteRenderer = spr;
					if ((object)spr != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
					{
						spr.enabled = false;
						UnityEngine.Object.Destroy(spr, 0f);
					}
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CShowRings_003Eb__2()
		{
			SpriteRenderer spriteRenderer = spr;
			if ((object)spr != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				spr.enabled = false;
				UnityEngine.Object.Destroy(spr, 0f);
			}
		}
	}

	private List<string> _WeaponIcons;

	private bool _AddedHiddenWeapons;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		base._onCriticalHP = onCriticalHP;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list._version + 1;
		list._version = version12;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num12 = list._size + 1;
			list._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list._version + 1;
		list._version = version13;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num13 = list._size + 1;
			list._size = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version14 = list._version + 1;
		list._version = version14;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num14 = list._size + 1;
			list._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version15 = list._version + 1;
		list._version = version15;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num15 = list._size + 1;
			list._size = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version16 = list._version + 1;
		list._version = version16;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num16 = list._size + 1;
			list._size = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version17 = list._version + 1;
		list._version = version17;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num17 = list._size + 1;
			list._size = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version18 = list._version + 1;
		list._version = version18;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num18 = list._size + 1;
			list._size = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version19 = list._version + 1;
		list._version = version19;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num19 = list._size + 1;
			list._size = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version20 = list._version + 1;
		list._version = version20;
		string[] items20 = list._items;
		if (list._size >= items20.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num20 = list._size + 1;
			list._size = num20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version21 = list._version + 1;
		list._version = version21;
		string[] items21 = list._items;
		if (list._size >= items21.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num21 = list._size + 1;
			list._size = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version22 = list._version + 1;
		list._version = version22;
		string[] items22 = list._items;
		if (list._size >= items22.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyWater");
		}
		else
		{
			int num22 = list._size + 1;
			list._size = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version23 = list._version + 1;
		list._version = version23;
		string[] items23 = list._items;
		if (list._size >= items23.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HolyBook");
		}
		else
		{
			int num23 = list._size + 1;
			list._size = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version24 = list._version + 1;
		list._version = version24;
		string[] items24 = list._items;
		if (list._size >= items24.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Cross");
		}
		else
		{
			int num24 = list._size + 1;
			list._size = num24;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_WeaponIcons = list;
	}

	public override void GetTreasureModifier()
	{
		//IL_023c: Expected O, but got I4
		//IL_0245: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_01f8: Expected O, but got I
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			TreasureFactory treasureFactory = core._treasureFactory;
			List<PrizeType> currentTreasureTypes = treasureFactory.currentTreasureTypes;
			object obj3 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			if ((nint)obj3 >= 0 || (nint)obj2 >= 2)
			{
				return;
			}
			GameManager core2 = GM.Core;
			TreasureFactory treasureFactory2 = core2._treasureFactory;
			List<PrizeType> currentTreasureTypes2 = treasureFactory2.currentTreasureTypes;
			object obj4 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			if ((nint)obj4 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+20+v64 @ rax_v3*4]");
			if ((nint)0 != 6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+20+v64 @ rax_v3*4]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+20+v64 @ rax_v3*4]");
					if ((nint)0 != 2)
					{
						goto IL_0250;
					}
				}
				GameManager core3 = GM.Core;
				TreasureFactory treasureFactory3 = core3._treasureFactory;
				List<PrizeType> currentTreasureTypes3 = treasureFactory3.currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r8_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj6 = 0;
				_ = 6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r8_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
				_ = (nint)0 + (nint)1;
			}
			else
			{
				GameManager core4 = GM.Core;
				TreasureFactory treasureFactory4 = core4._treasureFactory;
				List<PrizeType> currentTreasureTypes4 = treasureFactory4.currentTreasureTypes;
				object obj7 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj8 = 0;
				_ = 7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
				_ = (nint)0 + (nint)1;
			}
			goto IL_0250;
			IL_0250:
			obj2++;
			core = GM.Core;
			obj = obj2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void CriticalHP()
	{
		//IL_00f7: Expected I8, but got O
		//IL_006f: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		SantaJavelin2Weapon seraphicCry;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			Action<long> action = null;
			((CharacterControllerSanta)(object)action).TriggerOnCriticalHp((long)this);
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
		else if (!HasSeraphicCry(out seraphicCry))
		{
			bool setDark = default(bool);
			GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
		}
		else
		{
			((SantaJavelin2Weapon)null).StartWeirdSoulsPurifier();
		}
	}

	private void OnCriticalHp()
	{
		if (!HasSeraphicCry(out var seraphicCry))
		{
			bool setDark = default(bool);
			GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
		}
		else
		{
			seraphicCry.StartWeirdSoulsPurifier();
		}
	}

	public void TriggerOnCriticalHp(long startingSimFrame)
	{
		Action onSyncedTimer = OnCriticalHp;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public unsafe override void LevelUp()
	{
		//IL_0129: Expected I, but got O
		//IL_0137: Expected I, but got O
		//IL_0147: Expected O, but got I
		//IL_01c7: Expected O, but got I4
		//IL_0183: Expected O, but got I
		//IL_01b9: Expected O, but got I4
		//IL_022b: Expected F4, but got O
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected Ref, but got Unknown
		//IL_040d: Expected O, but got I4
		//IL_046a: Expected O, but got I4
		//IL_04c2: Expected O, but got I4
		//IL_051a: Expected O, but got I4
		base.LevelUp();
		float y;
		object obj = default(object);
		GameManager core;
		WeaponType weaponType;
		float2 float7;
		if (base._level != 40)
		{
			if (base._level != 80)
			{
				goto IL_0230;
			}
			float2 float5 = base.position;
			float2 float6 = base.position;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.height * 0.45f;
			y = (float)obj - num;
			core = GM.Core;
			weaponType = WeaponType.CANDYBOX;
			float7 = float5;
		}
		else
		{
			float2 float8 = base.position;
			float2 float9 = base.position;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float num2 = renderer2.height * 0.45f;
			y = (float)obj - num2;
			core = GM.Core;
			weaponType = WeaponType.ARMADIO;
			float7 = float8;
		}
		Vector2 pos = default(Vector2);
		float num3 = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = core.MakeStagePickup(pos, ItemType.WEAPON, weaponType, num3, relicType, validatePickups);
		Pickup pickup2;
		if ((object)pickup == null)
		{
			pickup2 = null;
			goto IL_07ec;
		}
		nint num4 = (nint)pickup;
		nint num5 = (nint)typeof(PickupWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj4;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1172 @ rax_v24+FFFFFFF8+v1043 @ rax_v20*8]");
			if (0 == (nint)typeof(PickupWeapon))
			{
				obj4 = 1;
				goto IL_07c5;
			}
		}
		obj4 = 0;
		goto IL_07c5;
		IL_07ec:
		if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
		{
			_ = 1;
		}
		GameManager core2 = GM.Core;
		core2._gizmoManager.ShowHighlightAt((float)float7, y);
		goto IL_0230;
		IL_07c5:
		bool flag = obj4 == null;
		pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		goto IL_07ec;
		IL_0230:
		if (_AddedHiddenWeapons)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
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
				object obj5 = x._equipmentType - 16;
				return obj5 == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		CharacterWeaponsManager weaponsManager2 = base._weaponsManager;
		Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__7_1;
		if (_003C_003Ec._003C_003E9__7_1 == null)
		{
			match2 = (_003C_003Ec._003C_003E9__7_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 14;
				return obj5 == null;
			});
		}
		Equipment equipment2 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField.Find(match2);
		CharacterWeaponsManager weaponsManager3 = base._weaponsManager;
		Predicate<Equipment> match3 = _003C_003Ec._003C_003E9__7_2;
		if (_003C_003Ec._003C_003E9__7_2 == null)
		{
			match3 = (_003C_003Ec._003C_003E9__7_2 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 9;
				return obj5 == null;
			});
		}
		Equipment equipment3 = ((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField.Find(match3);
		if ((object)equipment == null || ((UnityEngine.Object)equipment).m_CachedPtr == (IntPtr)0 || !equipment2 || !equipment3 || equipment._003CLevel_003Ek__BackingField < 8 || equipment2._003CLevel_003Ek__BackingField < 8 || equipment3._003CLevel_003Ek__BackingField < 8)
		{
			return;
		}
		ref List<string> frames = ref *(List<string>*)(this + 1040);
		_AddedHiddenWeapons = true;
		ShowRings(ref frames);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 400f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 4, num3);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = 1400f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Morph, soundConfig2, 2000f, 4, num3);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = 2400f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Morph, soundConfig3, 2000f, 4, num3);
		SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
		soundConfig4.Volume = (float?)(object)1;
		soundConfig4.Rate = 1f;
		soundConfig4.Detune = 3400f;
		PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Morph, soundConfig4, 2000f, 4, num3);
		CharacterWeaponsManager weaponsManager4 = base._weaponsManager;
		Predicate<Equipment> match4 = _003C_003Ec._003C_003E9__7_3;
		bool flag2 = _003C_003Ec._003C_003E9__7_3 != null;
		int num7 = 4;
		if (!flag2)
		{
			match4 = (_003C_003Ec._003C_003E9__7_3 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 17;
				return obj5 == null;
			});
			num7 = 0;
		}
		Equipment equipment4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Find(match4);
		if (!equipment4)
		{
			base._weaponsManager.RemoveEquipment(equipment);
			equipment.Cleanup();
			Weapon weapon = AddHiddenWeaponAndRemoveEvolution(WeaponType.HEAVENSWORD);
		}
		CharacterWeaponsManager weaponsManager5 = base._weaponsManager;
		Predicate<Equipment> match5 = _003C_003Ec._003C_003E9__7_4;
		if (_003C_003Ec._003C_003E9__7_4 == null)
		{
			match5 = (_003C_003Ec._003C_003E9__7_4 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 10;
				return obj5 == null;
			});
			num7 = 0;
		}
		Equipment equipment5 = ((EquipmentManager)weaponsManager5)._003CHiddenEquipment_003Ek__BackingField.Find(match5);
		if (!equipment5)
		{
			base._weaponsManager.RemoveEquipment(equipment3);
			equipment3.Cleanup();
			Weapon weapon2 = AddHiddenWeaponAndRemoveEvolution(WeaponType.BORA);
		}
		CharacterWeaponsManager weaponsManager6 = base._weaponsManager;
		Predicate<Equipment> match6 = _003C_003Ec._003C_003E9__7_5;
		if (_003C_003Ec._003C_003E9__7_5 == null)
		{
			match6 = (_003C_003Ec._003C_003E9__7_5 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 15;
				return obj5 == null;
			});
			num7 = 0;
		}
		Equipment equipment6 = ((EquipmentManager)weaponsManager6)._003CHiddenEquipment_003Ek__BackingField.Find(match6);
		if (!equipment6)
		{
			base._weaponsManager.RemoveEquipment(equipment2);
			equipment2.Cleanup();
			Weapon weapon3 = AddHiddenWeaponAndRemoveEvolution(WeaponType.VESPERS);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800035C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800035C0");
			_ = 1;
		}
		GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(this);
		if (panelForCharacter != null)
		{
			panelForCharacter.RebuildWeaponSlots();
			panelForCharacter.RebuildAccessorySlots();
		}
	}

	private Weapon AddHiddenWeaponAndRemoveEvolution(WeaponType type)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass8_0();
		if (CS_0024_003C_003E8__locals4 != null)
		{
			CS_0024_003C_003E8__locals4.type = type;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._weaponsFacade != null)
			{
				bool allowDuplicates = default(bool);
				Weapon result = core._weaponsFacade.AddHiddenWeapon(type, this, removeFromStore: true, allowDuplicates);
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._levelUpFactory != null && LevelUpFactory._specialWeapons != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1CF0");
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null && core3._levelUpFactory != null)
					{
						Func<WeaponType, bool> condition = delegate(WeaponType t)
						{
							//IL_000f: Expected O, but got I4
							object obj = t - CS_0024_003C_003E8__locals4.type;
							return obj == null;
						};
						Extensions.RemoveWhere((ICollection<System.Int32Enum>)LevelUpFactory._weaponStore, (Func<System.Int32Enum, bool>)(object)condition);
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null && core4._levelUpFactory != null)
						{
							core4._levelUpFactory.ForceExclude(CS_0024_003C_003E8__locals4.type);
							return result;
						}
					}
				}
			}
		}
		return (Weapon)(object)new NullReferenceException();
	}

	public unsafe void ShowRings(ref List<string> frames)
	{
		//IL_0228: Expected O, but got I
		//IL_0241: Expected I, but got O
		//IL_02b9: Expected I, but got O
		//IL_02cb: Expected O, but got I4
		//IL_02d6: Expected I, but got O
		//IL_030b: Expected O, but got I4
		//IL_0718: Expected I, but got O
		//IL_072e: Expected O, but got I
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Expected O, but got Unknown
		//IL_0398: Expected I, but got O
		//IL_0762: Expected O, but got I4
		//IL_0779: Expected I, but got I8
		//IL_0798: Expected I, but got O
		//IL_07ae: Expected O, but got I
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_0381: Expected I, but got I8
		//IL_0437: Expected I, but got O
		//IL_07f9: Expected I, but got I8
		//IL_0420: Expected I, but got I8
		//IL_051c->IL04a0: Incompatible stack heights: 1 vs 0
		//IL_0573->IL04a0: Incompatible stack heights: 2 vs 0
		//IL_00a1->IL04a0: Incompatible stack heights: 3 vs 0
		//IL_0103->IL04a0: Incompatible stack heights: 4 vs 0
		//IL_0606->IL04a0: Incompatible stack heights: 6 vs 0
		//IL_0660->IL04a0: Incompatible stack heights: 7 vs 0
		//IL_0196->IL04a0: Incompatible stack heights: 7 vs 0
		//IL_0201->IL04a0: Incompatible stack heights: 7 vs 0
		//IL_06e9->IL04a0: Incompatible stack heights: 8 vs 0
		//IL_0266->IL0266: Incompatible stack heights: 9 vs 8
		//IL_0706->IL04a0: Incompatible stack heights: 9 vs 0
		//IL_048b->IL04a0: Incompatible stack heights: 9 vs 0
		//IL_049f->IL080b: Incompatible stack heights: 9 vs 0
		List<string> list = frames;
		if (frames != null)
		{
			int num = 0;
			int num2 = 0;
			Vector2 vector = default(Vector2);
			string spriteName = default(string);
			while (true)
			{
				if (num2 >= list._size)
				{
					return;
				}
				_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
				if ((object)this == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				List<string> list2 = frames;
				if (frames == null)
				{
					break;
				}
				bool flag3 = num >= list2._size;
				string[] items = list2._items;
				if (list2._items == null)
				{
					break;
				}
				bool flag4 = num >= items.Length;
				GameObject gameObject = base.gameObject;
				SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "items", spriteName);
				if ((object)spriteRenderer == null)
				{
					break;
				}
				spriteRenderer.enabled = false;
				bool flag5 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 2000);
				bool flag6 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				CheckRenderer();
				Transform spriteRenderer2 = (Transform)(object)((ArcadeSprite)this)._spriteRenderer;
				if ((object)((ArcadeSprite)this)._spriteRenderer == null)
				{
					break;
				}
				bool flag7 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr);
				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				if ((object)transform2 == null)
				{
					break;
				}
				bool flag8 = (object)transform2.GetType() != typeof(RectTransform);
				object obj2 = null;
				if (!flag8)
				{
					obj2 = transform2;
				}
				if (obj2 != null)
				{
					Debug.LogWarning("Parent of RectTransform is being set with parent property. Consider using the SetParent method instead, with the worldPositionStays argument set to false. This will retain local orientation and scale rather than world orientation and scale, which can prevent common UI scaling issues.", transform2);
				}
				transform2.SetParent(parent, worldPositionStays: true);
				((UnityEngine.Object)spriteRenderer).SetName("RING");
				if (obj == null)
				{
					break;
				}
				obj.index = num;
				obj.spr = spriteRenderer;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				Transform spr = (Transform)(object)obj.spr;
				if ((object)obj.spr == null)
				{
					break;
				}
				bool flag9 = ((UnityEngine.Object)spr).m_CachedPtr == (IntPtr)0;
				IntPtr intPtr = Component.get_transform_Injected(((UnityEngine.Object)spr).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
				if (array == null)
				{
					break;
				}
				bool flag10 = (object)transform3 == null;
				Transform transform4 = (Transform)(nint)intPtr;
				if (!flag10)
				{
					Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
					bool flag11 = (object)transform5 == null;
					transform4 = transform3;
				}
				bool flag12 = (nint)((SpriteRenderer)(object)array).m_SpriteChangeEvent <= 0;
				array[0] = transform3;
				if (tweenConfig == null)
				{
					break;
				}
				tweenConfig.targets = array;
				Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform4);
				tweenConfig.localX = (float?)(object)1;
				Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform4);
				tweenConfig.duration = 500f;
				tweenConfig.ease = Ease.InOutSine;
				tweenConfig.localY = (float?)(object)1;
				TweenCallback tweenCallback = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ r10_v17 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass9_0._003CShowRings_003Eb__0);
				((Delegate)tweenCallback).m_target = obj;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ r10_v17 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num4;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ r10_v17 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num4 = unchecked((nint)6447293664L);
						goto IL_0759;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num4 = ((Delegate)tweenCallback).method_ptr;
				goto IL_0759;
				IL_07d9:
				nint num5 = 24;
				TweenCallback tweenCallback2;
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				tweenConfig.onComplete = tweenCallback2;
				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
				list = frames;
				num++;
				if (frames == null)
				{
					break;
				}
				num2 = num;
				continue;
				IL_0759:
				object obj5 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				tweenConfig.onStart = tweenCallback;
				tweenCallback2 = null;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v18 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass9_0._003CShowRings_003Eb__1);
				((Delegate)tweenCallback2).m_target = obj;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v18 (Il2CppMethodInfo)+4C]");
				object obj6 = (nint)0 >> 4;
				object obj7 = obj6 & 1;
				nint num7;
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v18 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num7 = unchecked((nint)6447293664L);
						goto IL_07d9;
					}
				}
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				num7 = ((Delegate)tweenCallback2).method_ptr;
				goto IL_07d9;
			}
		}
		throw new NullReferenceException();
	}
}
