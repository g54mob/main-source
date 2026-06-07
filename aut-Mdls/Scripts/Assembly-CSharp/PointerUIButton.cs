using System;
using UnityEngine;
using UnityEngine.UI;

public class PointerUIButton : MonoBehaviour
{
	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _colourImage;

	private Action<int> _action;

	private int _buttonIndex;

	public void Awake()
	{
		_button.onClick.AddListener(OnButtonClicked);
	}

	public void OnDestroy()
	{
		_button.onClick.RemoveListener(OnButtonClicked);
	}

	public void Register(Action<int> action, int buttonIndex, Color colour)
	{
		_action = action;
		_buttonIndex = buttonIndex;
		_colourImage.color = colour;
	}

	public void Unregister()
	{
		_action = null;
	}

	private void OnButtonClicked()
	{
		if (_action != null)
		{
			_action(_buttonIndex);
		}
	}
}
