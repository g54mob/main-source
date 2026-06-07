using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class OptionsButtonUGUI : MonoBehaviour
	{
		public delegate void OnValueChangedDelegate(int optionIndex);

		public delegate void OnValueChangedDelegateForText();

		public static string UndefinedText = "-";

		public TextMeshProUGUI TextTf;

		[Tooltip("Loop the options if either of the ends is reached?")]
		public bool Loop = true;

		[SerializeField]
		[Tooltip("If enabled and if this is selected (has focus) then the prev/next action will be triggered by keyboard/controller navigation too.\nNOTICE: This also means it will deny left/right selection navigation away from this is object. Useful for console type UIs.")]
		protected bool _enableButtonControls;

		protected AutoNavigationOverrides _autoNavigationOverrides;

		protected Selectable _selectable;

		public Func<string, string> OptionToTextFunc;

		public UnityEvent<int> OnValueChangedEvent;

		public OnValueChangedDelegate OnValueChanged;

		public UnityEvent OnValueChangedEventForText;

		public OnValueChangedDelegateForText OnValueChangedForText;

		[SerializeField]
		protected List<string> _options = new List<string>();

		protected List<string> _getOptionsCache = new List<string>();

		protected int _value;

		public bool EnableButtonControls
		{
			get
			{
				return _enableButtonControls;
			}
			set
			{
				if (AutoNavigationOverrides != null)
				{
					AutoNavigationOverrides.BlockLeft = EnableButtonControls;
					AutoNavigationOverrides.BlockRight = EnableButtonControls;
				}
			}
		}

		public AutoNavigationOverrides AutoNavigationOverrides
		{
			get
			{
				if (_autoNavigationOverrides == null)
				{
					_autoNavigationOverrides = GetComponent<AutoNavigationOverrides>();
				}
				return _autoNavigationOverrides;
			}
		}

		public Selectable Selectable
		{
			get
			{
				if (_selectable == null)
				{
					_selectable = GetComponent<Selectable>();
				}
				return _selectable;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return _value;
			}
			set
			{
				if (value == _value)
				{
					return;
				}
				if (_options == null || _options.Count == 0)
				{
					_value = 0;
					return;
				}
				_value = value % _options.Count;
				if (_value < 0)
				{
					_value = _options.Count + _value;
				}
				UpdateText();
				OnValueChangedEvent?.Invoke(_value);
				OnValueChanged?.Invoke(_value);
			}
		}

		public int NumOfOptions => _options.Count;

		public void Start()
		{
			EnableButtonControls = _enableButtonControls;
			UpdateText();
		}

		public virtual void Update()
		{
			if (EnableButtonControls && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == Selectable.gameObject)
			{
				if (InputUtils.LeftPressed())
				{
					Prev();
				}
				else if (InputUtils.RightPressed())
				{
					Next();
				}
			}
		}

		public void SetOptions(IList<string> options)
		{
			_options.Clear();
			_options.AddRange(options);
			UpdateText();
		}

		public List<string> GetOptions()
		{
			_getOptionsCache.Clear();
			foreach (string option in _options)
			{
				_getOptionsCache.Add(option);
			}
			return _getOptionsCache;
		}

		public void UpdateText()
		{
			if (_options.Count == 0 || _options.Count >= _value)
			{
				TextTf.text = UndefinedText;
			}
			if (OptionToTextFunc == null)
			{
				TextTf.text = _options[_value];
			}
			else
			{
				TextTf.text = OptionToTextFunc(_options[_value]);
			}
			OnValueChangedEventForText?.Invoke();
			OnValueChangedForText?.Invoke();
		}

		public void ClearOptions()
		{
			_options.Clear();
			UpdateText();
		}

		public void Prev()
		{
			if (_options.Count != 0 && (SelectedIndex != 0 || Loop))
			{
				SelectedIndex--;
			}
		}

		public void Next()
		{
			if (_options.Count != 0 && (SelectedIndex != NumOfOptions - 1 || Loop))
			{
				SelectedIndex++;
			}
		}

		public void SetSelected()
		{
			if (Selectable != null && EventSystem.current != null)
			{
				EventSystem.current.SetSelectedGameObject(Selectable.gameObject);
			}
		}
	}
}
