using UnityEngine;

public class CharacterLifetime : MonoBehaviour
{
	public int ticsLifetime = 60;

	private void UpdateTic(Character character)
	{
		ticsLifetime--;
		if (character.Alive && ticsLifetime <= 0)
		{
			character.Die(Character.DeathReason.LifetimeEnded);
		}
	}

	private void Start()
	{
		Character component = GetComponent<Character>();
		if (component != null)
		{
			component.OnUpdateTic += UpdateTic;
		}
	}

	private void OnDestroy()
	{
		Character component = GetComponent<Character>();
		if (component != null)
		{
			component.OnUpdateTic -= UpdateTic;
		}
	}
}
