using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS.UI
{
	public class FilterButton : MonoBehaviour
	{
		public Action<bool, int> OnToggleChanged;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private bool _updateIconColor = true;

		[SerializeField]
		private PaletteData _iconDisableColor;

		[SerializeField]
		private PaletteData _iconEnableColor;

		[SerializeField]
		private float _iconResizeOnPressed = 0.95f;

		private ToolTipsShower _toolTips;

		private Toggle _toggle;

		private Toggle Toggle
		{
			get
			{
				if (_toggle == null)
				{
					_toggle = GetComponent<Toggle>();
				}
				return _toggle;
			}
		}

		public bool IsOn
		{
			get
			{
				return Toggle.isOn;
			}
			set
			{
				Toggle.isOn = value;
			}
		}

		public int ToggleValue { get; private set; }

		public bool HaveText => _text != null;

		public bool HaveIcon => _icon != null;

		public bool HaveTooltip => _toolTips != null;

		private void Awake()
		{
			_toggle = GetComponent<Toggle>();
			_toolTips = GetComponent<ToolTipsShower>();
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
			Toggle.onValueChanged.AddListener(OnPressed);
		}

		private void OnDisable()
		{
			Toggle.onValueChanged.RemoveListener(OnPressed);
		}

		public void SetButtoninfo(Sprite icon, string text, int value)
		{
			if (_icon != null)
			{
				_icon.sprite = icon;
			}
			if (_text != null)
			{
				_text.text = text;
			}
			ToggleValue = value;
		}

		public void SetButtoninfo(Sprite icon, int value)
		{
			if (_icon != null)
			{
				_icon.sprite = icon;
			}
			ToggleValue = value;
		}

		public void SetButtoninfo(string text, int value)
		{
			if (_text != null)
			{
				_text.text = text;
			}
			ToggleValue = value;
		}

		public void SetTooltipsData(LocalizedString title, LocalizedString text)
		{
			_toolTips?.SetTootipsInfo(title, text);
		}

		public void SetToggled(bool toggled)
		{
			Toggle.isOn = toggled;
		}

		public void SetToggleGroup(ToggleGroup group)
		{
			Toggle.group = group;
		}

		private void OnPressed(bool on)
		{
			if (_icon != null && _updateIconColor)
			{
				_icon.transform.localScale = Vector3.one * (on ? _iconResizeOnPressed : 1f);
				_icon.color = (on ? BBTPalette.GetColor(_iconDisableColor) : BBTPalette.GetColor(_iconEnableColor));
			}
			OnToggleChanged?.Invoke(on, ToggleValue);
		}
	}
}
