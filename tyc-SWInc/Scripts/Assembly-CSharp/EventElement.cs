using UnityEngine;
using UnityEngine.UI;

public class EventElement : MonoBehaviour
{
	private string icon;

	public Image iconImage;

	public Text Description;

	public string Icon
	{
		get
		{
			return icon;
		}
		set
		{
			icon = value;
			iconImage.sprite = ObjectDatabase.GetIcon(icon);
		}
	}
}
