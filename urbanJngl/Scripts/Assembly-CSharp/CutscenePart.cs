using System;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class CutscenePart
{
	public Image image;

	public TextMeshProUGUI text;

	public void Show()
	{
		if (image != null)
		{
			image.gameObject.SetActive(value: true);
		}
		if (text != null)
		{
			text.gameObject.SetActive(value: true);
		}
	}

	public void Hide()
	{
		if (image != null)
		{
			image.gameObject.SetActive(value: false);
		}
		if (text != null)
		{
			text.gameObject.SetActive(value: false);
		}
	}
}
