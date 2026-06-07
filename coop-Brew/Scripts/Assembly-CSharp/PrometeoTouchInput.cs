using UnityEngine;

public class PrometeoTouchInput : MonoBehaviour
{
	public bool changeScaleOnPressed;

	[HideInInspector]
	public bool buttonPressed;

	private RectTransform rectTransform;

	private Vector3 initialScale;

	private float scaleDownMultiplier;

	private void Start()
	{
	}

	public void ButtonDown()
	{
	}

	public void ButtonUp()
	{
	}
}
