public class CharacterBurstTreasureById : CharacterBurstSpawner
{
	public string treasureId;

	protected override void DoSpawn()
	{
		if (EvaluateRequiredAndBlocked())
		{
			DoCharacterSpawnTreasureById(GetComponent<Character>(), treasureId, positionOffset);
		}
	}

	private void DoCharacterSpawnTreasureById(Character character, string treasureId, IntPosition positionOffset)
	{
		Data.Treasure treasureWithId = TreasureFactory.singleton.GetTreasureWithId(treasureId);
		if (treasureWithId != null)
		{
			CharacterTreasureSpawner treasureSpawnerForType = TreasureFactory.singleton.GetTreasureSpawnerForType(treasureWithId.type);
			treasureSpawnerForType.itemsInTreasure = treasureWithId.items;
			Character component = treasureSpawnerForType.GetComponent<Character>();
			ItemData.Rarity.Type type = TreasureItem.FindBestRarityInItems(treasureWithId.items);
			if (type != ItemData.Rarity.Type.Common)
			{
				component.colorTint = ItemData.Rarity.GetColorForRarity(type);
			}
			component.PositionX = character.PositionX + positionOffset.x;
			component.PositionY = character.PositionY + positionOffset.y;
			component.PositionZ = character.PositionZ + positionOffset.z;
			AsciiAnimation component2 = component.GetComponent<AsciiAnimation>();
			if (component2 != null)
			{
				component2.Stop();
				component2.Play();
			}
			CopyTravelDataToCharacter(component);
			GameStates.Singleton.level.AddCharacter(component);
			BigHead.treasureTime = 2f;
			HamartiaEventController.singleton.ReportLocationVictory();
		}
		else
		{
			Utils.LogError("Could not find treasure " + treasureId + " to add on character " + character, character.gameObject);
		}
	}
}
