using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class CutLineMachineButton : MachineButton
	{
		[SerializeField]
		private Image _border;

		[SerializeField]
		private CanvasGroup _squareLeft;

		[SerializeField]
		private CanvasGroup _squareRight;

		[SerializeField]
		private Color _borderColorNormal;

		[SerializeField]
		private Color _borderColorDisabled;

		[SerializeField]
		private float squareAlphaNormal;

		[SerializeField]
		private float squareAlphaDisabled;

		private bool _isFirstButton;

		public bool IsFirstButton
		{
			get
			{
				return _isFirstButton;
			}
			set
			{
				_isFirstButton = value;
				if (value)
				{
					_squareLeft.alpha = squareAlphaDisabled;
				}
				_squareLeft.gameObject.SetActive(value);
			}
		}

		public bool IsFirstActiveButton
		{
			set
			{
				_squareLeft.alpha = (value ? squareAlphaNormal : squareAlphaDisabled);
				if (!_isFirstButton)
				{
					_squareLeft.gameObject.SetActive(value);
				}
			}
		}

		protected override bool TrySetState(ButtonState newState, bool onInitiation = false)
		{
			if (!base.TrySetState(newState, onInitiation))
			{
				return false;
			}
			_border.color = ((newState == ButtonState.Disabled) ? _borderColorDisabled : _borderColorNormal);
			_squareRight.alpha = ((newState == ButtonState.Disabled) ? squareAlphaDisabled : squareAlphaNormal);
			return true;
		}
	}
}
