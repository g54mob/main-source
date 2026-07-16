using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarControllerHull : BarController
{
	public FillBar repairableBar;

	public FillBar mainHealthBar;

	public TextMeshProUGUI healthText;

	[SerializeField]
	private FloatingHullDamageDisplay FloatingText;

	public void UpdateRepairableBarPosition()
	{
		Image component = mainHealthBar.GetComponent<Image>();
		float width = component.rectTransform.rect.width;
		float num = width - width * component.fillAmount;
		repairableBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f - num, 0f);
	}
}
