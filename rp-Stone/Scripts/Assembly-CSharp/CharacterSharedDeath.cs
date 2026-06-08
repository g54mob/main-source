using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterSharedDeath : MonoBehaviour
{
	public string characterIdToShareDeathWith;

	private Character myCharacter;

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character.id == characterIdToShareDeathWith)
		{
			myCharacter.Die(Character.DeathReason.SharedDeath);
		}
	}

	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
		myCharacter = GetComponent<Character>();
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}
}
