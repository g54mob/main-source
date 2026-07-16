using TMPro;
using UnityEngine;

public class AddDropShadow : MonoBehaviour
{
	public TMP_Text textComponent;

	private Vector2 shadowOffset = new Vector2(2f, -2f);

	private Color shadowColor = new Color(0f, 0f, 0f, 1f);

	private void Start()
	{
		if (textComponent != null)
		{
			textComponent.fontMaterial.EnableKeyword("UNDERLAY_ON");
			textComponent.fontMaterial.SetColor("_UnderlayColor", shadowColor);
			textComponent.fontMaterial.SetFloat("_UnderlayOffsetX", shadowOffset.x);
			textComponent.fontMaterial.SetFloat("_UnderlayOffsetY", shadowOffset.y);
		}
	}
}
