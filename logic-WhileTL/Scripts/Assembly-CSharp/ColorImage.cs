using UnityEngine;
using UnityEngine.UI;

public class ColorImage : ActiveComponent
{
	private Image img;

	public string colorKey;

	public string appleColorKey;

	private void Start()
	{
		img = base.gameObject.GetComponent<Image>();
	}

	private void FixedUpdate()
	{
		if (ActiveComponent.Model != null)
		{
			img.color = Logic.GetColor(colorKey);
			Object.Destroy(this);
		}
	}
}
