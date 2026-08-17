using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class TP_Celia_Character : TP_Character
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
		base.AfterFullInitialization();
	}

	public override void LevelUp()
	{
		//IL_0205: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		base.LevelUp();
		int num = ((CharacterController)this)._level & 1;
		bool flag = num == 0;
		object obj = !flag;
		if (obj == null)
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
			object obj2 = _sequentialSpawn * 200;
			float num5 = num4 * 1.65f;
			object obj3 = default(object);
			float y = num5 + (float)obj3;
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals6.x = x;
			CS_0024_003C_003E8__locals6.y = y;
			CS_0024_003C_003E8__locals6.itemType = ItemType.TP_KARMA_COIN;
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
			float duration = (float)obj2 * 0.001f;
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
