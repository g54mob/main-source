using UnityEngine;

public class ControlMapping_CategoryLabel : MonoBehaviour
{
	[SerializeField]
	private PugText _nameText;

	[SerializeField]
	private PugText _descriptionText;

	public void Setup(string nameKey, string descriptionKey, int startPadding)
	{
		LinearLayoutUIComponent component = GetComponent<LinearLayoutUIComponent>();
		if ((bool)component)
		{
			component.paddingStart = startPadding;
			component.RenderUIComponent();
		}
		if (nameKey != null)
		{
			_nameText.gameObject.SetActive(value: true);
			_nameText.Render(nameKey);
		}
		else
		{
			_nameText.gameObject.SetActive(value: false);
		}
		if (descriptionKey != null)
		{
			_descriptionText.gameObject.SetActive(value: true);
			_descriptionText.Render(descriptionKey);
		}
		else
		{
			_descriptionText.gameObject.SetActive(value: false);
		}
	}
}
