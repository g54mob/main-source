using UnityEngine;

public class PrometeoTouchInput : MonoBehaviour
{
	public bool changeScaleOnPressed;

	[HideInInspector]
	public bool buttonPressed;

	private RectTransform rectTransform;

	private Vector3 initialScale;

	private float scaleDownMultiplier = 0.85f;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		initialScale = rectTransform.localScale;
	}

	public void ButtonDown()
	{
		buttonPressed = true;
		if (changeScaleOnPressed)
		{
			rectTransform.localScale = initialScale * scaleDownMultiplier;
		}
	}

	public void ButtonUp()
	{
		buttonPressed = false;
		if (changeScaleOnPressed)
		{
			rectTransform.localScale = initialScale;
		}
	}
}
