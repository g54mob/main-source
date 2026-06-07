using System;
using Presentation.UI.LayoutElements;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Presentation.UI.TechTree
{
	public class FilterToggle : SwitchToggle
	{
		[Serializable]
		public new class SwitchEvent : UnityEvent<bool, Tag>
		{
		}

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Color _textOnColor;

		[SerializeField]
		private Color _textOffColor;

		public SwitchEvent OnFilterChanged = new SwitchEvent();

		private Tag _tag;

		private string _locaKey;

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += SetText;
			if (!string.IsNullOrEmpty(_locaKey))
			{
				SetText();
			}
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= SetText;
		}

		public void SetContent(string locaKey, Tag filterTag)
		{
			_locaKey = locaKey;
			SetText();
			_tag = filterTag;
		}

		private void SetText()
		{
			_text.SetText(LocalizationUtility.GetLocalizedText(_locaKey));
		}

		protected override void InternalToggle()
		{
			base.InternalToggle();
			_text.color = (_isOn ? _textOnColor : _textOffColor);
		}

		protected override void SendCallback()
		{
			OnFilterChanged.Invoke(_isOn, _tag);
		}
	}
}
