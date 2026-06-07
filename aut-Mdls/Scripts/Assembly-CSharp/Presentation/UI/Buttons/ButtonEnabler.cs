using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Buttons
{
	public class ButtonEnabler : MonoBehaviour
	{
		private const float DefaultAlpha = 1f;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private GameObject _disabledGameObject;

		[SerializeField]
		private GameObject _enabledGameObject;

		[SerializeField]
		private HoverBigButton _hoverBigButton;

		[SerializeField]
		private float _disabledAlpha = 0.3f;

		[SerializeField]
		private bool _startDisabled;

		public Button Button => _button;

		public bool Interactable
		{
			get
			{
				return _button.interactable;
			}
			set
			{
				_button.interactable = value;
				if (_disabledGameObject != null)
				{
					_disabledGameObject.SetActive(!value);
				}
				if (_enabledGameObject != null)
				{
					_enabledGameObject.SetActive(value);
				}
				if (_hoverBigButton != null)
				{
					_hoverBigButton.enabled = value;
				}
				if (_canvasGroup != null)
				{
					_canvasGroup.alpha = (value ? 1f : _disabledAlpha);
				}
			}
		}

		private void Awake()
		{
			if (_button == null)
			{
				_button = GetComponent<Button>();
			}
			if (_startDisabled)
			{
				Interactable = false;
			}
		}
	}
}
