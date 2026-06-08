using UnityEngine;

public class EventObjectiveCollectVigorRuneDrop : EventObjectiveBase
{
	private string dropPath;

	public EventObjectiveCollectVigorRuneDrop(int goal, string itemName)
		: base("enemy_drop_vigor_rune", goal)
	{
		dropPath = "Quests/vigor_rune_drop";
		description = string.Format(Te.xt("tid_q_basic_collect_resource"), TranslateIfTID(itemName));
	}

	public override void Init()
	{
		Inventory.Singleton.OnItemGained += HandleItemGained;
		Character.OnCharacterCreated += HandleCharacterCreated;
		Utils.PreloadAsyncPrefab(dropPath);
	}

	public override void End()
	{
		Inventory.Singleton.OnItemGained -= HandleItemGained;
		Character.OnCharacterCreated -= HandleCharacterCreated;
	}

	private void HandleCharacterCreated(Character newChar)
	{
		if (!(newChar is Enemy) || newChar.tags == null || newChar.tags.Contains("boss"))
		{
			return;
		}
		GameObject gameObject = Utils.LoadPrefab(dropPath);
		if (gameObject != null)
		{
			Character component = gameObject.GetComponent<Character>();
			if (component != null)
			{
				CharacterBurstSpawner characterBurstSpawner = newChar.gameObject.AddComponent<CharacterBurstSpawner>();
				characterBurstSpawner.fixedSpawns = new Character[1] { component };
				characterBurstSpawner.positionOffset = new IntPosition(0, 0, 0);
			}
		}
	}

	private void HandleItemGained(Item item, int amount)
	{
		if (item.element == ItemData.Element.Vigor && item.id == "runestone")
		{
			AddProgress(amount);
		}
	}
}
