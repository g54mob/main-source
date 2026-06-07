using UnityEngine.UI;

public class GlowShop : ActiveComponent
{
	private Image image;

	private void Start()
	{
		image = base.gameObject.GetComponent<Image>();
	}

	private void Update()
	{
		_ = ActiveComponent.Model;
	}
}
