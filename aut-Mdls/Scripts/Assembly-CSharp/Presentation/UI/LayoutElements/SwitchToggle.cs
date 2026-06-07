using System;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Presentation.UI.LayoutElements
{
	public class SwitchToggle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler
	{
		[Serializable]
		public class SwitchEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		public SwitchEvent OnValueChanged = new SwitchEvent();

		[SerializeField]
		private GameObject _switchOff;

		[SerializeField]
		private GameObject _switchOn;

		[SerializeField]
		protected bool _isOn;

		public bool IsOn
		{
			get
			{
				return _isOn;
			}
			set
			{
				Set(value);
			}
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			IsOn = !IsOn;
		}

		protected virtual void InternalToggle()
		{
			_switchOn.SetActive(_isOn);
			_switchOff.SetActive(!_isOn);
		}

		public void SetIsOnWithoutNotify(bool value)
		{
			Set(value, sendCallback: false);
		}

		private void Set(bool value, bool sendCallback = true)
		{
			_isOn = value;
			InternalToggle();
			if (sendCallback)
			{
				SendCallback();
				_audioManagerLocator?.AudioManager.PlayButtonSound();
			}
		}

		protected virtual void SendCallback()
		{
			OnValueChanged.Invoke(_isOn);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
		}
	}
}
