using DV.UIFramework;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class SettingChangeSourceTextInput : SettingChangeSource<string>
	{
		[NullCheck]
		[SerializeField]
		private TMP_InputField inputField;

		protected override void Awake()
		{
			base.Awake();
			inputField.onValueChanged.AddListener(UpdateAndFireEvent);
			inputField.onSelect.AddListener(OnSelect);
			inputField.onEndEdit.AddListener(OnDeselect);
		}

		private void OnDestroy()
		{
			inputField.onValueChanged.RemoveListener(UpdateAndFireEvent);
			inputField.onSelect.RemoveListener(OnSelect);
			inputField.onEndEdit.RemoveListener(OnDeselect);
		}

		private void OnSelect(string text)
		{
			SingletonBehaviour<APlatformProvider>.Instance.RequestTextInput(new APlatformProvider.TextInputRequest(inputField, isMultiLine: false, labelTMPro.text, delegate(APlatformProvider.TextInputResult result)
			{
				if (result.SaveText)
				{
					inputField.text = result.Text;
					inputField.caretPosition = int.MaxValue;
				}
				if (result.IsFinished)
				{
					inputField.DeactivateInputField();
				}
			}));
		}

		private void OnDeselect(string arg0)
		{
			SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				inputField.text = GetLatestValueFromProvider();
				base.OnResetOrApplied();
			}
		}
	}
}
