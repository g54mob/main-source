using UnityEngine;

public class AllDefenseTraining : MonoBehaviour
{
	public DefenseTraining[] trains = new DefenseTraining[6];

	public Character character;

	public void Start()
	{
	}

	public void updateMenu()
	{
		for (int i = 0; i < trains.Length; i++)
		{
			trains[i].updateText();
		}
	}

	public void reset()
	{
		for (int i = 0; i < trains.Length; i++)
		{
			trains[i].reset();
		}
	}

	public void refresh()
	{
		updateMenu();
	}

	public void removeAllEnergy()
	{
		for (int i = 0; i < character.training.defenseEnergy.Length; i++)
		{
			long num = character.training.defenseEnergy[i];
			character.training.defenseEnergy[i] -= num;
			character.idleEnergy += num;
		}
	}
}
