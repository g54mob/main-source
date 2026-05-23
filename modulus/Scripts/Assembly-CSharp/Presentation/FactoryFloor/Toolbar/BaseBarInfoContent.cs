using Data.UI.Controls;
using Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BaseBarInfoContent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		protected BaseEvent _hideBarInfoEvent;

		[Header("Binding")]
		[SerializeField]
		private SettingsRebindRuntimeInfo _settingsRebindRuntimeInfo;

		[SerializeField]
		private InputActionReference _inputAction;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!_button || _button.interactable)
			{
				string bindingString = null;
				bool hasBinding = _settingsRebindRuntimeInfo != null && _settingsRebindRuntimeInfo.TryGetBindingString(_inputAction, out bindingString, getLongVersion: true);
				OnHover(hasBinding, bindingString);
			}
		}

		protected virtual void OnHover(bool hasBinding, string bindingString)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			_hideBarInfoEvent.Fire();
		}
	}
}
