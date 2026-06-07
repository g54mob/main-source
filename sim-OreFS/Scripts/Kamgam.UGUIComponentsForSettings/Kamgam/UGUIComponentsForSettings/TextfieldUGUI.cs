using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Kamgam.UGUIComponentsForSettings
{
	public class TextfieldUGUI : MonoBehaviour
	{
		public delegate void OnTextChangedDelegate(string text);

		public TMP_InputField InputTf;

		public UnityEvent<string> OnTextChangedEvent;

		public OnTextChangedDelegate OnTextChanged;

		public string Text
		{
			get
			{
				return InputTf.text;
			}
			set
			{
				if (!(value == InputTf.text))
				{
					InputTf.text = value;
					OnTextChangedEvent?.Invoke(InputTf.text);
					OnTextChanged?.Invoke(InputTf.text);
				}
			}
		}

		public void Start()
		{
			InputTf.onValueChanged.AddListener(onTextChanged);
		}

		private void onTextChanged(string text)
		{
			OnTextChanged?.Invoke(text);
			OnTextChangedEvent?.Invoke(text);
		}
	}
}
