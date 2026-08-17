using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class TP_John_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass5_0
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

	private bool _arcanaAdded;

	private Timer _sequentialTimer;

	private int _sequentialSpawn;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_arcanaAdded = false;
	}

	public override void LevelUp()
	{
		//IL_02f2: Expected O, but got I4
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_01e4: Expected O, but got I4
		base.LevelUp();
		bool flag = ((CharacterController)this)._level != 10;
		ArcanaType arcanaType = ArcanaType.T00_KILLER;
		if (!flag)
		{
			bool flag2 = _arcanaAdded;
			arcanaType = ArcanaType.T00_KILLER;
			if (!flag2)
			{
				_arcanaAdded = true;
				GameManager core = GM.Core;
				ArcanaManager arcanaManager = core._arcanaManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				object obj = default(object);
				bool flag3 = obj != null;
				arcanaType = ArcanaType.T07_IRON_BLUE;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
					arcanaManager.TriggerArcana(ArcanaType.T07_IRON_BLUE);
					arcanaType = ArcanaType.T07_IRON_BLUE;
				}
				int num = arcanaManager._003CMaxArcanasPerRun_003Ek__BackingField + 1;
				arcanaManager._003CMaxArcanasPerRun_003Ek__BackingField = num;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj2 = (int)arcanaType >> 1;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 4;
		object obj6 = obj4 + obj5;
		if (((CharacterController)this)._level == (nint)obj6)
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
			object obj7 = _sequentialSpawn * 200;
			float num5 = num4 * 1.65f;
			object obj8 = default(object);
			float y = num5 + (float)obj8;
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals6.x = x;
			CS_0024_003C_003E8__locals6.y = y;
			CS_0024_003C_003E8__locals6.itemType = ItemType.TP_MIRROR_OF_TRUTH;
			Action onComplete2 = delegate
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
			float duration = (float)obj7 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			int sequentialSpawn = _sequentialSpawn + 1;
			_sequentialSpawn = sequentialSpawn;
		}
	}

	private void SpawnSingle(float x, float y, ItemType itemType, float delay)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass5_0();
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

	private void _003CLevelUp_003Eb__4_0()
	{
		_sequentialSpawn = 0;
	}
}
