using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityHoarder : PassiveAbility
{
	private float hoverFallSpeed = 12f;

	private float spawnIntervalStartSeconds = 60f;

	private float spawnIntervalEndSeconds = 120f;

	private float spawnIntervalIncreasePerDrop = 2.5f;

	private float spawnIntervalSeconds = 60f;

	private float currentTimer;

	private int accumulatedTicks;

	private int maxAccumulatedTicks = 1000;

	private float lastAccumulatedTime;

	public override void Cleanup()
	{
	}

	public override void Init()
	{
		currentTimer = spawnIntervalStartSeconds;
		spawnIntervalSeconds = spawnIntervalStartSeconds;
	}

	public override void Tick()
	{
		ChestTick();
		MovementTick();
		bool flag = MyPlayer.Instance == null;
	}

	private unsafe void MovementTick()
	{
		//IL_009d: Invalid comparison between F4 and I4
		//IL_0119: Expected O, but got Ref
		//IL_0197: Expected O, but got F4
		//IL_01a4: Invalid comparison between O and F4
		//IL_01da: Expected O, but got Ref
		UiManager instance = UiManager.Instance;
		if (instance.pause.IsPaused() || accumulatedTicks >= maxAccumulatedTicks)
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (!instance2.playerInput.IsHoldingJump())
		{
			return;
		}
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerMovement playerMovement = instance3.playerMovement;
		float num3 = default(float);
		if (playerMovement.fallSpeed > 0f)
		{
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerMovement playerMovement2 = instance4.playerMovement;
			float mass = playerMovement2.rb.mass;
			float num = (float)Vector3.upVector * mass;
			float num2 = num * 0.33f;
			playerMovement2.rb.AddForce((Vector3)(&num3), ForceMode.Impulse);
			if (MyTime.time > lastAccumulatedTime)
			{
				accumulatedTicks = 0;
			}
			int num4 = accumulatedTicks + 1;
			accumulatedTicks = num4;
			lastAccumulatedTime = MyTime.time;
			num3 = num2;
		}
		MyPlayer instance5 = MyPlayer.Instance;
		if (instance5.playerMovement.CanFloat())
		{
			MyPlayer instance6 = MyPlayer.Instance;
			PlayerMovement playerMovement3 = instance6.playerMovement;
			Vector3 velocity = playerMovement3.rb.velocity;
			object obj = hoverFallSpeed ^ -0f;
			MyPlayer instance7 = default(MyPlayer);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)velocity.y))
			{
				instance7 = MyPlayer.Instance;
			}
			PlayerMovement playerMovement4 = instance7.playerMovement;
			playerMovement4.rb.velocity = (Vector3)(&num3);
		}
	}

	private unsafe void ChestTick()
	{
		//IL_02a9: Invalid comparison between I4 and F4
		//IL_0163: Expected I, but got O
		//IL_0244: Expected O, but got Ref
		if (!(GameManager.Instance != null) || !(MyPlayer.Instance != null))
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if (instance._003CisCrypt_003Ek__BackingField || MyTime.paused || MyPlayer.Instance.IsDead())
		{
			return;
		}
		GameManager instance2 = GameManager.Instance;
		if (instance2.isPlaying && !ChallengesTracker.HasChallengeModifier("no_items") && !(0f < (currentTimer -= MyTime.fixedDeltaTime)))
		{
			if (spawnIntervalEndSeconds > spawnIntervalSeconds)
			{
				float num = spawnIntervalSeconds + spawnIntervalIncreasePerDrop;
				spawnIntervalSeconds = num;
			}
			currentTimer = spawnIntervalSeconds;
			float maxDistance = default(float);
			Vector3 enemySpawnPositionBiased = SpawnPositions.GetEnemySpawnPositionBiased((EnemyData)null, 0f, 50, maxDistance);
			nint num2 = (nint)typeof(SpawnPositions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v35 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
			nint num3 = 0;
			float num4 = enemySpawnPositionBiased.x - (float)SpawnPositions.INVALID_POS;
			float num5 = enemySpawnPositionBiased.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rcx_v23 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
			float num6 = num5 - 0f;
			float num7 = enemySpawnPositionBiased.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rcx_v23 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
			float num8 = num7 - 0f;
			float num9 = num6 * num6;
			float num10 = num8 * num8;
			float num11 = num4 * num4;
			float num12 = num9 + num11;
			float num13 = num12 + num10;
			if (!(9.9999994E-11f > num13))
			{
				EffectManager instance3 = EffectManager.Instance;
				object obj = default(object);
				EffectManager.Instance.SpawnChestForcePosition(instance3.openChestGhost, (Vector3)(&obj));
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			}
		}
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Hoarder;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_00c8: Expected O, but got I4
		//IL_00ec: Expected I, but got O
		//IL_0105: Expected O, but got I
		//IL_0132: Expected O, but got I
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text = "{0}";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num = 0;
			obj2 = text2;
			obj3 = 1;
			text = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num = 0;
				obj2 = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				obj3 = 0;
				text = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text).Add((string)obj3, obj2);
					object obj5 = default(object);
					throw obj5;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				num = 0;
				obj2 = text2;
				obj3 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
