using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class HeadStonePickup : MonoBehaviour
{
	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character.gameObject == base.gameObject)
		{
			Data.Quest questData = GameStates.Singleton.level.QuestData;
			HeadStones.RemoveAt(questData.id, questData.level, character.PositionX, character.PositionY);
		}
	}
}
