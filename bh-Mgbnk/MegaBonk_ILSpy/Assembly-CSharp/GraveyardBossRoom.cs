using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GraveyardBossRoom : MonoBehaviour
{
	private enum ELavaState
	{
		Idle,
		Rising,
		UpIdle,
		Lowering
	}

	public Transform playerTeleportTransform;

	public Transform bossSpawnTransform;

	public InteractableGhostBossLeave interactableGhostBossLeave;

	private bool _003CisFightingBoss_003Ek__BackingField;

	private Enemy bossEnemy;

	private float spawnBossAtTime;

	private bool _003ChasSpawnedBoss_003Ek__BackingField;

	public Light directionalLight;

	public AegisRenderer bossShields;

	public MusicTrack musicTrackBoss;

	private float timer;

	private static float darknessLightIntensityMultiplier = 1f;

	public static bool isPlayerInsideLight;

	public static Action A_BossDied;

	public BossLamp[] lamps;

	private int lampCount;

	private float lightDropFromLamps = 0.4f;

	private float currentLightIntensity;

	private float defaultLightIntensity;

	private Color defaultAmbientLight;

	private float bossDeadGracePeriod = 10f;

	private float bossDeadAtTime;

	public bool isBossDefeated;

	private float bdLightFadeDuration = 4f;

	private float bdLightStartFadeDelay = 0.25f;

	private float bdLightStartIntensity;

	private float bdLightIntensity;

	private float openGateDelay = 3f;

	private bool hasOpenedGate;

	public GraveyardBossMetalGate metalGate;

	private bool hasUsedDamageOtherThanLamps;

	public Transform lava;

	public Transform risingObjects;

	public Transform pillars;

	public AudioSource sfxRumble;

	public ShakePreset rumbleShake;

	private float lavaInterval = 30f;

	private float lavaDuration = 25f;

	private float lavaRiseTime = 4f;

	private float lavaStartTime;

	private float lavaEndTime;

	private float lavaRiseTimer;

	private Vector3 risingObjectsPositionDefault;

	private Vector3 risingObjectsPositionUp;

	private Vector3 lavaPosDefault;

	private Vector3 lavaPosUp;

	private Vector3 pillarsPosDefault;

	private Vector3 pillarsPosUp;

	private ELavaState lavaState;

	public bool isFightingBoss
	{
		get
		{
			return _003CisFightingBoss_003Ek__BackingField;
		}
		private set
		{
			_003CisFightingBoss_003Ek__BackingField = value;
		}
	}

	public bool hasSpawnedBoss
	{
		get
		{
			return _003ChasSpawnedBoss_003Ek__BackingField;
		}
		private set
		{
			_003ChasSpawnedBoss_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_071f: Expected O, but got I4
		//IL_0792: Expected O, but got I4
		//IL_07a8: Expected I, but got O
		//IL_07ce: Expected O, but got I4
		//IL_07e4: Expected I, but got O
		//IL_080a: Expected O, but got I4
		//IL_0820: Expected I, but got O
		//IL_01e1: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0899: Expected I, but got O
		//IL_0235: Expected I, but got O
		//IL_0246: Expected O, but got I4
		//IL_02d8: Expected I, but got O
		//IL_02e9: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
		//IL_0434: Expected O, but got I4
		//IL_08e6: Expected O, but got I4
		//IL_08fc: Expected I, but got O
		//IL_092a: Expected O, but got I4
		//IL_0940: Expected I, but got O
		//IL_096e: Expected O, but got I4
		//IL_0984: Expected I, but got O
		//IL_09b2: Expected O, but got I4
		//IL_09c8: Expected I, but got O
		//IL_069b: Expected O, but got I4
		//IL_06ef: Expected O, but got I4
		Delegate obj = BossLamp.A_Activate;
		Action action = LampActivate;
		Delegate obj2 = Delegate.Combine(BossLamp.A_Activate, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			BossLamp.A_Activate = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_09e6;
			}
			BossLamp.A_Activate = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_09f6;
			}
		}
		Action b = LampDeactivate;
		Delegate obj7 = Delegate.Combine(BossLamp.A_Deactivate, b);
		if ((object)obj7 == null)
		{
			BossLamp.A_Deactivate = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0a01;
			}
			BossLamp.A_Deactivate = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0a11;
			}
		}
		Action<Enemy> b2 = OnEnemyReleased;
		Delegate obj10 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b2);
		nint num4;
		Delegate obj11;
		if ((object)obj10 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action3 = default(Action<Enemy>);
			bool flag8 = action3 == null;
			num4 = (nint)typeof(Action<Enemy>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_0856;
			}
			Enemy.A_EnemyReleasedFromPool = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num4 = (nint)typeof(Action<Enemy>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_0866;
			}
		}
		Action<Enemy, DamageContainer> b3 = OnEnemyDied;
		Delegate obj13 = Delegate.Combine(Enemy.A_EnemyDied, b3);
		if ((object)obj13 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag10 = action4 == null;
			num4 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag10)
			{
				goto IL_0876;
			}
			Enemy.A_EnemyDied = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj14 = default(object);
			bool flag11 = obj14 == null;
			obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
			action2 = (Action)obj13;
			obj4 = 0;
			obj5 = null;
			if (flag11)
			{
				goto IL_0886;
			}
		}
		Action<float> b4 = OnLightIntensityChangeFromDarknessAttack;
		Delegate obj15 = Delegate.Combine(GhostKingAttackDarkness.A_LightIntensity, b4);
		if ((object)obj15 == null)
		{
			GhostKingAttackDarkness.A_LightIntensity = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action5 = default(Action<float>);
			bool flag12 = action5 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj15;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_08a6;
			}
			GhostKingAttackDarkness.A_LightIntensity = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj15;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_08b6;
			}
		}
		obj = GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget;
		Action action6 = DarknessAttackStarted;
		Delegate obj17 = Delegate.Combine(GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget, action6);
		if ((object)obj17 == null)
		{
			GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget = null;
		}
		else
		{
			bool flag14 = (object)obj17.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag14)
			{
				obj18 = obj17;
			}
			bool flag15 = (object)obj18 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj17;
			nint num5 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0a21;
			}
			GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget = (Action)obj18;
			bool flag16 = (object)obj17.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag16)
			{
				obj19 = obj17;
			}
			bool flag17 = (object)obj19 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj17;
			nint num6 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0a31;
			}
		}
		obj = GhostKingAttackDarkness.A_Explode;
		Action action7 = DarknessExplosion;
		Delegate obj20 = Delegate.Combine(GhostKingAttackDarkness.A_Explode, action7);
		if ((object)obj20 == null)
		{
			GhostKingAttackDarkness.A_Explode = null;
		}
		else
		{
			bool flag18 = (object)obj20.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag18)
			{
				obj21 = obj20;
			}
			bool flag19 = (object)obj21 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj20;
			nint num7 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0a41;
			}
			GhostKingAttackDarkness.A_Explode = (Action)obj21;
			bool flag20 = (object)obj20.GetType() != typeof(Action);
			Delegate obj22 = null;
			if (!flag20)
			{
				obj22 = obj20;
			}
			bool flag21 = (object)obj22 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj20;
			nint num8 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0a51;
			}
		}
		Action<Enemy, DamageContainer> b5 = OnEnemyDamage;
		Delegate obj23 = Delegate.Combine(Enemy.A_Damage, b5);
		if ((object)obj23 == null)
		{
			Enemy.A_Damage = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action8 = default(Action<Enemy, DamageContainer>);
		bool flag22 = action8 == null;
		obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj23;
		obj4 = 0;
		obj5 = null;
		if (flag22)
		{
			goto IL_09d6;
		}
		Enemy.A_Damage = action8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj24 = default(object);
		bool flag23 = obj24 == null;
		obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj23;
		obj4 = 0;
		obj5 = null;
		if (!flag23)
		{
			return;
		}
		goto IL_09e6;
		IL_0a41:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a31;
		IL_0a31:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a21;
		IL_09f6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0876:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0866;
		IL_0a51:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a41;
		IL_08a6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0886;
		IL_0886:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = (nint)obj;
		obj11 = action2;
		goto IL_0876;
		IL_0a21:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08b6;
		IL_0856:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a11;
		IL_08b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08a6;
		IL_0866:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0856;
		IL_0a11:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a01;
		IL_0a01:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f6;
		IL_09e6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d6;
		IL_09d6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a51;
	}

	private void OnDestroy()
	{
		//IL_071f: Expected O, but got I4
		//IL_0792: Expected O, but got I4
		//IL_07a8: Expected I, but got O
		//IL_07ce: Expected O, but got I4
		//IL_07e4: Expected I, but got O
		//IL_080a: Expected O, but got I4
		//IL_0820: Expected I, but got O
		//IL_01e1: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0899: Expected I, but got O
		//IL_0235: Expected I, but got O
		//IL_0246: Expected O, but got I4
		//IL_02d8: Expected I, but got O
		//IL_02e9: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
		//IL_0434: Expected O, but got I4
		//IL_08e6: Expected O, but got I4
		//IL_08fc: Expected I, but got O
		//IL_092a: Expected O, but got I4
		//IL_0940: Expected I, but got O
		//IL_096e: Expected O, but got I4
		//IL_0984: Expected I, but got O
		//IL_09b2: Expected O, but got I4
		//IL_09c8: Expected I, but got O
		//IL_069b: Expected O, but got I4
		//IL_06ef: Expected O, but got I4
		Delegate obj = BossLamp.A_Activate;
		Action action = LampActivate;
		Delegate obj2 = Delegate.Remove(BossLamp.A_Activate, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			BossLamp.A_Activate = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_09e6;
			}
			BossLamp.A_Activate = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_09f6;
			}
		}
		Action value = LampDeactivate;
		Delegate obj7 = Delegate.Remove(BossLamp.A_Deactivate, value);
		if ((object)obj7 == null)
		{
			BossLamp.A_Deactivate = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0a01;
			}
			BossLamp.A_Deactivate = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0a11;
			}
		}
		Action<Enemy> value2 = OnEnemyReleased;
		Delegate obj10 = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value2);
		nint num4;
		Delegate obj11;
		if ((object)obj10 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action3 = default(Action<Enemy>);
			bool flag8 = action3 == null;
			num4 = (nint)typeof(Action<Enemy>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_0856;
			}
			Enemy.A_EnemyReleasedFromPool = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num4 = (nint)typeof(Action<Enemy>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_0866;
			}
		}
		Action<Enemy, DamageContainer> value3 = OnEnemyDied;
		Delegate obj13 = Delegate.Remove(Enemy.A_EnemyDied, value3);
		if ((object)obj13 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag10 = action4 == null;
			num4 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag10)
			{
				goto IL_0876;
			}
			Enemy.A_EnemyDied = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj14 = default(object);
			bool flag11 = obj14 == null;
			obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
			action2 = (Action)obj13;
			obj4 = 0;
			obj5 = null;
			if (flag11)
			{
				goto IL_0886;
			}
		}
		Action<float> value4 = OnLightIntensityChangeFromDarknessAttack;
		Delegate obj15 = Delegate.Remove(GhostKingAttackDarkness.A_LightIntensity, value4);
		if ((object)obj15 == null)
		{
			GhostKingAttackDarkness.A_LightIntensity = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action5 = default(Action<float>);
			bool flag12 = action5 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj15;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_08a6;
			}
			GhostKingAttackDarkness.A_LightIntensity = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj15;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_08b6;
			}
		}
		obj = GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget;
		Action action6 = DarknessAttackStarted;
		Delegate obj17 = Delegate.Remove(GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget, action6);
		if ((object)obj17 == null)
		{
			GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget = null;
		}
		else
		{
			bool flag14 = (object)obj17.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag14)
			{
				obj18 = obj17;
			}
			bool flag15 = (object)obj18 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj17;
			nint num5 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0a21;
			}
			GhostKingAttackDarkness.A_DarknessAttackSetEnemyTarget = (Action)obj18;
			bool flag16 = (object)obj17.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag16)
			{
				obj19 = obj17;
			}
			bool flag17 = (object)obj19 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj17;
			nint num6 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0a31;
			}
		}
		obj = GhostKingAttackDarkness.A_Explode;
		Action action7 = DarknessExplosion;
		Delegate obj20 = Delegate.Remove(GhostKingAttackDarkness.A_Explode, action7);
		if ((object)obj20 == null)
		{
			GhostKingAttackDarkness.A_Explode = null;
		}
		else
		{
			bool flag18 = (object)obj20.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag18)
			{
				obj21 = obj20;
			}
			bool flag19 = (object)obj21 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj20;
			nint num7 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0a41;
			}
			GhostKingAttackDarkness.A_Explode = (Action)obj21;
			bool flag20 = (object)obj20.GetType() != typeof(Action);
			Delegate obj22 = null;
			if (!flag20)
			{
				obj22 = obj20;
			}
			bool flag21 = (object)obj22 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj20;
			nint num8 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0a51;
			}
		}
		Action<Enemy, DamageContainer> value5 = OnEnemyDamage;
		Delegate obj23 = Delegate.Remove(Enemy.A_Damage, value5);
		if ((object)obj23 == null)
		{
			Enemy.A_Damage = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action8 = default(Action<Enemy, DamageContainer>);
		bool flag22 = action8 == null;
		obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj23;
		obj4 = 0;
		obj5 = null;
		if (flag22)
		{
			goto IL_09d6;
		}
		Enemy.A_Damage = action8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj24 = default(object);
		bool flag23 = obj24 == null;
		obj = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj23;
		obj4 = 0;
		obj5 = null;
		if (!flag23)
		{
			return;
		}
		goto IL_09e6;
		IL_0a41:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a31;
		IL_0a31:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a21;
		IL_09f6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0876:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0866;
		IL_0a51:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a41;
		IL_08a6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0886;
		IL_0886:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = (nint)obj;
		obj11 = action2;
		goto IL_0876;
		IL_0a21:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08b6;
		IL_0856:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a11;
		IL_08b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08a6;
		IL_0866:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0856;
		IL_0a11:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a01;
		IL_0a01:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f6;
		IL_09e6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d6;
		IL_09d6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a51;
	}

	private void Start()
	{
	}

	private void LampActivate()
	{
		int num = lampCount + 1;
		lampCount = num;
		RefreshLighting();
		RefreshBossArmor();
	}

	private void LampDeactivate()
	{
		int num = lampCount - 1;
		lampCount = num;
		RefreshLighting();
		RefreshBossArmor();
	}

	private void RefreshBossArmor()
	{
		//IL_0052: Expected O, but got I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00cc: Expected F4, but got I4
		if (!(bossEnemy != null))
		{
			return;
		}
		bool flag = lampCount == 0;
		float newArmor;
		if (!flag)
		{
			object obj = lampCount - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					newArmor = (flag ? 0.6f : (((nint)obj3 == 1) ? 0f : 0.98f));
				}
				else
				{
					newArmor = 0.8f;
				}
			}
			else
			{
				newArmor = 0.95f;
			}
		}
		else
		{
			newArmor = 0.99f;
		}
		BossLamp[] array = lamps;
		int current = array.Length - lampCount;
		bossEnemy.SetArmor(newArmor, current, array.Length);
		int amount = array.Length - lampCount;
		bossShields.SetAmount(amount);
	}

	private unsafe void RefreshLighting()
	{
		//IL_0020: Expected F4, but got I4
		//IL_0061: Invalid comparison between I4 and F4
		//IL_00ac: Expected F4, but got I4
		//IL_01a1: Expected O, but got Ref
		//IL_00c1: Invalid comparison between I4 and F4
		//IL_01b4: Expected O, but got Ref
		BossLamp[] array = lamps;
		int num = lampCount / array.Length;
		currentLightIntensity = num;
		bool flag = !isBossDefeated;
		float num2 = (float)num * lightDropFromLamps;
		float num3 = 1f - lightDropFromLamps;
		float num4 = num2 + num3;
		float num5 = num4 * darknessLightIntensityMultiplier;
		currentLightIntensity = num5;
		if (!flag)
		{
			float num6 = bdLightIntensity * darknessLightIntensityMultiplier;
			currentLightIntensity = num6;
		}
		float intensity = defaultLightIntensity * currentLightIntensity;
		directionalLight.intensity = intensity;
		float num7 = currentLightIntensity;
		if (!(0f > currentLightIntensity))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num8 = default(float);
		RenderSettings.ambientLight = (Color)(&num8);
		if (0f > currentLightIntensity || currentLightIntensity > 1f)
		{
		}
		RenderSettings.fogColor = (Color)(&num8);
	}

	public void Activate()
	{
		//IL_0097: Expected O, but got F4
		//IL_00db: Expected O, but got F4
		//IL_011f: Expected O, but got F4
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		_003CisFightingBoss_003Ek__BackingField = true;
		isPlayerInsideLight = false;
		darknessLightIntensityMultiplier = 1f;
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		defaultLightIntensity = stageData.lightIntensity;
		StageData stageData2 = MapController._003CcurrentStage_003Ek__BackingField;
		defaultAmbientLight = stageData2.ambienceColor;
		MyTime.StartCryptBoss();
		FindNextLavaRise();
		RefreshLighting();
		Vector3 position = risingObjects.position;
		risingObjectsPositionDefault = (Vector3)position.x;
		_ = position.z;
		Vector3 vector = default(Vector3);
		risingObjectsPositionUp = vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+118]");
		_ = 0;
		Vector3 position2 = lava.position;
		lavaPosDefault = (Vector3)position2.x;
		_ = position2.z;
		lavaPosUp = vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+130]");
		_ = 0;
		Vector3 position3 = pillars.position;
		pillarsPosDefault = (Vector3)position3.x;
		_ = position3.z;
		pillarsPosUp = vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+148]");
		_ = 0;
		float num = MyTime.time + 3f;
		spawnBossAtTime = num;
	}

	private void BossFightOver()
	{
		if (isBossDefeated)
		{
			return;
		}
		_003CisFightingBoss_003Ek__BackingField = false;
		bossEnemy = null;
		isBossDefeated = true;
		bossDeadAtTime = MyTime.time;
		InteractableGhostBossLeave instance = (InteractableGhostBossLeave)(object)EnemyManager.Instance;
		if ((object)EnemyManager.Instance != null && (object)((BaseInteractable)instance).outline != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			Dictionary<uint, Enemy>.Enumerator enumerator = default(Dictionary<uint, Enemy>.Enumerator);
			Enemy enemy = default(Enemy);
			while (enumerator.MoveNext())
			{
				if ((object)enemy != null)
				{
					enemy.Kill();
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			bdLightStartIntensity = currentLightIntensity;
			darknessLightIntensityMultiplier = 1f;
			if ((object)interactableGhostBossLeave != null)
			{
				interactableGhostBossLeave.OpenDoor();
				Action<bool> a_BossDefeated = InteractableBossSpawner.A_BossDefeated;
				if (InteractableBossSpawner.A_BossDefeated != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ rax_v25 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PostBossDeadUpdate()
	{
		//IL_0057: Invalid comparison between I4 and F4
		//IL_00a2: Expected F4, but got I4
		//IL_0187: Invalid comparison between I4 and F4
		//IL_00de: Expected F4, but got I4
		if (!isBossDefeated)
		{
			return;
		}
		float num = MyTime.time - bossDeadAtTime;
		if (!(num < bdLightStartFadeDelay) && 1f > bdLightIntensity)
		{
			float num2 = num - bdLightStartFadeDelay;
			float num3 = num2 / bdLightFadeDuration;
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			float num4 = Easing.InOutQuad(num3);
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			float num5 = 1f - bdLightStartIntensity;
			float num6 = num5 * num4;
			float num7 = num6 + bdLightStartIntensity;
			bdLightIntensity = num7;
			RefreshLighting();
		}
		if (!(num < openGateDelay) && !hasOpenedGate)
		{
			hasOpenedGate = true;
			metalGate.Open();
		}
	}

	private void Update()
	{
		//IL_005c: Invalid comparison between I4 and F4
		//IL_00a7: Expected F4, but got I4
		//IL_01b3: Invalid comparison between I4 and F4
		//IL_00e3: Expected F4, but got I4
		float num = timer + MyTime.deltaTime;
		timer = num;
		CheckSpawnBoss();
		UpdateLava();
		UpdateShields();
		if (!isBossDefeated)
		{
			return;
		}
		float num2 = MyTime.time - bossDeadAtTime;
		if (!(num2 < bdLightStartFadeDelay) && 1f > bdLightIntensity)
		{
			float num3 = num2 - bdLightStartFadeDelay;
			float num4 = num3 / bdLightFadeDuration;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			float num5 = Easing.InOutQuad(num4);
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			float num6 = 1f - bdLightStartIntensity;
			float num7 = num6 * num5;
			float num8 = num7 + bdLightStartIntensity;
			bdLightIntensity = num8;
			RefreshLighting();
		}
		if (!(num2 < openGateDelay) && !hasOpenedGate)
		{
			hasOpenedGate = true;
			metalGate.Open();
		}
	}

	private void FixedUpdate()
	{
		//IL_0093: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		if (!isBossDefeated && _003ChasSpawnedBoss_003Ek__BackingField && bossEnemy != null && bossEnemy.IsDead())
		{
			BossFightOver();
		}
		isPlayerInsideLight = false;
		BossLamp[] array = lamps;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < array.Length)
			{
				if (!array[obj].HasPlayer())
				{
					obj++;
					obj2 = obj;
					continue;
				}
				break;
			}
			return;
		}
		isPlayerInsideLight = true;
	}

	private void CheckIfBossDead()
	{
		if (!isBossDefeated && _003ChasSpawnedBoss_003Ek__BackingField && bossEnemy != null && bossEnemy.IsDead())
		{
			BossFightOver();
		}
	}

	private unsafe void UpdateShields()
	{
		//IL_01b8: Expected O, but got Ref
		//IL_01f5: Expected O, but got Ref
		if (!(bossEnemy != null))
		{
			Transform transform = bossShields.transform;
			Transform parent = transform.parent;
			GameObject gameObject = parent.gameObject;
			if (gameObject.activeSelf)
			{
				Transform transform2 = bossShields.transform;
				Transform parent2 = transform2.parent;
				GameObject gameObject2 = parent2.gameObject;
				gameObject2.SetActive(value: false);
			}
			return;
		}
		Transform transform3 = bossShields.transform;
		Transform parent3 = transform3.parent;
		GameObject gameObject3 = parent3.gameObject;
		if (!gameObject3.activeSelf)
		{
			Transform transform4 = bossShields.transform;
			Transform parent4 = transform4.parent;
			GameObject gameObject4 = parent4.gameObject;
			gameObject4.SetActive(value: true);
		}
		Transform transform5 = bossShields.transform;
		Transform parent5 = transform5.parent;
		Vector3 feetPosition = bossEnemy.GetFeetPosition();
		float num = default(float);
		parent5.position = (Vector3)(&num);
		Transform transform6 = bossShields.transform;
		Transform parent6 = transform6.parent;
		parent6.Rotate((Vector3)(&num), 2f);
	}

	private void CheckSpawnBoss()
	{
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		if (!_003ChasSpawnedBoss_003Ek__BackingField && _003CisFightingBoss_003Ek__BackingField && !(MyTime.time < spawnBossAtTime))
		{
			_003ChasSpawnedBoss_003Ek__BackingField = true;
			Vector3 position = bossSpawnTransform.position;
			Vector3 pos = default(Vector3);
			float extraSizeMultiplier = default(float);
			Enemy enemy = EnemyManager.Instance.SpawnBoss(EEnemy.GhostKing, 0, EEnemyFlag.StageBoss, pos, extraSizeMultiplier);
			bossEnemy = enemy;
			RefreshBossArmor();
			BossLamp[] array = lamps;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				Enemy enemy2 = bossEnemy;
				Collider component = array[obj].GetComponent<Collider>();
				Physics.IgnoreCollision(enemy2.collider, component, ignore: true);
				obj++;
				obj2 = obj;
			}
			MusicController.Instance.PlayMusicTrack(musicTrackBoss);
			UiManager instance = UiManager.Instance;
			instance.objective.OnBossSpawned();
		}
	}

	private void OnEnemyReleased(Enemy enemy)
	{
		if (enemy == bossEnemy)
		{
			BossFightOver();
		}
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
		if (!(enemy == bossEnemy))
		{
			return;
		}
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData.enemyName == EEnemy.GhostKing)
		{
			Action a_BossDied = A_BossDied;
			if (A_BossDied != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v75.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void OnLightIntensityChangeFromDarknessAttack(float i)
	{
		if (!isBossDefeated)
		{
			darknessLightIntensityMultiplier = i;
			RefreshLighting();
		}
	}

	private void DarknessAttackStarted()
	{
		bossEnemy.FollowTarget(bossSpawnTransform);
	}

	private void DarknessExplosion()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		BossLamp[] array = lamps;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			if (!array[obj2].HasPlayer())
			{
				array[obj2].Deactivate();
			}
			obj2++;
			obj = obj2;
		}
	}

	public static bool IsDarknessAttack()
	{
		//IL_0034: Invalid comparison between F4 and I4
		bool flag = 1f < darknessLightIntensityMultiplier;
		float num = 1f - darknessLightIntensityMultiplier;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public static float GetDarknessIntensityMultiplier()
	{
		return darknessLightIntensityMultiplier;
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E23]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (dc.damageSource != "Unkown")
		{
			hasUsedDamageOtherThanLamps = true;
		}
	}

	private unsafe void OnDisable()
	{
		//IL_0043: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		if (isBossDefeated && directionalLight != null)
		{
			directionalLight.intensity = defaultLightIntensity;
			Color color = default(Color);
			RenderSettings.ambientLight = (Color)(&color);
			RenderSettings.fogColor = (Color)(&color);
		}
	}

	private void FindNextLavaRise()
	{
		float num = (lavaStartTime = MyTime.time + lavaInterval) + lavaDuration;
		lavaEndTime = num;
	}

	private void UpdateLava()
	{
		//IL_0231: Invalid comparison between I4 and F4
		//IL_053b: Invalid comparison between I4 and F4
		//IL_027c: Expected F4, but got I4
		//IL_011f: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_0586: Expected F4, but got I4
		//IL_088b: Invalid comparison between I4 and F4
		//IL_01bb: Expected O, but got I4
		//IL_0b6b: Invalid comparison between I4 and F4
		//IL_02b8: Expected F4, but got I4
		//IL_05c2: Expected F4, but got I4
		//IL_08d8: Invalid comparison between I4 and F4
		//IL_0bb8: Invalid comparison between I4 and F4
		//IL_02f4: Expected F4, but got I4
		//IL_05fe: Expected F4, but got I4
		//IL_0311: Invalid comparison between I4 and F4
		//IL_061b: Invalid comparison between I4 and F4
		//IL_0364: Expected F4, but got I4
		//IL_0670: Expected F4, but got I4
		//IL_092c: Expected O, but got I
		//IL_0949: Expected O, but got I
		//IL_0bfb: Expected O, but got I
		//IL_0c29: Expected O, but got I
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_03b0: Invalid comparison between I4 and F4
		//IL_06bc: Invalid comparison between I4 and F4
		//IL_0403: Expected F4, but got I4
		//IL_070f: Expected F4, but got I4
		//IL_09e8: Expected O, but got I
		//IL_0a05: Expected O, but got I
		//IL_0cc8: Expected O, but got I
		//IL_0ce5: Expected O, but got I
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_044f: Invalid comparison between I4 and F4
		//IL_075b: Invalid comparison between I4 and F4
		//IL_04a4: Expected F4, but got I4
		//IL_07ae: Expected F4, but got I4
		//IL_0aa4: Expected O, but got I
		//IL_0ac1: Expected O, but got I
		//IL_0d84: Expected O, but got I
		//IL_0da1: Expected O, but got I
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Expected O, but got Unknown
		if (isBossDefeated)
		{
			if (lavaState == ELavaState.Idle)
			{
				return;
			}
			if (lavaState == ELavaState.UpIdle)
			{
				lavaState = ELavaState.Lowering;
				lavaRiseTimer = 0f;
				PlayerCamera instance = PlayerCamera.Instance;
				ShakeInstance shakeInstance = instance.shaker.Shake(rumbleShake, (int?)(object)0);
				sfxRumble.Play();
			}
		}
		if (lavaState == ELavaState.Idle && !(MyTime.time < lavaStartTime))
		{
			lavaState = ELavaState.Rising;
			lavaRiseTimer = 0f;
			PlayerCamera instance2 = PlayerCamera.Instance;
			ShakeInstance shakeInstance2 = instance2.shaker.Shake(rumbleShake, (int?)(object)0);
			sfxRumble.Play();
		}
		if (lavaState == ELavaState.UpIdle && !(MyTime.time < lavaEndTime))
		{
			lavaState = ELavaState.Lowering;
			lavaRiseTimer = 0f;
			PlayerCamera instance3 = PlayerCamera.Instance;
			ShakeInstance shakeInstance3 = instance3.shaker.Shake(rumbleShake, (int?)(object)0);
			sfxRumble.Play();
		}
		object obj4 = default(object);
		if (lavaState == ELavaState.Rising)
		{
			float num = (lavaRiseTimer += MyTime.deltaTime) / lavaRiseTime;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			float num2 = Easing.InOutQuad(num);
			float num3 = lavaRiseTimer - 3f;
			float num4 = num3 / lavaRiseTime;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			float num5 = Easing.InOutQuad(num4);
			float num6 = lavaRiseTimer - 4.5f;
			float num7 = num6 / lavaRiseTime;
			if (!(0f > num7))
			{
				if (num7 > 1f)
				{
					num7 = 1f;
				}
			}
			else
			{
				num7 = 0f;
			}
			float num8 = Easing.InOutQuad(num7);
			Transform transform = risingObjects.transform;
			float num9;
			if (!(0f > num2))
			{
				bool flag = !(num2 > 1f);
				num9 = num2;
				if (!flag)
				{
					num9 = 1f;
				}
			}
			else
			{
				num9 = 0f;
			}
			object obj = risingObjectsPositionUp - risingObjectsPositionDefault;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+120]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+114]");
			object obj2 = num10 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+124]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+118]");
			object obj3 = num11 - 0;
			float num12 = (float)obj * num9;
			float num13 = (float)obj2 * num9;
			float num14 = (float)obj3 * num9;
			float num15 = num12 + (float)risingObjectsPositionDefault;
			float num16 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+114]");
			float num17 = num16 + 0f;
			float num18 = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+118]");
			float num19 = num18 + 0f;
			Vector3 position = (Vector3)(obj4 - 96);
			transform.position = position;
			Transform transform2 = lava.transform;
			float num20;
			if (!(0f > num5))
			{
				bool flag2 = !(num5 > 1f);
				num20 = num5;
				if (!flag2)
				{
					num20 = 1f;
				}
			}
			else
			{
				num20 = 0f;
			}
			object obj5 = lavaPosUp - lavaPosDefault;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+138]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+12C]");
			object obj6 = num21 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+13C]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+130]");
			object obj7 = num22 - 0;
			float num23 = (float)obj5 * num20;
			float num24 = (float)obj6 * num20;
			float num25 = (float)obj7 * num20;
			float num26 = num23 + (float)lavaPosDefault;
			float num27 = num24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+12C]");
			float num28 = num27 + 0f;
			float num29 = num25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+130]");
			float num30 = num29 + 0f;
			Vector3 position2 = (Vector3)(obj4 - 96);
			transform2.position = position2;
			Transform transform3 = pillars.transform;
			float num31 = ((0f > num8) ? 0f : ((num8 > 1f) ? 1f : num8));
			object obj8 = pillarsPosUp - pillarsPosDefault;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+150]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+144]");
			object obj9 = num32 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+154]");
			nint num33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+148]");
			object obj10 = num33 - 0;
			float num34 = (float)obj8 * num31;
			float num35 = (float)obj9 * num31;
			float num36 = (float)obj10 * num31;
			float num37 = num34 + (float)pillarsPosDefault;
			float num38 = num35;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+144]");
			float num39 = num38 + 0f;
			float num40 = num36;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+148]");
			float num41 = num40 + 0f;
			Vector3 position3 = (Vector3)(obj4 - 96);
			transform3.position = position3;
			if (!(num8 < 1f))
			{
				lavaState = ELavaState.UpIdle;
			}
		}
		if (lavaState != ELavaState.Lowering)
		{
			return;
		}
		float num42 = (lavaRiseTimer += MyTime.deltaTime) / lavaRiseTime;
		if (!(0f > num42))
		{
			if (num42 > 1f)
			{
				num42 = 1f;
			}
		}
		else
		{
			num42 = 0f;
		}
		float num43 = Easing.InOutQuad(num42);
		float num44 = lavaRiseTimer - 2f;
		float num45 = num44 / lavaRiseTime;
		if (!(0f > num45))
		{
			if (num45 > 1f)
			{
				num45 = 1f;
			}
		}
		else
		{
			num45 = 0f;
		}
		float num46 = Easing.InOutQuad(num45);
		float num47 = lavaRiseTimer - 3.5f;
		float num48 = num47 / lavaRiseTime;
		if (!(0f > num48))
		{
			if (num48 > 1f)
			{
				num48 = 1f;
			}
		}
		else
		{
			num48 = 0f;
		}
		float num49 = Easing.InOutQuad(num48);
		Transform transform4 = risingObjects.transform;
		float num50 = ((0f > num49) ? 0f : ((num49 > 1f) ? 1f : num49));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+118]");
		nint num51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+124]");
		object obj11 = num51 - 0;
		object obj12 = risingObjectsPositionDefault - risingObjectsPositionUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+114]");
		nint num52 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+120]");
		object obj13 = num52 - 0;
		float num53 = (float)obj11 * num50;
		float num54 = (float)obj12 * num50;
		float num55 = num53;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+124]");
		float num56 = num55 + 0f;
		float num57 = (float)obj13 * num50;
		float num58 = num54 + (float)risingObjectsPositionUp;
		float num59 = num57;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+120]");
		float num60 = num59 + 0f;
		Vector3 position4 = (Vector3)(obj4 - 96);
		transform4.position = position4;
		Transform transform5 = lava.transform;
		float num61;
		if (!(0f > num43))
		{
			bool flag3 = !(num43 > 1f);
			num61 = num43;
			if (!flag3)
			{
				num61 = 1f;
			}
		}
		else
		{
			num61 = 0f;
		}
		object obj14 = lavaPosDefault - lavaPosUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+12C]");
		nint num62 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+138]");
		object obj15 = num62 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+130]");
		nint num63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+13C]");
		object obj16 = num63 - 0;
		float num64 = (float)obj14 * num61;
		float num65 = (float)obj15 * num61;
		float num66 = (float)obj16 * num61;
		float num67 = num64 + (float)lavaPosUp;
		float num68 = num65;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+138]");
		float num69 = num68 + 0f;
		float num70 = num66;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+13C]");
		float num71 = num70 + 0f;
		Vector3 position5 = (Vector3)(obj4 - 96);
		transform5.position = position5;
		Transform transform6 = pillars.transform;
		float num72;
		if (!(0f > num46))
		{
			bool flag4 = !(num46 > 1f);
			num72 = num46;
			if (!flag4)
			{
				num72 = 1f;
			}
		}
		else
		{
			num72 = 0f;
		}
		object obj17 = pillarsPosDefault - pillarsPosUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+144]");
		nint num73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+150]");
		object obj18 = num73 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+148]");
		nint num74 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+154]");
		object obj19 = num74 - 0;
		float num75 = (float)obj17 * num72;
		float num76 = (float)obj18 * num72;
		float num77 = (float)obj19 * num72;
		float num78 = num75 + (float)pillarsPosUp;
		float num79 = num76;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+150]");
		float num80 = num79 + 0f;
		float num81 = num77;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossRoom)+154]");
		float num82 = num81 + 0f;
		Vector3 position6 = (Vector3)(obj4 - 96);
		transform6.position = position6;
		if (!(num49 < 1f))
		{
			lavaState = ELavaState.Idle;
			FindNextLavaRise();
		}
	}
}
