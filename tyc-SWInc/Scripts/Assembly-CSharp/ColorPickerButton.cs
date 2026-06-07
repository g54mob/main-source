using UnityEngine;
using UnityEngine.UI;

public class ColorPickerButton : MonoBehaviour
{
	public Button button;

	public Image ColorRect;

	public Text Label;

	public Button.ButtonClickedEvent OnClick
	{
		get
		{
			return button.onClick;
		}
	}
}
