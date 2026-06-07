using UnityEngine;
using UnityEngine.UI;

public class HelpCustomClick : ActiveComponent
{
	private Color defaultColor;

	private Image image;

	public bool hide;

	private void Start()
	{
		hide = false;
		image = base.gameObject.GetComponent<Image>();
	}

	private void Update()
	{
	}
}
