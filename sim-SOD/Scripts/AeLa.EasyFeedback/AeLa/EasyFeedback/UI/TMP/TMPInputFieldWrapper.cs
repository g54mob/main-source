using AeLa.EasyFeedback.UI.Interfaces;
using TMPro;
using UnityEngine.Events;

namespace AeLa.EasyFeedback.UI.TMP
{
	internal class TMPInputFieldWrapper : UIInteropWrapper<TMP_InputField>, IInputField
	{
		public UnityEvent<string> OnValueChanged => null;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsFocused => false;

		public TMPInputFieldWrapper(TMP_InputField internalTarget)
			: base((TMP_InputField)default(_00210))
		{
		}

		public void ActivateInputField()
		{
		}

		public void DeactivateInputField()
		{
		}
	}
}
