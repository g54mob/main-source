using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.UI.UGUI
{
	internal class UGUIInputFieldWrapper : UIInteropWrapper<InputField>, IInputField
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

		public UGUIInputFieldWrapper(InputField internalTarget)
			: base((InputField)default(_00210))
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
