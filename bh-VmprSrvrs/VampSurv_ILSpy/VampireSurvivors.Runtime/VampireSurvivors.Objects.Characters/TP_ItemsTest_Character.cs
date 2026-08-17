using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class TP_ItemsTest_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public float x;

		public float y;

		public ItemType itemType;

		internal void _003CSpawnSingle_003Eb__0()
		{
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(x, y);
		}
	}

	private Timer _sequentialTimer;

	private int _sequentialSpawn;

	private List<ItemType> _pickupTypes;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
	}

	public override void LevelUp()
	{
		//IL_001a: Expected I4, but got I8
		//IL_0044: Expected O, but got I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected I4, but got Unknown
		base.LevelUp();
		int num = (int)(((CharacterController)this)._level & 0x80000001L);
		object obj = default(object);
		object obj2 = default(object);
		if (obj != obj2)
		{
			object obj3 = num - 1;
			object obj4 = obj3 | -2;
			num = obj4 + 1;
		}
		if (num != 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x187635370\"");
		}
	}

	private void SpawnPickups(int extra = 0)
	{
		//IL_0100: Expected O, but got F4
		//IL_0123: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		GameManager core = GM.Core;
		if (!core._003CCanInterrupt_003Ek__BackingField)
		{
			return;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 360f;
		float2 float5 = base.position;
		object obj3 = 200;
		ArcadeSprite arcadeSprite = this;
		object obj4 = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool flag;
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebp\"");
			float num2 = 0f * ((float)Math.PI / 6f);
			float num3 = num2 + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebp\"");
			float num4 = num3 * 2.15f;
			float num5 = 0f * ((float)Math.PI / 6f);
			float x = num4 + (float)float5;
			float num6 = num5 + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num7 = num6 * 2.15f;
			float y = num7 + (float)obj4;
			ItemType itemType = Extensions.PickRnd(_pickupTypes);
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals6.x = x;
			CS_0024_003C_003E8__locals6.y = y;
			CS_0024_003C_003E8__locals6.itemType = itemType;
			Action action = delegate
			{
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool shouldCallValidatePickups = default(bool);
				bool isRemote = default(bool);
				Pickup pickup = GM.Core.MakePickup(pos, CS_0024_003C_003E8__locals6.itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
				GameManager core2 = GM.Core;
				core2._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals6.x, CS_0024_003C_003E8__locals6.y);
			};
			float duration = (float)obj3 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			obj3 += 200;
			flag = (nint)obj3 < 2600;
			arcadeSprite = (ArcadeSprite)(object)action;
		}
		while (flag);
	}

	private void SpawnSingle(float x, float y, ItemType itemType, float delay)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals6.x = x;
		CS_0024_003C_003E8__locals6.y = y;
		CS_0024_003C_003E8__locals6.itemType = itemType;
		Action onComplete = delegate
		{
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, CS_0024_003C_003E8__locals6.itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals6.x, CS_0024_003C_003E8__locals6.y);
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public TP_ItemsTest_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0278: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02a0: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_022a: Expected O, but got I
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)205);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 205;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)206);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 206;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)207);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 207;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)209);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 209;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)208);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 208;
		}
		_pickupTypes = list;
		((CharacterController)this)._002Ector();
	}
}
