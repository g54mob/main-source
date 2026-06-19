using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class SandboxDependencyEntry : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Transform _buttonTransform;

		[SerializeField]
		private Localize _buttonText;

		private Action _buttonAction;

		private void Awake()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		public void Setup(string text, string tooltipTerm = null, Color? colour = null, Action buttonAction = null, string overrideButtonText = null)
		{
			_text.text = text;
			if (tooltipTerm != null)
			{
				_tooltip.TooltipTerm = tooltipTerm;
			}
			if (colour.HasValue)
			{
				_text.color = colour.Value;
			}
			_buttonTransform.gameObject.SetActive(buttonAction != null);
			_buttonAction = buttonAction;
			if (!string.IsNullOrEmpty(overrideButtonText))
			{
				_buttonText.Term = overrideButtonText;
			}
		}

		private void OnButtonPressed()
		{
			_buttonAction?.Invoke();
		}
	}
}
