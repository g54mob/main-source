using System;
using System.Collections;
using DG.Tweening;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Presentation.UI.LayoutElements
{
	public class TextToggle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler
	{
		[Serializable]
		public class ToggleEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private LayoutElement _mask;

		[SerializeField]
		protected bool _isOn;

		public ToggleEvent OnValueChanged = new ToggleEvent();

		private Vector2 _maskExpandedSize;

		private Vector2 _maskCollapsedSize;

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

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			OnLanguageUpdate();
		}

		private void OnLanguageUpdate()
		{
			StartCoroutine(SetSize());
		}

		private IEnumerator SetSize()
		{
			yield return null;
			_maskExpandedSize = new Vector2(_text.preferredWidth + Mathf.Abs(_text.rectTransform.anchoredPosition.x), _mask.preferredHeight);
			_maskCollapsedSize = new Vector2(0f, _mask.preferredHeight);
			_mask.DOKill();
			_mask.preferredWidth = (_isOn ? _maskExpandedSize.x : _maskCollapsedSize.x);
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			IsOn = !IsOn;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_audioManagerLocator?.AudioManager.PlayButtonHoverSound();
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

		private void InternalToggle()
		{
			_mask.DOKill();
			_mask.DOPreferredSize(_isOn ? _maskExpandedSize : _maskCollapsedSize, 0.2f).SetEase(Ease.InOutSine);
		}

		protected virtual void SendCallback()
		{
			OnValueChanged.Invoke(_isOn);
		}
	}
}
