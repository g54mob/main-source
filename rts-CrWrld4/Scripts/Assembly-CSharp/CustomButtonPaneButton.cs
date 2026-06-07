using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonPaneButton : MonoBehaviour
{
	public TextMeshProUGUI buttonText;

	public Image image;

	public CustomButtonPane.ButtonData buttonData;

	public string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public void OnClick()
	{
	}

	public void SetData(CustomButtonPane.ButtonData bd)
	{
	}

	public void Refresh()
	{
	}
}
