using UnityEngine;
using UnityEngine.UI;

public class ImageColor : ActiveComponent
{
	public string colorKey;

	private void Update()
	{
		if (ActiveComponent.Model != null)
		{
			GetComponent<Image>().color = Logic.GetColor(colorKey);
			Object.Destroy(this);
		}
	}

	private void LateUpdate()
	{
		if (ActiveComponent.Model != null)
		{
			GetComponent<Image>().color = Logic.GetColor(colorKey);
			Object.Destroy(this);
		}
	}
}
