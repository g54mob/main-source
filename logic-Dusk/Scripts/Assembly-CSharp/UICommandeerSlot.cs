using UnityEngine;
using UnityEngine.UI;

public class UICommandeerSlot : MonoBehaviour
{
	public Image borderImage;

	public Image iconImage;

	public Image iconBorderImage;

	public Text label;

	private void Awake()
	{
		label.text = "------";
		iconImage.enabled = false;
	}

	public void SetIsPermanent()
	{
		borderImage.enabled = false;
		iconBorderImage.enabled = false;
		iconImage.color = Color.gray;
	}

	public void SetFilled(string name, Color color)
	{
		if (!string.IsNullOrEmpty(name))
		{
			label.text = name;
		}
		else
		{
			label.text = "-----";
		}
		label.color = color;
		iconImage.enabled = true;
	}

	public void SetBorderColor(Color color)
	{
		borderImage.color = color;
	}
}
