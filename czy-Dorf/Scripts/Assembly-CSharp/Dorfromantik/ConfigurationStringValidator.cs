using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class ConfigurationStringValidator : MonoBehaviour
	{
		[SerializeField]
		private Color invalidCharColor;

		[SerializeField]
		private TMP_InputField inputFieldToValidate;

		[SerializeField]
		private NumberSystemConverter numberSystemConverter;

		[SerializeField]
		[FormerlySerializedAs("customModeConfiguration")]
		private CustomModeConfiguration configuration;

		private string currentInputFieldValue = "";

		private string modifiedText;

		private bool hasInvalidChars;

		private int targetCaretPosition = -1;

		private int currentSeperatorCount;

		private void Awake()
		{
			targetCaretPosition = -1;
			TMP_InputField tMP_InputField = inputFieldToValidate;
			tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, new TMP_InputField.OnValidateInput(ValidateInput));
			inputFieldToValidate.onEndEdit.AddListener(ValueChanged);
		}

		private void LateUpdate()
		{
			if (targetCaretPosition != -1)
			{
				inputFieldToValidate.caretPosition = targetCaretPosition;
				targetCaretPosition = -1;
				Debug.Log($"set caret position to {inputFieldToValidate.caretPosition}");
			}
		}

		private void ValueChanged(string newInputFieldValue)
		{
			Debug.Log("OnValueChanged " + newInputFieldValue);
			_ = newInputFieldValue.Length;
			_ = currentInputFieldValue.Length;
			_ = newInputFieldValue.Length;
			_ = currentInputFieldValue.Length;
			string text = newInputFieldValue.Replace("-", "");
			string text2 = "";
			string text3 = text;
			for (int i = 0; i < text3.Length; i++)
			{
				char charToValidate = text3[i];
				if (numberSystemConverter.IsEncodedCharValid(charToValidate))
				{
					text2 += charToValidate;
				}
				else if (numberSystemConverter.IsEncodedCharInRange(charToValidate))
				{
					text2 += "0";
				}
			}
			if (text2.Length > configuration.configStringLength)
			{
				text2 = text2.Substring(0, configuration.configStringLength);
			}
			string text4 = text2;
			List<int> list = new List<int>();
			int num;
			for (num = configuration.separatorIndex; num < text2.Length + (text2.Length - 1) / configuration.separatorIndex; num += configuration.separatorIndex)
			{
				text4 = text4.Insert(num, "-");
				list.Add(num);
				num++;
			}
			currentInputFieldValue = text4;
			inputFieldToValidate.SetTextWithoutNotify(currentInputFieldValue);
		}

		private char ValidateInput(string text, int charIndex, char charToValidate)
		{
			if (charToValidate != '-')
			{
				if (!numberSystemConverter.IsEncodedCharInRange(charToValidate))
				{
					charToValidate = '\0';
				}
				else if (!numberSystemConverter.IsEncodedCharValid(charToValidate))
				{
					charToValidate = '0';
				}
			}
			return charToValidate;
		}
	}
}
