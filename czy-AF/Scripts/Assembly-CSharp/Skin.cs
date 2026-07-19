using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
	public enum Style
	{
		Default = 0,
		Light = 1,
		Alternative = 2
	}

	public Style style;

	[Header("Settings")]
	public Color color;

	public Sprite image;

	public void SetSkin(Style s)
	{
		if (style != s)
		{
			return;
		}
		if ((bool)GetComponent<Image>())
		{
			GetComponent<Image>().color = color;
			if (image != null)
			{
				GetComponent<Image>().sprite = image;
			}
		}
		if ((bool)GetComponent<Text>())
		{
			GetComponent<Text>().color = color;
		}
	}
}
