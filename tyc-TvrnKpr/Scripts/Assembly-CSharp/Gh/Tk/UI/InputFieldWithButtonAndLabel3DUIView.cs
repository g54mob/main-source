using Gh.Tk.UI.Dialogs;
using I18n;
using TMPro;

namespace Gh.Tk.UI
{
	public class InputFieldWithButtonAndLabel3DUIView : BaseInteractable3DUIView
	{
		public FormElementInput inputElement;

		public TMP_InputField inputField;

		public TextMeshProUGUII18n inputFieldText;

		public TextMeshProUGUII18n inputFieldLabel;

		public TextMeshProUGUII18n inputPlaceholderLabel;

		public Button3DUIView submitButton;

		public void SetInputText(string username)
		{
		}

		public string GetInputText()
		{
			return null;
		}
	}
}
