using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterTreasureSpawner : MonoBehaviour
{
	public string requiresFlag;

	public string blockedByFlag;

	public string blockedByItem;

	public int ticDelay;

	public IntPosition positionOffset = new IntPosition(4, 0, 0);

	public TreasurePickup pickupPrefab;

	public Data.ItemInTreasure[] itemsInTreasure;

	private Character myChar;

	private bool spawnPending;

	private bool hasSpawned;

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character == myChar)
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

	private void HandleOnCharacterCleanedUp(Character character)
	{
		if (character == myChar)
		{
			TryToSpawn();
		}
	}

	private void HandleOnUpdateTic(Character character)
	{
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
			if ((string.IsNullOrEmpty(requiresFlag) || ProgressFlags.GetFlag(requiresFlag)) && (string.IsNullOrEmpty(blockedByFlag) || !ProgressFlags.GetFlag(blockedByFlag)) && (string.IsNullOrEmpty(blockedByItem) || !Inventory.Singleton.HasItemById(blockedByItem)))
			{
				DoSpawn();
			}
		}
	}

	private void DoSpawn()
	{
		TreasurePickup treasurePickup = Object.Instantiate(pickupPrefab);
		treasurePickup.PositionX = myChar.PositionX + positionOffset.x;
		treasurePickup.PositionY = myChar.PositionY + positionOffset.y;
		treasurePickup.PositionZ = myChar.PositionZ + positionOffset.z;
		treasurePickup.itemsInTreasure = itemsInTreasure;
		treasurePickup.colorTint = myChar.colorTint;
		GameStates.Singleton.level.AddCharacter(treasurePickup);
	}

	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
		Character.OnCharacterCleanedUp += HandleOnCharacterCleanedUp;
		myChar = GetComponent<Character>();
		myChar.OnUpdateTic += HandleOnUpdateTic;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Character.OnCharacterCleanedUp -= HandleOnCharacterCleanedUp;
		myChar.OnUpdateTic -= HandleOnUpdateTic;
	}
}
