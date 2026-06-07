using UnityEngine;

public class ColorPickerTester : MonoBehaviour
{
	public Renderer renderer;

	public ColorPicker picker;

	public Color Color = Color.red;

	private void Start()
	{
		picker.onValueChanged.AddListener(delegate(Color color)
		{
			renderer.material.color = color;
			Color = color;
		});
		renderer.material.color = picker.CurrentColor;
		picker.CurrentColor = Color;
	}

	private void Update()
	{
	}
}
