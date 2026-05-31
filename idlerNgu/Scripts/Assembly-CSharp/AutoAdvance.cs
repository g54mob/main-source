using UnityEngine;
using UnityEngine.UI;

public class AutoAdvance : MonoBehaviour
{
	public Character character;

	public Toggle autoAdvanceToggle;

	public void updateStatus()
	{
		if (character.purchases.hasAutoAdvance)
		{
			autoAdvanceToggle.gameObject.SetActive(value: true);
		}
		else
		{
			autoAdvanceToggle.gameObject.SetActive(value: false);
		}
	}

	public void toggle()
	{
		character.training.autoAdvanceToggle = autoAdvanceToggle.isOn;
	}
}
