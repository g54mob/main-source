using UnityEngine;

public class CharacterBurstSpawner : MonoBehaviour
{
	public enum LifecycleEvent
	{
		Added = 0,
		Died = 1,
		CleanedUp = 2,
		HitpointsHalf = 3,
		WokeUp = 4
	}

	public string requiresFlag;

	public string blockedByFlag;

	public string requiresItem;

	public string blockedByItem;

	public LifecycleEvent lifecycleEvent = LifecycleEvent.Died;

	public Character.DeathReason[] exceptDeathReasons;

	public int ticDelay;

	public IntPosition positionOffset;

	public IntPosition randomSpread;

	public int travelTics;

	public float travelX;

	public Character[] fixedSpawns;

	public string[] fixedSpawnPaths;

	public int randomCount;

	public Character[] randomSpawns;

	private Character myChar;

	private bool spawnPending;

	private bool hasSpawned;

	private int lastHitpoints = -1;

	private Enemy myEnemyComponent;

	private Enemy.State lastEnemyComponentState;

	private void HandleOnAddedToLevel(Character character)
	{
		if (lifecycleEvent == LifecycleEvent.Added)
		{
			if (ticDelay > 0)
			{
				spawnPending = true;
			}
			else
			{
				TryToSpawn();
			}
		}
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (lifecycleEvent != LifecycleEvent.Died || !(character == myChar))
		{
			return;
		}
		int num = 0;
		while (exceptDeathReasons != null && num < exceptDeathReasons.Length)
		{
			if (exceptDeathReasons[num] == reason)
			{
				return;
			}
			num++;
		}
		if (ticDelay > 0)
		{
			spawnPending = true;
		}
		else
		{
			TryToSpawn();
		}
	}

	private void HandleOnCharacterCleanedUp(Character character)
	{
		if (character == myChar && (spawnPending || lifecycleEvent == LifecycleEvent.CleanedUp))
		{
			TryToSpawn();
		}
	}

	private void HandleOnUpdateTic(Character character)
	{
		if (lifecycleEvent == LifecycleEvent.HitpointsHalf)
		{
			int num = character.MaxHitpoints / 2;
			if (lastHitpoints > num && character.Hitpoints <= num)
			{
				TryToSpawn();
			}
			lastHitpoints = character.Hitpoints;
		}
		else if (lifecycleEvent == LifecycleEvent.WokeUp && myEnemyComponent != null && lastEnemyComponentState != Enemy.State.WakingUp && myEnemyComponent.CurrentState == Enemy.State.WakingUp)
		{
			lastEnemyComponentState = Enemy.State.WakingUp;
			spawnPending = true;
		}
		if (spawnPending && !hasSpawned && ticDelay-- <= 0)
		{
			spawnPending = false;
			TryToSpawn();
		}
	}

	private void TryToSpawn()
	{
		if (!hasSpawned)
		{
			hasSpawned = true;
			DoSpawn();
		}
	}

	protected virtual void DoSpawn()
	{
		if (!EvaluateRequiredAndBlocked())
		{
			return;
		}
		if (fixedSpawns != null && fixedSpawns.Length != 0)
		{
			for (int i = 0; i < fixedSpawns.Length; i++)
			{
				SpawnOne(fixedSpawns[i]);
			}
		}
		if (fixedSpawnPaths != null && fixedSpawnPaths.Length != 0)
		{
			for (int j = 0; j < fixedSpawnPaths.Length; j++)
			{
				Character component = Utils.LoadPrefab(fixedSpawnPaths[j]).GetComponent<Character>();
				SpawnOne(component);
			}
		}
		if (randomSpawns != null && randomSpawns.Length != 0)
		{
			for (int k = 0; k < randomCount; k++)
			{
				int num = Random.Range(0, randomSpawns.Length);
				SpawnOne(randomSpawns[num]);
			}
		}
	}

	protected bool EvaluateRequiredAndBlocked()
	{
		if (ProgressFlags.EvaluateRequiredAndBlockedBy(requiresFlag, blockedByFlag))
		{
			return Inventory.Singleton.EvaluateRequiredAndBlockedBy(requiresItem, blockedByItem);
		}
		return false;
	}

	protected void SpawnOne(Character prefab)
	{
		if (prefab == null)
		{
			Utils.LogError("Prefab is null. Cannot spawn.", base.gameObject);
			return;
		}
		Character character = Object.Instantiate(prefab);
		character.PositionX = myChar.PositionX + positionOffset.x;
		character.PositionY = myChar.PositionY + positionOffset.y;
		character.PositionZ = myChar.PositionZ + positionOffset.z;
		if (randomSpread != null)
		{
			character.PositionX += Random.Range(-randomSpread.x, randomSpread.x);
			character.PositionY += Random.Range(-randomSpread.y, randomSpread.y);
			character.PositionZ += Random.Range(-randomSpread.z, randomSpread.z);
		}
		AsciiAnimation component = character.GetComponent<AsciiAnimation>();
		if (component != null)
		{
			component.Stop();
			component.Play();
		}
		CopyTravelDataToCharacter(character);
		GameStates.Singleton.level.AddCharacter(character);
		character.SetLevel(myChar.level);
	}

	protected void CopyTravelDataToCharacter(Character c)
	{
		if (travelTics > 0 && c is Decoration)
		{
			DecorationTravelComponent decorationTravelComponent = c.gameObject.AddComponent<DecorationTravelComponent>();
			decorationTravelComponent.durationTics = travelTics;
			decorationTravelComponent.velocityX = travelX;
		}
	}

	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
		Character.OnCharacterCleanedUp += HandleOnCharacterCleanedUp;
		myChar = GetComponent<Character>();
		myChar.OnUpdateTic += HandleOnUpdateTic;
		myChar.OnAddedToLevel += HandleOnAddedToLevel;
		myEnemyComponent = GetComponent<Enemy>();
		if (fixedSpawnPaths != null)
		{
			for (int i = 0; i < fixedSpawnPaths.Length; i++)
			{
				Utils.PreloadAsyncPrefab(fixedSpawnPaths[i]);
			}
		}
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Character.OnCharacterCleanedUp -= HandleOnCharacterCleanedUp;
		myChar.OnUpdateTic -= HandleOnUpdateTic;
		myChar.OnAddedToLevel -= HandleOnAddedToLevel;
	}
}
