using System;
using System.Globalization;
using CTS.Core;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UIMoneyVFX : CTSBehaviour
	{
		[SerializeField]
		private Color _normalColor = Color.white;

		[SerializeField]
		private Color _addColor = Color.green;

		[SerializeField]
		private Color _removeColor = Color.red;

		[SerializeField]
		private Image _imageToChangecolor;

		[SerializeField]
		private float _normalColorSpeed = 1f;

		[SerializeField]
		private float _changeColorSpeed = 5f;

		[SerializeField]
		private float _addUpdateSpeed;

		[SerializeField]
		private float _clearUpdateSpeed;

		[Inject(false)]
		private TextMeshProUGUI _textRef;

		private int? _currentTarget;

		private int _currentCount;

		private float _currentUpdateSpeed;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			SetText(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
			SaveManager.OnLoadingFinished += GameData_OnLoadingFinished;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
			SaveManager.OnLoadingFinished -= GameData_OnLoadingFinished;
		}

		private void Update()
		{
			if (_currentTarget.HasValue)
			{
				Color color = _imageToChangecolor.color;
				color = Color.Lerp(color, _normalColor, Time.unscaledDeltaTime * _normalColorSpeed);
				if (_currentCount == _currentTarget)
				{
					float num = Math.Abs(0f - _currentUpdateSpeed);
					_currentUpdateSpeed -= Time.unscaledDeltaTime * _clearUpdateSpeed * num;
					_currentUpdateSpeed = Math.Max(0f, _currentUpdateSpeed);
					_imageToChangecolor.color = color;
					return;
				}
				int num2 = Math.Abs(_currentTarget.Value - _currentCount);
				_currentUpdateSpeed += Time.unscaledDeltaTime * _addUpdateSpeed * (float)num2;
				_currentUpdateSpeed = Math.Min(_currentUpdateSpeed, 1E+09f);
				int currentCount = _currentCount;
				_currentCount = MathPlus.AddTowards(_currentCount, (int)Math.Ceiling(_currentUpdateSpeed * Time.unscaledDeltaTime), _currentTarget.Value);
				SetText(_currentCount);
				int num3 = _currentCount - currentCount;
				color = Color.Lerp(color, (num3 < 0) ? _removeColor : _addColor, Time.unscaledDeltaTime * _changeColorSpeed);
				_imageToChangecolor.color = color;
			}
		}

		private void OnMoneyAmountChanged(int amount)
		{
			if (_currentTarget.HasValue)
			{
				_currentTarget = amount;
				return;
			}
			_currentTarget = amount;
			_currentCount = amount;
			SetText(amount);
		}

		private void GameData_OnLoadingFinished()
		{
			_currentTarget = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			_currentCount = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			SetText(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
		}

		private void SetText(int amount)
		{
			if ((bool)_textRef)
			{
				bool flag = amount < 0;
				amount = Math.Abs(amount);
				NumberFormatInfo numberFormatInfo = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
				numberFormatInfo.NumberGroupSeparator = " ";
				string text = amount.ToString("#,0", numberFormatInfo);
				_textRef.text = " " + (flag ? "-" : "") + "$" + text;
			}
		}
	}
}
