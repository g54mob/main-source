using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies.DLC6;

public class EME_TeleporterBoss_Specter : EME_TeleporterBoss
{
	private const float SPAWN_TIME_OFFSET = 500f;

	protected override void InitSpawnBossBullets()
	{
		//IL_0020: Expected I, but got O
		if (bossSpawnsBullets)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.DLC6.EME_TeleporterBoss_Specter>)+510]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			float duration = bulletSpawnInterval * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bulletSpawnTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			BulletSpawnTimer = bulletSpawnTimer;
		}
	}

	protected override void SpawnBossBullets()
	{
		if (!bossSpawnsBullets || ((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField || ((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		Action onComplete = delegate
		{
			//IL_006c: Expected O, but got I4
			GameObject gameObject = base.gameObject;
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj != null)
			{
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003CSpawnBossBullets_003Eb__2_0()
	{
		//IL_006c: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null)
		{
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
	}
}
