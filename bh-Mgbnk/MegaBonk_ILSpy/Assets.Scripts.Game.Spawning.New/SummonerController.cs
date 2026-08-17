using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New.Summoners;
using Assets.Scripts.Game.Spawning.New.Timelines;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.Spawning.New;

public class SummonerController
{
	public StageSummoner stageSummoner;

	private SpecialSkeletonSummoner specialSkeletonSummoner;

	private BaseSummoner swarmSummoner;

	private BaseSummoner finalSwarmSummoner;

	private List<BaseSummoner> summoners;

	private int id;

	private int currentTimelineEvent;

	private StageTimeline timeline;

	public static Action A_SwarmStarted;

	public static Action A_FinalSwarmStarted;

	public static Action A_MiniBoss;

	public static Action A_FinalSwarmStopped;

	private float lastAddedNewEnemyTime;

	private bool hadEventThisTick;

	private float swarmOverAtTime;

	private int _003CminibossCount_003Ek__BackingField;

	private List<EEnemy> minibossPool;

	private bool isFinalSwarmStarted;

	private float bossDeadGracePeriod;

	private bool isFinalBossDead;

	private bool areSummonersDestroyed;

	public int minibossCount
	{
		get
		{
			return _003CminibossCount_003Ek__BackingField;
		}
		private set
		{
			_003CminibossCount_003Ek__BackingField = value;
		}
	}

	public SummonerController()
	{
		//IL_0277: Expected I4, but got I8
		//IL_01db: Expected I, but got O
		//IL_01e4: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_00dc: Expected O, but got I4
		//IL_0233: Expected I, but got O
		//IL_023c: Expected O, but got I4
		//IL_0245: Expected O, but got I4
		currentTimelineEvent = -1;
		List<EEnemy> list = new List<EEnemy>();
		minibossPool = list;
		bossDeadGracePeriod = 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		List<BaseSummoner> list2 = (summoners = new List<BaseSummoner>());
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		bool flag = (object)MapController._003CcurrentStage_003Ek__BackingField == null;
		List<BaseSummoner> list3 = list2;
		if (!flag)
		{
			timeline = stageData.stageTimeline;
			if (!MapController.isFinalBossStage)
			{
				list3 = (List<BaseSummoner>)(object)timeline;
				int num = id + 1;
				id = num;
				if (timeline == null)
				{
					goto IL_025c;
				}
				StageSummoner stageSummoner = new StageSummoner(id, (List<EEnemy>)list3._size);
				this.stageSummoner = stageSummoner;
				int num2 = id + 1;
				id = num2;
				List<EEnemy> defaultEnemies = new List<EEnemy>();
				SpecialSkeletonSummoner specialSkeletonSummoner = (SpecialSkeletonSummoner)new BaseSummoner(id, defaultEnemies);
				this.specialSkeletonSummoner = specialSkeletonSummoner;
				AddSummoner(this.stageSummoner);
				AddSummoner(this.specialSkeletonSummoner);
			}
			Action<bool> b = OnBossDied;
			Delegate obj = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
			if ((object)obj == null)
			{
				InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			bool flag2 = action == null;
			nint num3 = (nint)typeof(Action<bool>);
			object obj2 = 0;
			object obj3 = 0;
			list3 = (List<BaseSummoner>)(object)obj;
			if (!flag2)
			{
				InteractableBossSpawner.A_BossDefeated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num3 = (nint)typeof(Action<bool>);
				obj2 = 0;
				obj3 = 0;
				list3 = (List<BaseSummoner>)(object)obj;
				if (!flag3)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			return;
		}
		goto IL_025c;
		IL_025c:
		throw new NullReferenceException();
	}

	public void Tick()
	{
		GameManager instance = GameManager.Instance;
		if (!instance.isPlaying)
		{
			return;
		}
		TickTimeline();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		BaseSummoner baseSummoner = default(BaseSummoner);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (baseSummoner == null)
				{
					break;
				}
				baseSummoner.Tick();
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	public float GetMaxTimeLength()
	{
		return timeline.GetStageTime();
	}

	private void TickTimeline()
	{
		//IL_00cc: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_034b: Invalid comparison between F4 and O
		hadEventThisTick = false;
		float num = (GameManager.Instance.HasEnteredBossRoom() ? 600f : timeline.GetStageTime());
		if (!(MyTime.stageTimer < num) && !isFinalSwarmStarted && !isFinalSwarmStarted)
		{
			isFinalSwarmStarted = true;
			TryStopSummoners();
			int num2 = id + 1;
			id = num2;
			List<EEnemy> list = new List<EEnemy>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v58 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v58 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v58 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v46+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(EEnemy.Ghost);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v58 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 16;
			}
			SwarmSummoner swarmSummoner = new SwarmSummoner(id, list);
			finalSwarmSummoner = swarmSummoner;
			AddSummoner(finalSwarmSummoner);
			Action a_FinalSwarmStarted = A_FinalSwarmStarted;
			if (A_FinalSwarmStarted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v375.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		if (MapController.isFinalBossStage || GameManager.Instance.HasEnteredBossRoom() || MapController.isFinalBossStage || isFinalSwarmStarted || isFinalBossDead)
		{
			return;
		}
		if (this.swarmSummoner != null && !(MyTime.stageTimer < swarmOverAtTime))
		{
			bool flag = ((List<object>)(object)summoners).Remove((object)this.swarmSummoner);
			this.swarmSummoner.Cleanup();
			this.swarmSummoner = null;
		}
		StageTimeline stageTimeline = timeline;
		List<TimelineEvent> events = stageTimeline.events;
		int num4 = currentTimelineEvent + 1;
		if (num4 < events._size)
		{
			StageTimeline stageTimeline2 = timeline;
			TimelineEvent timelineEvent = stageTimeline2.events.get_Item(num4);
			TimelineEvent timelineEvent2 = stageTimeline2.events.get_Item(0);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)MyTime.stageTimer) >= System.Runtime.CompilerServices.Unsafe.As<TimelineEvent, UIntPtr>(ref timelineEvent2))
			{
				StartEvent(num4);
				hadEventThisTick = true;
			}
		}
		StageTimeline stageTimeline3 = timeline;
		float num5 = stageTimeline3.checkNewEnemyInterval + lastAddedNewEnemyTime;
		if (!(MyTime.stageTimer < num5))
		{
			TryAddNewEnemyCard();
		}
	}

	public float GetStageTimeMax()
	{
		if (!GameManager.Instance.HasEnteredBossRoom())
		{
			return timeline.GetStageTime();
		}
		return 600f;
	}

	private bool AreEventsDisabled()
	{
		//IL_006d: Expected I4, but got O
		if (MapController.isFinalBossStage)
		{
			return true;
		}
		if ((object)GameManager.Instance != null)
		{
			return GameManager.Instance.HasEnteredBossRoom();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void TryAddNewEnemyCard()
	{
		//IL_00b2: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_011b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		float num = default(float);
		lastAddedNewEnemyTime = num;
		if (!hadEventThisTick && !isFinalSwarmStarted && swarmSummoner == null && this.stageSummoner.AddEnemyToPoolAndPickNewCard(null, out var selectedEnemy))
		{
			StageSummoner stageSummoner = this.stageSummoner;
			List<EEnemy> list = new List<EEnemy>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v10+18]");
			if (num2 >= 0)
			{
				list.AddWithResize(selectedEnemy);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			StageTimeline stageTimeline = timeline;
			float num3 = stageTimeline.checkNewEnemyInterval * 0.5f;
			((BaseSummoner)stageSummoner).isWaveMode = true;
			float waveModeOverAtTime = num3 + MyTime.time;
			((BaseSummoner)stageSummoner).waveModeOverAtTime = waveModeOverAtTime;
			List<EnemyCard> waveModeCards = ((BaseSummoner)stageSummoner).GenerateCards(list);
			((BaseSummoner)stageSummoner).waveModeCards = waveModeCards;
		}
	}

	public void StartEvent(int eventIndex)
	{
		//IL_00a8: Expected O, but got I4
		//IL_010c: Expected I4, but got O
		//IL_0111: Expected I, but got O
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		StageTimeline stageTimeline = timeline;
		int index = default(int);
		currentTimelineEvent = index;
		if (timeline != null && stageTimeline.events != null)
		{
			TimelineEvent timelineEvent = stageTimeline.events.get_Item(index);
			bool flag = timelineEvent == null;
			nint num = 0;
			if (!flag)
			{
				index = (int)timelineEvent.eTimelineEvent;
				bool flag2 = timelineEvent.eTimelineEvent == ETimelineEvent.EAddEnemyCard;
				num = 0;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					Exception ex = new Exception("Not added yet");
					ex._002Ector("Not added yet");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				object obj = timelineEvent.eTimelineEvent - 1;
				if (flag2)
				{
					EventMiniboss(timelineEvent);
					return;
				}
				if ((nint)obj != 1)
				{
					return;
				}
				int num2 = id + 1;
				id = num2;
				SwarmSummoner swarmSummoner = new SwarmSummoner(id, timelineEvent.enemies);
				this.swarmSummoner = swarmSummoner;
				AddSummoner(this.swarmSummoner);
				StageSummoner stageSummoner = this.stageSummoner;
				bool flag3 = this.stageSummoner == null;
				index = (int)this.swarmSummoner;
				num = unchecked((nint)null);
				if (!flag3)
				{
					((BaseSummoner)stageSummoner).slowmodeMultiplier = 0f;
					stageSummoner.slowmode = true;
					float slowmodeOverAtTime = timelineEvent.duration + MyTime.time;
					((BaseSummoner)stageSummoner).slowmodeOverAtTime = slowmodeOverAtTime;
					float num3 = timelineEvent.timeMinutes * 60f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
					object obj3 = default(object);
					object obj2 = obj3 + timelineEvent.duration;
					float num4 = (float)obj2 - 1f;
					swarmOverAtTime = num4;
					Action a_SwarmStarted = A_SwarmStarted;
					if (A_SwarmStarted != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v206.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void EventSwarm(TimelineEvent timelineEvent)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		int num = id + 1;
		id = num;
		SwarmSummoner swarmSummoner = new SwarmSummoner(id, timelineEvent.enemies);
		this.swarmSummoner = swarmSummoner;
		AddSummoner(this.swarmSummoner);
		StageSummoner stageSummoner = this.stageSummoner;
		((BaseSummoner)stageSummoner).slowmodeMultiplier = 0f;
		stageSummoner.slowmode = true;
		float slowmodeOverAtTime = timelineEvent.duration + MyTime.time;
		((BaseSummoner)stageSummoner).slowmodeOverAtTime = slowmodeOverAtTime;
		float num2 = timelineEvent.timeMinutes * 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		object obj2 = default(object);
		object obj = obj2 + timelineEvent.duration;
		float num3 = (float)obj - 1f;
		swarmOverAtTime = num3;
		Action a_SwarmStarted = A_SwarmStarted;
		if (A_SwarmStarted != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v187.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe void EventMiniboss(TimelineEvent timelineEvent)
	{
		//IL_0602: Expected O, but got I4
		//IL_060b: Expected O, but got I4
		//IL_021f: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_01eb: Expected O, but got Ref
		//IL_00fd: Expected I, but got O
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0320: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_0157: Expected I4, but got F4
		//IL_0393: Expected I, but got O
		//IL_04e9: Expected O, but got F4
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected O, but got Unknown
		//IL_0564: Expected O, but got I4
		List<EEnemy> list = minibossPool;
		bool flag = minibossPool == null;
		SummonerController summonerController = this;
		object obj;
		List<EEnemy>.Enumerator enumerator3 = default(List<EEnemy>.Enumerator);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v4 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			if ((nint)0 > (nint)0)
			{
				obj = 0;
				List<EEnemy>.Enumerator enumerator = (List<EEnemy>.Enumerator)0;
				summonerController = this;
				goto IL_06a5;
			}
			StageTimeline stageTimeline = timeline;
			bool flag2 = timeline == null;
			summonerController = this;
			if (!flag2)
			{
				bool flag3 = stageTimeline.minibosses == null;
				summonerController = this;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
					nint num = 0;
					List<EEnemy>.Enumerator enumerator2 = default(List<EEnemy>.Enumerator);
					float num2 = default(float);
					while (enumerator2.MoveNext())
					{
						summonerController = (SummonerController)(object)minibossPool;
						if (minibossPool != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v15 (Assets.Scripts.Game.Spawning.New.SummonerController)+1C]");
							_ = (nint)0 + (nint)1;
							num = (nint)summonerController.stageSummoner;
							if (summonerController.stageSummoner != null)
							{
								SpecialSkeletonSummoner obj2 = summonerController.specialSkeletonSummoner;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v18 (Il2CppMethodInfo)+18]");
								if ((nint)obj2 >= 0)
								{
									minibossPool.AddWithResize((EEnemy)num2);
									num = 0;
									continue;
								}
								SpecialSkeletonSummoner specialSkeletonSummoner = (SpecialSkeletonSummoner)(summonerController.specialSkeletonSummoner + 1);
								summonerController.specialSkeletonSummoner = specialSkeletonSummoner;
								SpecialSkeletonSummoner obj3 = summonerController.specialSkeletonSummoner;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v18 (Il2CppMethodInfo)+18]");
								if ((nint)obj3 < 0)
								{
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					enumerator2.Dispose();
					obj = 0;
					float num3 = num2;
					List<EEnemy>.Enumerator enumerator = enumerator3;
					enumerator3 = (List<EEnemy>.Enumerator)0;
					summonerController = (SummonerController)(&enumerator2);
					goto IL_06a5;
				}
			}
		}
		goto IL_05af;
		IL_05af:
		throw new NullReferenceException();
		IL_0572:
		StageSummoner stageSummoner = this.stageSummoner;
		if (this.stageSummoner != null)
		{
			((BaseSummoner)stageSummoner).slowmodeMultiplier = 0.25f;
			stageSummoner.slowmode = true;
			float slowmodeOverAtTime = MyTime.time + 20f;
			((BaseSummoner)stageSummoner).slowmodeOverAtTime = slowmodeOverAtTime;
			int num4 = _003CminibossCount_003Ek__BackingField + 1;
			_003CminibossCount_003Ek__BackingField = num4;
			Action a_MiniBoss = A_MiniBoss;
			if (A_MiniBoss != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v883.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return;
		}
		goto IL_05af;
		IL_06a5:
		List<EEnemy> list2 = minibossPool;
		if (minibossPool != null)
		{
			summonerController = (SummonerController)(object)MyRandom.random;
			if (MyRandom.random != null)
			{
				nint num5 = (nint)summonerController;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v18 (Il2CppClass<Assets.Scripts.Game.Spawning.New.SummonerController>)+1A0]");
				EEnemyFlag eEnemyFlag = EEnemyFlag.None;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v640 @ rax_v18 (Il2CppClass<Assets.Scripts.Game.Spawning.New.SummonerController>)+198] (should have been resolved before IL gen)");
				bool flag4 = minibossPool == null;
				summonerController = (SummonerController)(object)minibossPool;
				if (!flag4)
				{
					int index = default(int);
					EEnemy eEnemy = minibossPool.get_Item(index);
					bool flag5 = minibossPool == null;
					summonerController = (SummonerController)(object)minibossPool;
					if (!flag5)
					{
						minibossPool.RemoveAt(index);
						bool flag6 = (object)DataManager.Instance == null;
						summonerController = (SummonerController)(object)DataManager.Instance;
						if (!flag6)
						{
							EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
							summonerController = (SummonerController)(object)GameManager.Instance;
							if ((object)GameManager.Instance != null)
							{
								object obj4 = (summonerController.isFinalSwarmStarted ? 1 : 0) + 1;
								bool flag7 = (nint)obj4 <= 0;
								object obj5 = 0;
								if (flag7)
								{
									goto IL_0572;
								}
								object obj6 = obj;
								float num6 = default(float);
								float extraSizeMultiplier = default(float);
								while ((object)MyPlayer.Instance != null)
								{
									float spawnDirectionBias = MyPlayer.Instance.GetSpawnDirectionBias();
									Vector3 enemySpawnPositionBiased = SpawnPositions.GetEnemySpawnPositionBiased((EnemyData)null, spawnDirectionBias, 50, num6);
									nint num7 = (nint)typeof(SpawnPositions);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v43 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
									nint num8 = 0;
									float num9 = enemySpawnPositionBiased.x - (float)SpawnPositions.INVALID_POS;
									float num10 = enemySpawnPositionBiased.y;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rcx_v31 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
									float num11 = num10 - 0f;
									float num12 = enemySpawnPositionBiased.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rcx_v31 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
									float num13 = num12 - 0f;
									float num14 = num11 * num11;
									float num3 = num9 * num9;
									float num15 = num14 + num3;
									float num16 = num13 * num13;
									float num17 = num15 + num16;
									if (9.9999994E-11f > num17)
									{
										if ((object)MyPlayer.Instance == null)
										{
											break;
										}
										Transform transform = MyPlayer.Instance.transform;
										if ((object)transform == null)
										{
											break;
										}
										Vector3 position = transform.position;
										num8 = (nint)(&enumerator3);
									}
									if ((object)enemyData == null || (object)EnemyManager.Instance == null)
									{
										break;
									}
									Enemy enemy = EnemyManager.Instance.SpawnBoss(enemyData.enemyName, id, EEnemyFlag.SummonerMiniboss, (Vector3)num6, extraSizeMultiplier);
									if (enemy == null)
									{
										Debug.LogError("Boss is null, failed to spawn mini boss, NOT GOOD UH OHH FUCKkkk");
										summonerController = (SummonerController)(object)"Boss is null, failed to spawn mini boss, NOT GOOD UH OHH FUCKkkk";
									}
									obj6++;
									bool flag8 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
									eEnemyFlag = EEnemyFlag.SummonerMiniboss;
									obj5 = 0;
									if (flag8)
									{
										continue;
									}
									goto IL_0572;
								}
							}
						}
					}
				}
			}
		}
		goto IL_05af;
	}

	private bool CanAddNewEnemyCard()
	{
		if (!hadEventThisTick && !isFinalSwarmStarted && swarmSummoner == null)
		{
			return true;
		}
		return false;
	}

	public bool IsFinalSwarm()
	{
		return isFinalSwarmStarted;
	}

	private void StartFinalSwarm()
	{
		//IL_0067: Expected O, but got I
		//IL_00c1: Expected O, but got I
		if (!isFinalSwarmStarted)
		{
			isFinalSwarmStarted = true;
			TryStopSummoners();
			int num = id + 1;
			id = num;
			List<EEnemy> list = new List<EEnemy>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v8+18]");
			if (num2 >= 0)
			{
				list.AddWithResize(EEnemy.Ghost);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 16;
			}
			SwarmSummoner swarmSummoner = new SwarmSummoner(id, list);
			finalSwarmSummoner = swarmSummoner;
			AddSummoner(finalSwarmSummoner);
			Action a_FinalSwarmStarted = A_FinalSwarmStarted;
			if (A_FinalSwarmStarted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v237.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public void StopFinalSwarm()
	{
		isFinalSwarmStarted = false;
		areSummonersDestroyed = false;
		TryStopSummoners();
		StageTimeline stageTimeline = timeline;
		int num = id + 1;
		id = num;
		StageSummoner stageSummoner = new StageSummoner(id, stageTimeline.startEnemies);
		this.stageSummoner = stageSummoner;
		AddSummoner(this.stageSummoner);
		areSummonersDestroyed = false;
	}

	private void AddSummoner(BaseSummoner summoner)
	{
		List<object> list = (List<object>)(object)summoners;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)summoner);
			return;
		}
		int size = list._size + 1;
		list._size = size;
		int num = default(int);
		items[num] = summoner;
	}

	private void DestroySummoner(BaseSummoner summoner)
	{
		bool flag = ((List<object>)(object)summoners).Remove((object)summoner);
		summoner.Cleanup();
	}

	public unsafe List<Enemy> SpawnStageBoss(Vector3 pos)
	{
		//IL_0027: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0253: Expected O, but got Ref
		//IL_00b7: Expected I4, but got I8
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		if (this.stageSummoner != null)
		{
			StageSummoner stageSummoner = this.stageSummoner;
			((BaseSummoner)stageSummoner).slowmodeMultiplier = 0.5f;
			stageSummoner.slowmode = true;
			float slowmodeOverAtTime = MyTime.time + 30f;
			((BaseSummoner)stageSummoner).slowmodeOverAtTime = slowmodeOverAtTime;
		}
		List<Enemy> list = new List<Enemy>();
		GameManager instance = GameManager.Instance;
		object obj = instance.bossCurses + 1;
		if ((nint)obj > 0)
		{
			float num = pos.x;
			float num2 = pos.y;
			float num3 = pos.z;
			object obj2 = 0;
			float x = default(float);
			Vector3 pos2 = default(Vector3);
			float extraSizeMultiplier = default(float);
			bool flag;
			do
			{
				Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
				Vector3 vector = VectorExtensions.XZVector((Vector3)(&x));
				float num4 = vector.x * 7f;
				float num5 = vector.y * 7f;
				float num6 = num4 + num;
				float num7 = num5 + num2;
				float num8 = vector.z * 7f;
				float num9 = num8 + num3;
				StageTimeline stageTimeline = timeline;
				EnemyData boss = stageTimeline.boss;
				Enemy enemy = EnemyManager.Instance.SpawnBoss(boss.enemyName, -1, EEnemyFlag.StageBoss, pos2, extraSizeMultiplier);
				int version = list._version + 1;
				list._version = version;
				Enemy[] items = list._items;
				int size = list._size;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)enemy);
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					if (list._size >= items.Length)
					{
						return (List<Enemy>)(object)new IndexOutOfRangeException();
					}
					items[size] = enemy;
				}
				obj2++;
				flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				x = insideUnitSphere.x;
				num3 = num9;
				num2 = num7;
				num = num6;
			}
			while (flag);
		}
		return list;
	}

	private void OnBossDied(bool isLastStage)
	{
		TryStopSummoners();
		isFinalBossDead = true;
		float num = (GameManager.Instance.HasEnteredBossRoom() ? 600f : timeline.GetStageTime());
		float num2 = num - bossDeadGracePeriod;
		if (num2 > MyTime.stageTimer)
		{
			float stageTimeMax = GetStageTimeMax();
			float stageTimer = stageTimeMax - bossDeadGracePeriod;
			MyTime.stageTimer = stageTimer;
		}
	}

	private unsafe void TryStopSummoners()
	{
		if (areSummonersDestroyed)
		{
			return;
		}
		areSummonersDestroyed = true;
		List<object> list = Enumerable.ToList((IEnumerable<object>)summoners);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				((List<BaseSummoner>.Enumerator*)(&enumerator))->Dispose();
				List<BaseSummoner> list2 = new List<BaseSummoner>();
				summoners = list2;
				return;
			}
			if (summoners == null)
			{
				break;
			}
			bool flag = ((List<object>)(object)summoners).Remove(obj);
			if (obj != null)
			{
				((BaseSummoner)obj).Cleanup();
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public void Cleanup()
	{
		//IL_006c: Expected I, but got O
		//IL_0219: Expected O, but got I
		//IL_0037: Expected I, but got O
		//IL_008c: Expected O, but got I4
		//IL_00bc: Expected I, but got O
		//IL_00ca: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		Action<bool> value = OnBossDied;
		Delegate obj = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value);
		nint num;
		if ((object)obj == null)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj;
			num = (nint)InteractableBossSpawner.A_BossDefeated;
			goto IL_00e1;
		}
		bool flag = ((List<BaseSummoner>)(object)obj).Remove((BaseSummoner)(object)typeof(Action<bool>));
		bool flag2 = !flag;
		nint num2 = (nint)typeof(Action<bool>);
		Delegate obj2 = obj;
		if (!flag2)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)flag;
			bool flag3 = ((List<BaseSummoner>)(object)obj).Remove((BaseSummoner)(object)typeof(Action<bool>));
			bool flag4 = !flag3;
			num = (nint)typeof(Action<bool>);
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj;
			if (!flag4)
			{
				goto IL_00e1;
			}
			bool flag5 = ((List<BaseSummoner>)(object)obj2).Remove((BaseSummoner)num2);
		}
		bool flag6 = ((List<BaseSummoner>)(object)obj2).Remove((BaseSummoner)num2);
		return;
		IL_00e1:
		bool flag7 = summoners == null;
		BaseSummoner[] array2 = default(BaseSummoner[]);
		BaseSummoner[] array = array2;
		Delegate obj3 = default(Delegate);
		obj2 = obj3;
		if (!flag7)
		{
			array2 = summoners.ToArray();
			bool flag8 = array2 == null;
			array = (BaseSummoner[])num;
			obj2 = obj;
			if (!flag8)
			{
				obj3 = null;
				Delegate obj4 = null;
				while (true)
				{
					if ((nint)obj4 >= array2.Length)
					{
						return;
					}
					bool flag9 = summoners == null;
					array = array2;
					obj2 = obj3;
					if (flag9)
					{
						break;
					}
					bool flag10 = ((List<object>)(object)summoners).Remove((object)array2[(object)obj3]);
					bool flag11 = array2[(object)obj3] == null;
					array = array2;
					obj2 = obj;
					if (flag11)
					{
						break;
					}
					array2[(object)obj3].Cleanup();
					obj3 = (Delegate)(obj3 + 1);
					obj4 = obj3;
				}
			}
		}
		throw new NullReferenceException();
	}
}
