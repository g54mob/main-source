using System;
using UnityEngine;

public class HarvestableResource : MonoBehaviour
{
	public Data.Resource resourceType;

	[NonSerialized]
	public Character character;

	private void Awake()
	{
		character = GetComponent<Character>();
		Character.OnCharacterTookDamage += HandleOnCharacterTookDamage;
		Character.OnCharacterDied += HandleOnCharacterDied;
	}

	private void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleOnCharacterTookDamage;
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}

	private void HandleOnCharacterTookDamage(Character character, Damage dmg)
	{
		if (character == this.character)
		{
			AsciiSprite mySprite = character.MySprite;
			int frameIndex = mySprite.GetFrameIndex();
			frameIndex = Mathf.Min(frameIndex + 1, mySprite.FrameCount - 1);
			mySprite.SetFrameIndex(frameIndex);
		}
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character == this.character && reason == Character.DeathReason.DamageTaken && character.level > 0)
		{
			int num = Mathf.CeilToInt((float)character.level / 5f);
			GameStates.Singleton.level.XpEarned += num;
			GameStates.Singleton.level.EarnMoney(num, character);
		}
	}
}
