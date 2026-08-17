using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_BOSS_Paranoia : EnemyControllerBoss
{
	protected float secondBossSpawnInterval = 4000f;

	private Timer secondBossSpawnTimer;

	private const EnemyType PLAYER_FACADE = EnemyType.TP_ADV_MINION_PLAYERFACADE;

	private const EnemyType PARANOIA_FACADE = EnemyType.TP_ADV_MINION_PARANOIAFACADE;

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_0157: Expected O, but got I
		//IL_0408: Expected O, but got I4
		//IL_0422: Expected O, but got I4
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_02e8: Expected O, but got F4
		//IL_0320: Expected O, but got F4
		base.InitEnemy(enemyType, asRemote);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._disableMinueteSpawning = true;
		Action onComplete = delegate
		{
			GameManager core4 = GM.Core;
			GameObject gameObject2 = core4._stage.SpawnEnemyInOuterRect(EnemyType.TP_ADV_MINION_PARANOIAFACADE);
		};
		float num = secondBossSpawnInterval * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(num, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		secondBossSpawnTimer = timer;
		bool flag2 = true;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		nint num2 = 0;
		Vector2 spawnedEnemies = (Vector2)stage2._spawnedEnemies;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (stage2._spawnedEnemies == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v7 (UnityEngine.Vector2)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		float num3 = num;
		Vector2 spawnedEnemies2 = (Vector2)stage2._spawnedEnemies;
		bool flag3 = false;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		EnemyController enemyController = default(EnemyController);
		float num5 = default(float);
		EnemyController enemyController2 = default(EnemyController);
		while (true)
		{
			bool num4 = flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v7 (UnityEngine.Vector2)+18]");
			if ((nint)(num4 ? 1 : 0) >= (nint)0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v7 (UnityEngine.Vector2)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v18+20+v199 @ rbx_v10 (System.Boolean)*8]");
			bool flag4 = (nint)0 == 0;
			bool flag5 = (object)this == null;
			object obj3 = flag5 & flag4;
			bool flag6 = obj3 == null;
			object obj4 = !flag6;
			if (obj4 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v18+20+v199 @ rbx_v10 (System.Boolean)*8]");
				bool flag7;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v18+20+v199 @ rbx_v10 (System.Boolean)*8]");
					object obj5 = 0 - this;
					flag7 = obj5 == null;
				}
				else
				{
					flag7 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v34+260]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v35+19C]");
						if ((nint)0 != 1135)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v36+19C]");
							if ((nint)0 != 1136)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								float2 float5 = arcadeSprite.position;
								GameManager core3 = GM.Core;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								bool flag8 = enemyController.IsBossEnemy();
								EnemyType enemyType2 = (EnemyType)((flag8 ? 1 : 0) + 1135);
								GameObject gameObject = core3._stage.SpawnEnemy(enemyType2, (Vector2)num5, asRemote: false, flag);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								enemyController2.Kill();
								num3 = num5;
								flag2 = false;
								spawnedEnemies2 = (Vector2)num5;
							}
						}
					}
				}
			}
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			bool num6 = flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v7 (UnityEngine.Vector2)+18]");
			if ((nint)(num6 ? 1 : 0) >= (nint)0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void InitSpawnSecondaryBoss()
	{
		Action onComplete = delegate
		{
			GameManager core = GM.Core;
			GameObject gameObject = core._stage.SpawnEnemyInOuterRect(EnemyType.TP_ADV_MINION_PARANOIAFACADE);
		};
		float duration = secondBossSpawnInterval * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		secondBossSpawnTimer = timer;
	}

	private void SpawnSecondBoss()
	{
		GameManager core = GM.Core;
		GameObject gameObject = core._stage.SpawnEnemyInOuterRect(EnemyType.TP_ADV_MINION_PARANOIAFACADE);
	}

	protected override void SpawnBossMinions(EnemyType type, int spawnAmount)
	{
		//IL_00ca: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		if ((!bossSpawnsMinions && !bossSpawnsMinionsOnDeath) || ((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField || spawnAmount <= 0 || (bossSpawnsMinionsOnDeath && !((EnemyController)this)._003CIsDead_003Ek__BackingField))
		{
			return;
		}
		if (spawnAmount != 1)
		{
			object obj = 0;
			do
			{
				GameManager core = GM.Core;
				GameObject gameObject = core._stage.SpawnEnemyInOuterRect(type);
				obj++;
			}
			while ((nint)obj < spawnAmount);
		}
		else
		{
			GameManager core2 = GM.Core;
			GameObject gameObject2 = core2._stage.SpawnEnemyInOuterRect(type);
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._disableMinueteSpawning = false;
		if (secondBossSpawnTimer != null)
		{
			secondBossSpawnTimer.Cancel();
		}
	}

	private void _003CInitSpawnSecondaryBoss_003Eb__5_0()
	{
		GameManager core = GM.Core;
		GameObject gameObject = core._stage.SpawnEnemyInOuterRect(EnemyType.TP_ADV_MINION_PARANOIAFACADE);
	}
}
