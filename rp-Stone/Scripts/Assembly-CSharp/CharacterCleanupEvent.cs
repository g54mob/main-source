using UnityEngine;

public class CharacterCleanupEvent : MonoBehaviour
{
	public GlobalGameplayEvent.Type eventType;

	public string eventParameter;

	private Character myChar;

	private void HandleOnCharacterCleanedUp(Character character)
	{
		if (character == myChar)
		{
			GlobalGameplayEvent.Execute(eventType, eventParameter);
		}
	}

	private void Awake()
	{
		Character.OnCharacterCleanedUp += HandleOnCharacterCleanedUp;
		myChar = GetComponent<Character>();
	}

	private void OnDestroy()
	{
		Character.OnCharacterCleanedUp -= HandleOnCharacterCleanedUp;
	}

	public void Parse(string sjson)
	{
		eventType = SlimJson.ParseEnum<GlobalGameplayEvent.Type>(sjson, "eventType");
		eventParameter = SlimJson.Parse(sjson, "eventParameter");
	}
}
