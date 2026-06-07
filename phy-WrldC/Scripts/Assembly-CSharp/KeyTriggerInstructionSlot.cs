using System;
using TMPro;
using UnityEngine;

public class KeyTriggerInstructionSlot : IfElseInstructionSlot
{
	private EditableLabel editableKeyLabel;

	private KeyAssignment keyAssignment;

	private TMP_Dropdown typeDropdown;

	private KeyTriggerInstruction keyTriggerInstruction;

	public event Action<bool> OnKeyBeginingOrEndingAssigmentEvent;

	public event Action<bool> OnKeyBeginingOrEndingLabelEditingEvent;

	protected override void Awake()
	{
		base.Awake();
		editableKeyLabel = base.transform.FindComponent<EditableLabel>("EditableKeyLabel", isRecursively: true);
		keyAssignment = base.transform.FindComponent<KeyAssignment>("KeyAssignment", isRecursively: true);
		typeDropdown = base.transform.FindComponent<TMP_Dropdown>("TypeDropdown", isRecursively: true);
		editableKeyLabel.OnLabelChangedEvent += delegate(string newLabel)
		{
			keyTriggerInstruction.KeyLabel = newLabel;
			keyTriggerInstruction.WasKeyLabelChanged = true;
		};
		editableKeyLabel.OnBeginingEditLabelEvent += delegate
		{
			this.OnKeyBeginingOrEndingLabelEditingEvent?.Invoke(obj: true);
		};
		editableKeyLabel.OnEndingEditLabelEvent += delegate
		{
			this.OnKeyBeginingOrEndingLabelEditingEvent?.Invoke(obj: false);
		};
		keyAssignment.OnKeyAssignment += delegate(KeyCode keyCode, AxisCode axisCode)
		{
			keyTriggerInstruction.Key = keyCode;
		};
		keyAssignment.OnKeyBeginingAssigment += delegate
		{
			this.OnKeyBeginingOrEndingAssigmentEvent?.Invoke(obj: true);
		};
		keyAssignment.OnKeyEndingAssigment += delegate
		{
			this.OnKeyBeginingOrEndingAssigmentEvent?.Invoke(obj: false);
		};
		typeDropdown.onValueChanged.AddListener(delegate(int index)
		{
			keyTriggerInstruction.TriggerType = (KeyTriggerType)index;
		});
	}

	private void InitializeTypeDropdown()
	{
		typeDropdown.options.Clear();
		string text = LanguagesManager.Instance.GetText("logic.key.down", "Down");
		string text2 = LanguagesManager.Instance.GetText("logic.key.up", "Up");
		string text3 = LanguagesManager.Instance.GetText("logic.key.uptodown", "Up to Down");
		string text4 = LanguagesManager.Instance.GetText("logic.key.downtoup", "Down to Up");
		typeDropdown.options.Add(new TMP_Dropdown.OptionData(text));
		typeDropdown.options.Add(new TMP_Dropdown.OptionData(text2));
		typeDropdown.options.Add(new TMP_Dropdown.OptionData(text3));
		typeDropdown.options.Add(new TMP_Dropdown.OptionData(text4));
	}

	public void Initialize(KeyTriggerInstruction instruction)
	{
		InternalInitialize(instruction);
	}

	protected override void InternalInitialize(Instruction instruction)
	{
		base.InternalInitialize(instruction);
		keyTriggerInstruction = instruction as KeyTriggerInstruction;
		InitializeTypeDropdown();
		editableKeyLabel.SetText(keyTriggerInstruction.KeyLabel);
		keyAssignment.SetKey(keyTriggerInstruction.Key);
		typeDropdown.value = (int)keyTriggerInstruction.TriggerType;
	}

	public void SetAxisEnabled(bool isAxisEnabled)
	{
		keyAssignment.IsAxisEnabled = isAxisEnabled;
	}

	public override Instruction GetInstruction()
	{
		return keyTriggerInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnKeyBeginingOrEndingAssigmentEvent = null;
		this.OnKeyBeginingOrEndingLabelEditingEvent = null;
		keyTriggerInstruction = null;
	}
}
