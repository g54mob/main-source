using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
	private static TooltipSystem current;

	public Tooltip tooltip;

	public Icontip icontip;

	public Signtip signtip;

	private void Awake()
	{
		current = this;
	}

	public static void Show(string tip)
	{
		current.tooltip.SetInfo(tip);
		current.tooltip.gameObject.SetActive(value: true);
	}

	public static void ShowCrop(string name, int waterings, int harvests, bool improved)
	{
		string text = name + "<br><sprite index=13>" + waterings + "  <sprite index=12>" + harvests;
		if (improved)
		{
			text += "  <sprite index=14>^";
		}
		current.tooltip.SetInfo(text);
		current.tooltip.gameObject.SetActive(value: true);
	}

	public static void Hide()
	{
		current.tooltip.gameObject.SetActive(value: false);
	}

	public static void ShowIcontip(Sprite newSprite)
	{
		current.icontip.ShowWith(newSprite);
	}

	public static void HideIcontip()
	{
		current.icontip.Hide();
	}

	public static void ShowSigntip(Sprite newSprite)
	{
		current.signtip.ShowWith(newSprite);
	}

	public static void HideSigntip()
	{
		current.signtip.Hide();
	}
}
