using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Managers;

public class EnemyManager : MonoBehaviour
{
	public EnemyData testEnemy;

	public Dictionary<uint, Enemy> enemies;

	public Dictionary<Collider, Enemy> collidersToEnemies;

	public Dictionary<GameObject, Enemy> gameobjectsToEnemies;

	private Dictionary<int, int> waveEnemies;

	private uint id;

	public static EnemyManager Instance;

	public bool enabledWaves;

	public SummonerController summonerController;

	private List<Enemy> stageBosses;

	public static Action A_StageBossDied;

	private bool _003CstageBossIsDead_003Ek__BackingField;

	public static int maxNumEnemiesPooled = 700;

	public int numEnemies;

	private float nextDebuffTickTime;

	private float zoomValue;

	private float currentValue;

	private bool started;

	public bool stageBossIsDead
	{
		get
		{
			return _003CstageBossIsDead_003Ek__BackingField;
		}
		private set
		{
			_003CstageBossIsDead_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_007c: Expected I, but got O
		//IL_00ed: Expected I, but got O
		if (!(Instance == null))
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		Action<Enemy> b = RemoveEnemy;
		Delegate obj2 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		if ((object)obj2 == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj2;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		bool flag = action == null;
		nint num = (nint)typeof(Action<Enemy>);
		if (!flag)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj3 = default(object);
			if (obj3 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		SummonerController summonerController = new SummonerController();
		this.summonerController = summonerController;
	}

	private void OnDestroy()
	{
		//IL_0121: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_00b5: Expected I, but got O
		//IL_00c3: Expected I, but got O
		if (!(Instance == this))
		{
			return;
		}
		Action<Enemy> value = RemoveEnemy;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		nint num;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			num = (nint)Enemy.A_EnemyReleasedFromPool;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action = default(Action<Enemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<Enemy>);
				goto IL_015f;
			}
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			num = (nint)typeof(Action<Enemy>);
			num2 = (nint)typeof(Action<Enemy>);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		bool flag2 = summonerController == null;
		num2 = num;
		if (!flag2)
		{
			summonerController.Cleanup();
			return;
		}
		goto IL_015f;
		IL_015f:
		throw new NullReferenceException();
	}

	public unsafe Enemy SpawnEnemy(EnemyData enemyData, int summonerId, bool forceSpawn, EEnemyFlag flag = EEnemyFlag.None, bool useDirectionBias = true)
	{
		//IL_002d: Expected I, but got O
		//IL_0114: Expected I4, but got F4
		//IL_0114: Expected O, but got Ref
		bool useDirectionBias2 = default(bool);
		float num = default(float);
		Vector3 enemySpawnPosition = SpawnPositions.GetEnemySpawnPosition(enemyData, 50, useDirectionBias2, num);
		nint num2 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num3 = 0;
		float num4 = enemySpawnPosition.x - (float)SpawnPositions.INVALID_POS;
		float num5 = enemySpawnPosition.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
		float num6 = num5 - 0f;
		float num7 = enemySpawnPosition.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		float num8 = num7 - 0f;
		float num9 = num6 * num6;
		float num10 = num8 * num8;
		float num11 = num4 * num4;
		float num12 = num9 + num11;
		float num13 = num12 + num10;
		object obj = default(object);
		EEnemyFlag flag2 = default(EEnemyFlag);
		bool canBeElite = default(bool);
		float extraSizeMultiplier = default(float);
		if (!(9.9999994E-11f > num13))
		{
			return SpawnEnemy(enemyData, (Vector3)(&obj), summonerId, (byte)(int)num != 0, flag2, canBeElite, extraSizeMultiplier);
		}
		return null;
	}

	public unsafe Enemy SpawnEnemy(EnemyData enemyData, Vector3 pos, int waveNumber, bool forceSpawn = false, EEnemyFlag flag = EEnemyFlag.None, bool canBeElite = true, float extraSizeMultiplier = 1f)
	{
		//IL_04f6: Expected I, but got O
		//IL_01f6: Expected O, but got Ref
		//IL_02a0: Expected O, but got I
		//IL_0309: Expected O, but got I
		nint num = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num2 = 0;
		float num3 = pos.x - (float)SpawnPositions.INVALID_POS;
		float num4 = pos.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
		float num5 = num4 - 0f;
		float num6 = pos.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		float num7 = num6 - 0f;
		float num8 = num5 * num5;
		float num9 = num3 * num3;
		float num10 = num7 * num7;
		float num11 = num8 + num9;
		float num12 = num11 + num10;
		if (9.9999994E-11f > num12)
		{
			goto IL_04d0;
		}
		object obj = default(object);
		if (obj == null)
		{
			int numMaxEnemies = GetNumMaxEnemies();
			if (numEnemies >= numMaxEnemies)
			{
				goto IL_04d0;
			}
		}
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject;
		if ((object)PoolManager.Instance != null && instance.enemyPool != null)
		{
			gameObject = instance.enemyPool.Get();
			if (!(gameObject != null))
			{
				goto IL_04d0;
			}
			if (gameobjectsToEnemies != null)
			{
				if (gameobjectsToEnemies.ContainsKey(gameObject))
				{
					goto IL_0522;
				}
				if ((object)gameObject != null)
				{
					Enemy component = gameObject.GetComponent<Enemy>();
					if (gameobjectsToEnemies != null)
					{
						((Dictionary<object, object>)(object)gameobjectsToEnemies).Add((object)gameObject, (object)component);
						goto IL_0522;
					}
				}
			}
		}
		goto IL_04da;
		IL_04d0:
		return null;
		IL_0522:
		object value;
		if (gameobjectsToEnemies != null)
		{
			if (!((Dictionary<object, object>)(object)gameobjectsToEnemies).TryGetValue((object)gameObject, out value))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			}
			uint num13 = id + 1;
			id = num13;
			if (value != null)
			{
				object obj2 = default(object);
				int waveNumber2 = default(int);
				EEnemyFlag flag2 = default(EEnemyFlag);
				bool canBeElite2 = default(bool);
				float extraSizeMultiplier2 = default(float);
				((Enemy)value).InitEnemy(id, enemyData, (Vector3)(&obj2), waveNumber2, flag2, canBeElite2, extraSizeMultiplier2);
				if (value != null && enemies != null)
				{
					Dictionary<uint, Enemy> dictionary = enemies;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ stack_18_v4 (System.Object)+88]");
					((Dictionary<uint, object>)(object)dictionary).Add(0u, value);
					if (value != null && collidersToEnemies != null)
					{
						Dictionary<Collider, Enemy> dictionary2 = collidersToEnemies;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ stack_18_v4 (System.Object)+50]");
						if (!dictionary2.ContainsKey((Collider)0))
						{
							if (value == null || collidersToEnemies == null)
							{
								goto IL_04da;
							}
							Dictionary<Collider, Enemy> dictionary3 = collidersToEnemies;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ stack_18_v4 (System.Object)+50]");
							((Dictionary<object, object>)(object)dictionary3).Add((object)0, value);
						}
						if (value != null)
						{
							GameObject key = ((Component)value).gameObject;
							if (gameobjectsToEnemies != null)
							{
								if (gameobjectsToEnemies.ContainsKey(key))
								{
									goto IL_03d9;
								}
								if (value != null)
								{
									GameObject key2 = ((Component)value).gameObject;
									if (gameobjectsToEnemies != null)
									{
										((Dictionary<object, object>)(object)gameobjectsToEnemies).Add((object)key2, value);
										goto IL_03d9;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04da;
		IL_03d9:
		if (waveEnemies != null)
		{
			if (!waveEnemies.ContainsKey(waveNumber))
			{
				if (waveEnemies == null)
				{
					goto IL_04da;
				}
				waveEnemies.Add(waveNumber, 0);
			}
			if (waveEnemies != null)
			{
				int num14 = waveEnemies.get_Item(waveNumber);
				int value2 = num14 + 1;
				waveEnemies.set_Item(waveNumber, value2);
				int num15 = numEnemies + 1;
				numEnemies = num15;
				return (Enemy)value;
			}
		}
		goto IL_04da;
		IL_04da:
		return (Enemy)(object)new NullReferenceException();
	}

	public unsafe Enemy SpawnBoss(EEnemy eEnemy, int summonerId, EEnemyFlag enemyFlag, Vector3 pos, float extraSizeMultiplier = 1f)
	{
		//IL_0039: Expected O, but got Ref
		EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
		object obj = default(object);
		bool forceSpawn = default(bool);
		EEnemyFlag flag = default(EEnemyFlag);
		bool canBeElite = default(bool);
		float extraSizeMultiplier2 = default(float);
		Enemy enemy = SpawnEnemy(enemyData, (Vector3)(&obj), summonerId, forceSpawn, flag, canBeElite, extraSizeMultiplier2);
		if (enemy != null)
		{
			GameManager instance = GameManager.Instance;
			if (instance.bossCurses > 0 && eEnemy != EEnemy.GhostInvincible)
			{
				float num = (float)instance.bossCurses * 0.16f;
				float swarmMultiplierHp = num + 1f;
				enemy.SetSwarmMultiplierHp(swarmMultiplierHp);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			object obj2 = default(object);
			if (obj2 != null)
			{
				List<object> list = (List<object>)(object)stageBosses;
				int version = list._version + 1;
				list._version = version;
				object[] items = list._items;
				if (list._size >= items.Length)
				{
					list.AddWithResize((object)enemy);
					return enemy;
				}
				int size = list._size + 1;
				list._size = size;
				if (list._size >= items.Length)
				{
					return (Enemy)(object)new IndexOutOfRangeException();
				}
				int num2 = default(int);
				items[num2] = enemy;
			}
			return enemy;
		}
		return null;
	}

	public void RemoveEnemy(Enemy enemy)
	{
		bool flag = ((Dictionary<uint, object>)(object)enemies).Remove(enemy._003Cid_003Ek__BackingField);
		int num = numEnemies - 1;
		numEnemies = num;
		if (waveEnemies.ContainsKey(enemy._003CwaveNumber_003Ek__BackingField))
		{
			int num2 = waveEnemies.get_Item(enemy._003CwaveNumber_003Ek__BackingField);
			int value = num2 - 1;
			waveEnemies.set_Item(enemy._003CwaveNumber_003Ek__BackingField, value);
		}
		if (!enemy.IsStageBoss())
		{
			return;
		}
		bool flag2 = ((List<object>)(object)stageBosses).Remove((object)enemy);
		List<Enemy> list = stageBosses;
		if (list._size <= 0)
		{
			List<Enemy> list2 = new List<Enemy>();
			stageBosses = list2;
			_003CstageBossIsDead_003Ek__BackingField = true;
			Action a_StageBossDied = A_StageBossDied;
			if (A_StageBossDied != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v228.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void StageBossDied()
	{
		List<Enemy> list = new List<Enemy>();
		stageBosses = list;
		_003CstageBossIsDead_003Ek__BackingField = true;
		Action a_StageBossDied = A_StageBossDied;
		if (A_StageBossDied != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v58.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public bool CanSpawnEnemy()
	{
		//IL_0019: Expected O, but got I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		int numMaxEnemies = GetNumMaxEnemies();
		object obj = numEnemies - numMaxEnemies;
		int num = numEnemies ^ numMaxEnemies;
		int num2 = numEnemies ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	public bool HasMaxEnemies()
	{
		//IL_0019: Expected O, but got I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		int numMaxEnemies = GetNumMaxEnemies();
		object obj = numEnemies - numMaxEnemies;
		int num = numEnemies ^ numMaxEnemies;
		int num2 = numEnemies ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 == flag;
	}

	public int GetNumMaxEnemies()
	{
		if (this.summonerController != null)
		{
			SummonerController summonerController = this.summonerController;
			if (summonerController.isFinalSwarmStarted)
			{
				bool flag = 120f > MyTime.finalSwarmTimer;
				int result = 400;
				if (!flag)
				{
					result = 300;
				}
				return result;
			}
		}
		return 550;
	}

	public int GetNumEnemies()
	{
		return numEnemies;
	}

	public int GetEnemiesFromSummoner(int wave)
	{
		//IL_007c: Expected I4, but got O
		if (waveEnemies != null)
		{
			if (!waveEnemies.ContainsKey(wave))
			{
				return 0;
			}
			if (waveEnemies != null)
			{
				return waveEnemies.get_Item(wave);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public bool IsFinalSwarm()
	{
		if (this.summonerController != null)
		{
			SummonerController summonerController = this.summonerController;
			return summonerController.isFinalSwarmStarted;
		}
		return false;
	}

	private void Update()
	{
		if (!MyTime.paused && MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				bool flag = MyPlayer.Instance.IsDead();
			}
		}
	}

	private void FixedUpdate()
	{
		//IL_0013: Invalid comparison between I4 and F4
		GameManager instance = GameManager.Instance;
		Enemy enemy = default(Enemy);
		if ((object)GameManager.Instance != null)
		{
			if (!(0f < instance.gameTimer) || MyTime.paused)
			{
				return;
			}
			if (MyTime.time < nextDebuffTickTime)
			{
				goto IL_0203;
			}
			float num = MyTime.time + DebuffUtility.debuffCooldownSeconds;
			nextDebuffTickTime = num;
			if (enemies != null)
			{
				Dictionary<uint, Enemy>.ValueCollection values = enemies.Values;
				if (values != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
					Dictionary<uint, Enemy>.ValueCollection.Enumerator enumerator = default(Dictionary<uint, Enemy>.ValueCollection.Enumerator);
					while (enumerator.MoveNext())
					{
						if ((object)enemy != null)
						{
							enemy.DebuffTick();
							continue;
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					goto IL_0203;
				}
			}
		}
		goto IL_0153;
		IL_0203:
		if (enemies != null)
		{
			Dictionary<uint, Enemy>.ValueCollection values2 = enemies.Values;
			if (values2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
				Dictionary<uint, Enemy>.ValueCollection.Enumerator enumerator2 = default(Dictionary<uint, Enemy>.ValueCollection.Enumerator);
				while (enumerator2.MoveNext())
				{
					if ((object)enemy != null)
					{
						enemy.MyFixedUpdate();
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				if (!enabledWaves)
				{
					return;
				}
				if (summonerController != null)
				{
					summonerController.Tick();
					return;
				}
			}
		}
		goto IL_0153;
		IL_0153:
		throw new NullReferenceException();
	}

	public bool GetEnemy(Collider collider, out Enemy enemy)
	{
		//IL_00d8: Expected I4, but got O
		if (collidersToEnemies != null)
		{
			bool flag = ((Dictionary<object, object>)(object)collidersToEnemies).TryGetValue((object)collider, out System.Runtime.CompilerServices.Unsafe.As<Enemy, object>(ref enemy));
			if (!flag)
			{
				MyLogger.LogErrorInBuild("AAH COLLIDER TO ENEMY FAILED? WTF?");
			}
			bool flag2 = enemy != null;
			bool flag3 = !flag2;
			bool result = flag;
			if (!flag3)
			{
				if ((object)enemy == null)
				{
					goto IL_00ca;
				}
				bool flag4 = enemy.IsDeadOrDyingNextFrame();
				bool flag5 = !flag4;
				result = flag;
				if (!flag5)
				{
					result = false;
				}
			}
			return result;
		}
		goto IL_00ca;
		IL_00ca:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool GetEnemy(GameObject enemyObject, out Enemy enemy)
	{
		//IL_0050: Expected I4, but got O
		if (gameobjectsToEnemies != null)
		{
			bool flag = ((Dictionary<object, object>)(object)gameobjectsToEnemies).TryGetValue((object)enemyObject, out System.Runtime.CompilerServices.Unsafe.As<Enemy, object>(ref enemy));
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				flag = false;
			}
			return flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void TestSpawnEnemy()
	{
	}

	public EnemyManager()
	{
		Dictionary<uint, Enemy> dictionary = new Dictionary<uint, Enemy>();
		enemies = dictionary;
		collidersToEnemies = new Dictionary<Collider, Enemy>();
		gameobjectsToEnemies = new Dictionary<GameObject, Enemy>();
		waveEnemies = new Dictionary<int, int>();
		stageBosses = new List<Enemy>();
		base._002Ector();
	}
}
