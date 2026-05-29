using System.Collections.Generic;
using CTS.Core.Utilities;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public abstract class UISettingRoulette<T> : UISetting<T>
	{
		[SerializeField]
		private CTSButton _leftButton;

		[SerializeField]
		private CTSButton _rightButton;

		[SerializeField]
		private TMP_Text _centerText;

		protected readonly List<T> _values = new List<T>();

		protected override void OnAwake()
		{
			base.OnAwake();
			_leftButton.onClick.AddListener(OnLeftButtonClicked);
			_rightButton.onClick.AddListener(OnRightButtonClicked);
			_setting.ValueChanged += OnSettingValueChanged;
		}

		private void OnDestroy()
		{
			_setting.ValueChanged -= OnSettingValueChanged;
		}

		public void AddValue(T value)
		{
			if (!_values.Contains(value))
			{
				_values.Add(value);
			}
		}

		private void OnSettingValueChanged(T obj)
		{
			_centerText.text = ToString(obj);
		}

		private void OnLeftButtonClicked()
		{
			int num = IndexOf(_setting.GetValue());
			if (!num.IsCorrectArrayIndex(_values))
			{
				num = _values.Count;
			}
			num--;
			if (num < 0)
			{
				num = _values.Count - 1;
			}
			_setting.SetValue(_values[num]);
		}

		private void OnRightButtonClicked()
		{
			int num = IndexOf(_setting.GetValue());
			if (!num.IsCorrectArrayIndex(_values))
			{
				num = 0;
			}
			num++;
			if (num >= _values.Count)
			{
				num = 0;
			}
			_setting.SetValue(_values[num]);
		}

		protected abstract string ToString(T obj);

		protected abstract int IndexOf(T obj);
	}
}
