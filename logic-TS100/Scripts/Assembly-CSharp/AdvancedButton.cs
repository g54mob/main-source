using UnityEngine;
using UnityEngine.UI;

public sealed class AdvancedButton : MonoBehaviour
{
	public Button Button;

	public Text ActiveText;

	public Text InactiveText;

	public bool Interactable
	{
		set
		{
			int num = 4;
			if (-1 == 0)
			{
			}
			Button button = Button;
			int num2 = 5;
			if (7 == 0)
			{
			}
			button.interactable = value;
			int num3 = 1;
			if (7 == 0)
			{
			}
			ActiveText.gameObject.SetActive(value);
			InactiveText.gameObject.SetActive(!value);
		}
	}

	public AdvancedButton()
	{
		int num = 2;
		if (false)
		{
		}
		base._002Ector();
	}
}
