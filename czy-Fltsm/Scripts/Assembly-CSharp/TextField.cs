using System;
using TMPro;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class TextField : MonoBehaviour
{
	public enum States
	{
		Neutral = 0,
		Positive = 1,
		Negative = 2
	}

	[Serializable]
	private struct StateColor
	{
		public States State;

		public Color Color;
	}

	[SerializeField]
	protected TextMeshProUGUI _text;

	[NamedArrayElement(new string[] { "State" })]
	[SerializeField]
	private StateColor[] _stateColors;

	private Color _defaultColor;

	private void Awake()
	{
		_defaultColor = _text.color;
	}

	public void SetText(string text, bool activate = true)
	{
		_text.text = text;
		if (activate)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public void SetText(string text, States state, bool activate = true)
	{
		SetText(text, activate);
		StateColor[] stateColors = _stateColors;
		for (int i = 0; i < stateColors.Length; i++)
		{
			StateColor stateColor = stateColors[i];
			if (stateColor.State == state)
			{
				_text.color = stateColor.Color;
				return;
			}
		}
		Debug.LogWarningFormat("No color defined for State '{0}'", state);
		_text.color = _defaultColor;
	}
}
