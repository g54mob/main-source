using Data.FactoryFloor.Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorHoverUIs
{
	public class OperatorStateInfoView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _typeBg;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Color _warningColor;

		[SerializeField]
		private Color _errorColor;

		public void SetStateContent(OperatorStateBehaviour.State state)
		{
			_text.SetText(LocalizationUtility.GetLocalizedText(state.LocalizationKey));
			_typeBg.color = ((state.StateType == OperatorStateBehaviour.StateType.Error) ? _errorColor : _warningColor);
			_icon.sprite = state.Icon;
		}
	}
}
