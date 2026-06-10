using NSEipix.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class EditableInputGroupLayoutItemView : LayoutGroupItemView
	{
		private readonly int inputIndex;

		private readonly int minusButtonIndex = 1;

		private readonly int plusButtonIndex = 2;

		public TMP_InputField InputField => base.GroupItems[inputIndex].GetComponent<TMP_InputField>();

		public SoundButton MinusButton => base.GroupItems[minusButtonIndex].GetComponent<SoundButton>();

		public SoundButton PlusButton => base.GroupItems[plusButtonIndex].GetComponent<SoundButton>();

		public void SetData(string value, UnityAction<int> inputCallback, UnityAction<int> buttonCallback, int buttonModifier = 1)
		{
			InputField.text = value;
			InputField.onEndEdit.RemoveAllListeners();
			InputField.onEndEdit.AddListener(delegate(string s)
			{
				inputCallback(OnInputCallback(s));
			});
			MinusButton.AddCleanListener(delegate
			{
				OnButtonCallback(-buttonModifier, buttonCallback);
			});
			PlusButton.AddCleanListener(delegate
			{
				OnButtonCallback(buttonModifier, buttonCallback);
			});
		}

		private void OnButtonCallback(int value, UnityAction<int> buttonCallback)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				value *= 100;
			}
			else if (Input.GetKey(KeyCode.LeftControl))
			{
				value *= 10;
			}
			buttonCallback(value);
		}

		private static int OnInputCallback(string s)
		{
			int.TryParse(s, out var result);
			return result;
		}
	}
}
