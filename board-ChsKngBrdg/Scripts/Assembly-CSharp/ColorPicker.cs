using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
	public GlobalColor globalColor;

	public void Awake()
	{
		Color color = globalColor.globalColor;
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		if (component != null)
		{
			component.color = new Color(color.r, color.g, color.b, component.color.a);
		}
		TMP_Text component2 = GetComponent<TMP_Text>();
		if (component2 != null)
		{
			component2.color = new Color(color.r, color.g, color.b, component2.color.a);
		}
		Image component3 = GetComponent<Image>();
		if (component3 != null)
		{
			component3.color = new Color(color.r, color.g, color.b, component3.color.a);
		}
	}
}
