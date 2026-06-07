using System;
using UnityEngine;
using UnityEngine.UI;

public class LightColorButton : MonoBehaviour
{
	[SerializeField]
	private Image _colorImage;

	private Button _button;

	private Color _color;

	public event Action<Color> OnColorSelected;

	private void Start()
	{
		_button = GetComponent<Button>();
		_button.onClick.AddListener(OnClick);
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	public void SetColor(Color color)
	{
		_color = color;
		_colorImage.color = _color;
	}

	private void OnClick()
	{
		this.OnColorSelected?.Invoke(_color);
	}
}
