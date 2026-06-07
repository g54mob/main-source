using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransitions : MonoBehaviour
{
	[Tooltip("Image to color tint.")]
	[SerializeField]
	private Image _targetImage;

	[Header("Color Tints")]
	[Tooltip("The multiplier for the color when the button is highlighted.")]
	[SerializeField]
	private float _highlight = 0.8f;

	[Tooltip("The multiplier for the color when the button is pressed.")]
	[SerializeField]
	private float _pressed = 0.6f;

	private Color _defaultColor;

	private bool _setNormalColor;

	private void Start()
	{
		if (_targetImage == null)
		{
			Debugger.Warning($"No target image has been set for button {this}");
		}
	}

	private void OnEnable()
	{
		if (!_setNormalColor)
		{
			_defaultColor = _targetImage.color;
			_setNormalColor = true;
		}
		Normal();
	}

	public void Normal()
	{
		_targetImage.color = _defaultColor;
	}

	public void Highlight()
	{
		_targetImage.color = new Color(_defaultColor.r * _highlight, _defaultColor.g * _highlight, _defaultColor.b * _highlight);
	}

	public void Pressed()
	{
		_targetImage.color = new Color(_defaultColor.r * _pressed, _defaultColor.g * _pressed, _defaultColor.b * _pressed);
	}
}
