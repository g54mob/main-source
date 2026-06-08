using UnityEngine;

public class EnemyStealsKi : MonoBehaviour
{
	private Character myCharacter;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner == myCharacter)
		{
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, 1L);
			FloatingText floatingText = c.ShowFloatingText("-@1");
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.white;
			}
		}
	}

	private void Awake()
	{
		myCharacter = GetComponent<Character>();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	private void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}
}
