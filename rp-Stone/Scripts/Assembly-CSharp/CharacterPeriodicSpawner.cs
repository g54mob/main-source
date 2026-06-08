using UnityEngine;

public class CharacterPeriodicSpawner : MonoBehaviour
{
	public string requiresFlag;

	public string blockedByFlag;

	public string blockedByItem;

	public int initialDelay = 30;

	public int spawnPeriod = 30;

	public IntPosition positionOffset;

	public Character[] fixedSpawns;

	public int randomSpawnCount = -1;

	public Character[] randomSpawns;

	private Character myChar;

	private Enemy myEnemyComponent;

	private int fixedSpawnsMade;

	private int randomSpawnsMade;

	public int elapsedTics { get; private set; }

	private void HandleOnUpdateTic(Character character)
	{
		if (character.Alive && (myEnemyComponent == null || myEnemyComponent.IsAwake()) && elapsedTics++ >= spawnPeriod && TryToSpawn())
		{
			elapsedTics = 0;
		}
	}

	private bool TryToSpawn()
	{
		if ((string.IsNullOrEmpty(requiresFlag) || ProgressFlags.GetFlag(requiresFlag)) && (string.IsNullOrEmpty(blockedByFlag) || !ProgressFlags.GetFlag(blockedByFlag)) && (string.IsNullOrEmpty(blockedByItem) || !Inventory.Singleton.HasItemById(blockedByItem)))
		{
			if (fixedSpawnsMade < fixedSpawns.Length)
			{
				SpawnOne(fixedSpawns[fixedSpawnsMade]);
				fixedSpawnsMade++;
				return true;
			}
			if (randomSpawns.Length != 0 && (randomSpawnCount < 0 || randomSpawnsMade < randomSpawnCount))
			{
				int num = Random.Range(0, randomSpawns.Length);
				SpawnOne(randomSpawns[num]);
				randomSpawnsMade++;
				return true;
			}
		}
		return false;
	}

	private void SpawnOne(Character prefab)
	{
		Character character = Object.Instantiate(prefab);
		character.PositionX = myChar.PositionX + positionOffset.x;
		character.PositionY = myChar.PositionY + positionOffset.y;
		character.PositionZ = myChar.PositionZ + positionOffset.z;
		GameStates.Singleton.level.AddCharacter(character);
		character.SetLevel(myChar.level);
		Enemy enemy = character as Enemy;
		if ((bool)enemy)
		{
			enemy.WakeUp();
		}
	}

	private void Awake()
	{
		elapsedTics = spawnPeriod - initialDelay;
		myChar = GetComponent<Character>();
		myChar.OnUpdateTic += HandleOnUpdateTic;
		myEnemyComponent = GetComponent<Enemy>();
	}

	private void OnDestroy()
	{
		myChar.OnUpdateTic -= HandleOnUpdateTic;
	}
}
