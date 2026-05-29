using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class MainMenuButton : Button
	{
		[SerializeField]
		private TextMeshProUGUI _buttonText;

		private bool _isPointerDown;

		private Button _thisbutton;

		private StandaloneInputModule _inputModule;

		[field: SerializeField]
		public Image Icon { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			_inputModule = Object.FindObjectOfType<StandaloneInputModule>();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			if (base.IsInteractable())
			{
				base.OnDeselect(eventData);
				if (_inputModule != null && _inputModule.inputOverride != null)
				{
					_buttonText.color = Color.white;
					ChangeIconColor(_buttonText.color);
				}
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.IsInteractable())
			{
				base.OnPointerEnter(eventData);
				_buttonText.color = Color.black;
				ChangeIconColor(_buttonText.color);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.IsInteractable())
			{
				return;
			}
			base.OnPointerExit(eventData);
			if (base.currentSelectionState != SelectionState.Selected)
			{
				EventSystem.current.SetSelectedGameObject(null);
				if (!_isPointerDown)
				{
					_buttonText.color = Color.white;
					ChangeIconColor(_buttonText.color);
				}
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (base.IsInteractable())
			{
				base.OnPointerClick(eventData);
				base.InstantClearState();
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (base.IsInteractable() && eventData.button == PointerEventData.InputButton.Left)
			{
				base.OnPointerDown(eventData);
				_buttonText.color = Color.black;
				ChangeIconColor(_buttonText.color);
				_isPointerDown = true;
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			if (base.IsInteractable() && eventData.button == PointerEventData.InputButton.Left)
			{
				base.OnPointerUp(eventData);
				_buttonText.color = Color.white;
				ChangeIconColor(_buttonText.color);
				if (_isPointerDown)
				{
					_isPointerDown = false;
				}
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			if (base.IsInteractable())
			{
				base.OnSelect(eventData);
				_buttonText.color = Color.black;
				ChangeIconColor(_buttonText.color);
			}
		}

		private void ChangeIconColor(Color Color)
		{
			if (Icon != null)
			{
				Icon.color = Color;
			}
		}

		public override bool IsInteractable()
		{
			if (base.IsInteractable())
			{
				_buttonText.color = Color.white;
				ChangeIconColor(_buttonText.color);
			}
			else
			{
				_buttonText.color = Color.grey;
				ChangeIconColor(_buttonText.color);
			}
			return base.IsInteractable();
		}
	}
}
