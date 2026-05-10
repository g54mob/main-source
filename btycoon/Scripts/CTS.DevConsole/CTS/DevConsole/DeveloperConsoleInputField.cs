using TMPro;
using UnityEngine;

namespace CTS.DevConsole
{
	public class DeveloperConsoleInputField : MonoBehaviour
	{
		private TMP_InputField _inputField;

		private DeveloperConsole _console;

		private void Awake()
		{
			_inputField = GetComponent<TMP_InputField>();
			_console = GetComponentInParent<DeveloperConsole>();
		}

		private void OnEnable()
		{
			Register();
		}

		private void OnDisable()
		{
			Unregister();
		}

		private void Register()
		{
			_inputField.onSubmit.AddListener(OnSubmit);
		}

		private void Unregister()
		{
			_inputField.onSubmit.RemoveListener(OnSubmit);
		}

		private void OnSubmit(string p_text)
		{
			if (!(p_text == ""))
			{
				DeveloperConsole.NewLine();
				DeveloperConsole.Log(p_text);
				_inputField.text = "";
				_console.ProcessCommand(p_text.TrimEnd());
				_inputField.Select();
				_inputField.ActivateInputField();
			}
		}
	}
}
