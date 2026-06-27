using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_NumberInputField : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField inputField;

		[Min(1f)]
		[SerializeField]
		private int maxValue = 99;

		[Min(1f)]
		[SerializeField]
		private int maxDigits = 2;

		private readonly Regex digitsOnly = new Regex("\\D+");

		public event Action<int> OnValueChanged;

		private void OnEnable()
		{
			inputField.onValueChanged.AddListener(ValidateInputValue);
		}

		private void OnDisable()
		{
			inputField.onValueChanged.RemoveListener(ValidateInputValue);
		}

		public int ValidateAddApplyCountValue(int count)
		{
			int result = Mathf.Clamp(count, 0, maxValue);
			inputField.SetTextWithoutNotify(result.ToString());
			return result;
		}

		private void ValidateInputValue(string raw)
		{
			if (string.IsNullOrEmpty(raw))
			{
				SetInputValue(0);
				return;
			}
			string text = digitsOnly.Replace(raw, string.Empty);
			text = text.TrimStart('0');
			int result;
			if (text.Length == 0)
			{
				SetInputValue(0);
			}
			else if (text.Length > maxDigits)
			{
				SetInputValue(maxValue);
			}
			else if (!int.TryParse(text, out result))
			{
				SetInputValue(0);
			}
			else
			{
				SetInputValue(result);
			}
		}

		private void SetInputValue(int input)
		{
			int obj = Mathf.Clamp(input, 0, maxValue);
			inputField.SetTextWithoutNotify(obj.ToString());
			this.OnValueChanged?.Invoke(obj);
		}
	}
}
