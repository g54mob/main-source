using UnityEngine;

[RequireComponent(typeof(StatModifier))]
public class TrackBuffDamageForBalance : MonoBehaviour
{
	private StatModifier myStatMod;

	private int totalDamage;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (myStatMod != null && dmg.Owner == myStatMod.character)
		{
			totalDamage += dmg.amount;
		}
	}

	private void Start()
	{
		myStatMod = GetComponent<StatModifier>();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	private void OnDestroy()
	{
		if (myStatMod != null)
		{
			Utils.LogWarningIfEditor("Damage dealt while had buff '" + myStatMod.id + "' = " + totalDamage);
		}
		myStatMod = null;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}
}
