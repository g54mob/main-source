using UnityEngine;

public class CharacterDeathEvent : MonoBehaviour
{
	public GlobalGameplayEvent.Type eventType;

	public string eventParameter;

	public Character.DeathReason[] exceptReasons;

	private Character myChar;

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (!(character == myChar))
		{
			return;
		}
		int num = 0;
		while (exceptReasons != null && num < exceptReasons.Length)
		{
			if (exceptReasons[num] == reason)
			{
				return;
			}
			num++;
		}
		GlobalGameplayEvent.Execute(eventType, eventParameter);
	}

	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
		myChar = GetComponent<Character>();
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}

	public void Parse(string sjson)
	{
		eventType = SlimJson.ParseEnum<GlobalGameplayEvent.Type>(sjson, "eventType");
		eventParameter = SlimJson.Parse(sjson, "eventParameter");
		exceptReasons = SlimJson.ParseEnumArray<Character.DeathReason>(sjson, "exceptReasons");
	}
}
