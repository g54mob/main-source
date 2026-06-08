using UnityEngine;
using UnityEngine.UI;

public class UIMultiObjectStateToggle : MonoBehaviour
{
	public Image[] imageArray;

	public UIModTextLabel[] labelArray;

	private void OnDestroy()
	{
		if (imageArray != null)
		{
			int num = imageArray.Length;
			for (int i = 0; i < num; i++)
			{
				imageArray[i] = null;
			}
			imageArray = null;
		}
	}

	public void SetActive()
	{
		if (imageArray != null)
		{
			Image[] array = imageArray;
			foreach (Image image in array)
			{
				if (image != null)
				{
					image.color = ModificationUI.Instance.selectedBorderColor;
				}
			}
		}
		if (labelArray == null)
		{
			return;
		}
		UIModTextLabel[] array2 = labelArray;
		foreach (UIModTextLabel uIModTextLabel in array2)
		{
			if (uIModTextLabel != null)
			{
				uIModTextLabel.SetActive();
			}
		}
	}

	public void SetInactive()
	{
		if (imageArray != null)
		{
			Image[] array = imageArray;
			foreach (Image image in array)
			{
				if (image != null)
				{
					image.color = ModificationUI.Instance.deSelectedBorderColor;
				}
			}
		}
		if (labelArray == null)
		{
			return;
		}
		UIModTextLabel[] array2 = labelArray;
		foreach (UIModTextLabel uIModTextLabel in array2)
		{
			if (uIModTextLabel != null)
			{
				uIModTextLabel.SetInactive();
			}
		}
	}
}
