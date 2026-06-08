using System;
using System.Collections.Generic;
using Dorfromantik;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TutorialEvent_DisplayText))]
public class TutorialEvent_ReplaceTextWithKeyMapping : TutorialEvent
{
	[Serializable]
	private struct ReplacedKeyMappingInfo
	{
		public string stringToReplace;

		public InputActionReference inputAction;

		public int firstBindingIndex;

		public int bindingDisplayCount;

		public string fallbackBindingName;
	}

	[SerializeField]
	private List<ReplacedKeyMappingInfo> replacedInfo;

	private TextMeshProUGUI textLabel;

	private QuestWatcher watchedQuest;

	private TutorialEvent_DisplayText displayTextEvent;

	public override void Begin()
	{
		AddReplacementAttributes();
		Singleton<InputManager>.Instance.OnInputDeviceChanged += AddReplacementAttributes;
	}

	private void AddReplacementAttributes(Dorfromantik.InputDevice inputDevice = Dorfromantik.InputDevice.Undefined)
	{
		displayTextEvent = GetComponent<TutorialEvent_DisplayText>();
		foreach (ReplacedKeyMappingInfo item in replacedInfo)
		{
			string currentControlScheme = Singleton<InputManager>.Instance.CurrentControlScheme;
			string text = KeyBindingUtility.GetRichTextAttributeForBinding(KeyBindingUtility.GetBindingString(item.inputAction.action, InputBinding.MaskByGroup(currentControlScheme)), showSymbolForEmptyBinding: false, item.fallbackBindingName, item.firstBindingIndex, item.bindingDisplayCount);
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = StringUtility.Reverse(text);
			}
			displayTextEvent.AddReplacement(item.stringToReplace, text);
		}
		displayTextEvent.UpdateText();
	}

	public override void Finish()
	{
		if ((bool)Singleton<InputManager>.Instance)
		{
			Singleton<InputManager>.Instance.OnInputDeviceChanged -= AddReplacementAttributes;
		}
	}

	public override void Skip()
	{
	}
}
