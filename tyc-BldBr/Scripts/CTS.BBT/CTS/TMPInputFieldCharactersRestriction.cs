using System.Text.RegularExpressions;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class TMPInputFieldCharactersRestriction : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Default value is '@\"[^a-zA-Z0-9 -]\"'.")]
		private string _authorizedCharacters = "[^a-zA-Z0-9 -]";

		[SerializeField]
		[Inject(false)]
		private TMP_InputField _tmpInputField;

		private void OnDisable()
		{
			if ((bool)_tmpInputField)
			{
				_tmpInputField.onValueChanged.RemoveListener(TMPInputValueChanged);
			}
		}

		private void OnEnable()
		{
			if ((bool)_tmpInputField)
			{
				_tmpInputField.onValueChanged.AddListener(TMPInputValueChanged);
			}
		}

		private void TMPInputValueChanged(string text)
		{
			_tmpInputField.text = Regex.Replace(text, _authorizedCharacters, "");
		}
	}
}
