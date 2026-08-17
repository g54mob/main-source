using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class TP_Julia_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass4_0
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

	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 6;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T06_SARABANDE);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
	}

	public override void LevelUp()
	{
		//IL_021e: Expected I4, but got I8
		//IL_0013: Expected O, but got I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		//IL_013f: Expected O, but got I4
		base.LevelUp();
		int num = (int)(((CharacterController)this)._level & 0x80000001L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5E55]");
		if ((nint)0 < (nint)0)
		{
			object obj = num - 1;
			object obj2 = obj | -2;
			num = obj2 + 1;
		}
		if (num != 1)
		{
			if (_sequentialTimer != null)
			{
				_sequentialTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_sequentialSpawn = 0;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer sequentialTimer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_sequentialTimer = sequentialTimer;
			float2 float5 = base.position;
			float num2 = (float)_sequentialSpawn * ((float)Math.PI / 6f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num3 = num2 * 1.65f;
			float2 float6 = base.position;
			float x = (float)float5 + num3;
			float num4 = (float)_sequentialSpawn * ((float)Math.PI / 6f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			object obj3 = _sequentialSpawn * 200;
			float num5 = num4 * 1.65f;
			object obj4 = default(object);
			float y = num5 + (float)obj4;
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals6.x = x;
			CS_0024_003C_003E8__locals6.y = y;
			CS_0024_003C_003E8__locals6.itemType = ItemType.TP_HEART_REFRESH;
			Action onComplete2 = delegate
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
			float duration = (float)obj3 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			int sequentialSpawn = _sequentialSpawn + 1;
			_sequentialSpawn = sequentialSpawn;
		}
	}

	private void SpawnSingle(float x, float y, ItemType itemType, float delay)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass4_0();
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

	private void _003CLevelUp_003Eb__3_0()
	{
		_sequentialSpawn = 0;
	}
}
