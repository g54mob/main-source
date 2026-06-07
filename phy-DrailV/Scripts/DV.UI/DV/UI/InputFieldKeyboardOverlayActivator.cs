using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(TMP_InputField))]
	public class InputFieldKeyboardOverlayActivator : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private TMP_InputField inputField;

		private void Awake()
		{
			inputField.onSelect.AddListener(OnSelect);
			inputField.onEndEdit.AddListener(OnDeselect);
		}

		private void OnDestroy()
		{
			inputField.onSelect.RemoveListener(OnSelect);
			inputField.onEndEdit.RemoveListener(OnDeselect);
		}

		private void OnSelect(string text)
		{
			SingletonBehaviour<APlatformProvider>.Instance.RequestTextInput(new APlatformProvider.TextInputRequest(inputField, inputField.multiLine, descriptionText ? descriptionText.text : "", delegate(APlatformProvider.TextInputResult result)
			{
				if (result.SaveText)
				{
					inputField.text = result.Text;
					inputField.caretPosition = int.MaxValue;
				}
			}));
		}

		private void OnDeselect(string text)
		{
			SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
		}
	}
}
