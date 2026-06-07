using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ResearchStorageBlade : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Color enabledColor = Color.white;

	[SerializeField]
	private Color disabledColor = Color.white;

	[SerializeField]
	private Material animationMaterial;

	public void SetState(bool state)
	{
		image.color = (state ? enabledColor : disabledColor);
		image.material = (state ? animationMaterial : null);
	}
}
