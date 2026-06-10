using System;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class GmCustomInputValidator : MonoBehaviour
	{
		[SerializeField]
		private int characterLimit = 18;

		private TMP_InputField inputField;

		private void Start()
		{
			inputField = GetComponent<TMP_InputField>();
			if (!(inputField == null))
			{
				inputField.characterLimit = characterLimit;
				TMP_InputField tMP_InputField = inputField;
				tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, new TMP_InputField.OnValidateInput(OnValidateInput));
			}
		}

		private char OnValidateInput(string text, int pos, char ch)
		{
			if (text.Length > characterLimit || (ch >= '!' && ch <= '/') || (ch >= ':' && ch <= '@') || (ch >= '[' && ch <= '`') || (ch >= '{' && ch <= '~'))
			{
				return '\0';
			}
			text += ch;
			pos++;
			return ch;
		}
	}
}
