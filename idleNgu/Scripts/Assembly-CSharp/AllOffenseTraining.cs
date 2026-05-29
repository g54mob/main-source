using UnityEngine;
using UnityEngine.UI;

public class AllOffenseTraining : MonoBehaviour
{
	public OffenseTraining[] trains = new OffenseTraining[6];

	public Character character;

	public Toggle autoAdvance;

	public AutoAdvance autoAdvanceController;

	public void Start()
	{
		InvokeRepeating("toggleColour", 0f, 0.1f);
	}

	public void updateMenu()
	{
		for (int i = 0; i < trains.Length; i++)
		{
			trains[i].updateText();
		}
		autoAdvanceController.updateStatus();
	}

	public void reset()
	{
		for (int i = 0; i < trains.Length; i++)
		{
			trains[i].reset();
		}
	}

	public void toggleColour()
	{
		if (!autoAdvance.isOn)
		{
			autoAdvance.graphic.color = Color.clear;
		}
		if (autoAdvance.isOn)
		{
			autoAdvance.graphic.color = Color.black;
		}
	}

	public void refresh()
	{
		updateMenu();
	}

	public void removeAllEnergy()
	{
		for (int i = 0; i < character.training.attackEnergy.Length; i++)
		{
			long num = character.training.attackEnergy[i];
			character.training.attackEnergy[i] -= num;
			character.idleEnergy += num;
		}
	}
}
