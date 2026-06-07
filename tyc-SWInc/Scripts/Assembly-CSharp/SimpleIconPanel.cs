using UnityEngine;
using UnityEngine.UI;

public class SimpleIconPanel : MonoBehaviour
{
	public Image Icon;

	public GUIToolTipper Tip;

	public void SetIcon(string tip, string icon, string color)
	{
		Tip.TooltipDescription = tip;
		Icon.sprite = ObjectDatabase.GetIcon(icon);
		Color color2;
		Icon.color = (ColorUtility.TryParseHtmlString(color, out color2) ? color2 : Color.white);
	}
}
