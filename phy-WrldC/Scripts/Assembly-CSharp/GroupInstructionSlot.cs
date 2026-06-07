using System;
using UnityEngine;

public class GroupInstructionSlot : MultiDropZonesInstructionSlot
{
	private GameObject groupPanel;

	private InstructionDropZone groupInstructionDropZone;

	private EditableLabel editableKeyLabel;

	private GroupInstruction groupInstruction;

	public Transform GroupTransform => groupPanel.transform;

	public event Action<bool> OnKeyBeginingOrEndingLabelEditingEvent;

	protected override void Awake()
	{
		base.Awake();
		editableKeyLabel = base.transform.FindComponent<EditableLabel>("EditableKeyLabel", isRecursively: true);
		groupPanel = base.transform.FindChildRecursively("GroupPanel").gameObject;
		groupInstructionDropZone = groupPanel.GetComponent<InstructionDropZone>();
		groupInstructionDropZone.IsRootLevel = false;
		editableKeyLabel.OnLabelChangedEvent += delegate(string newLabel)
		{
			groupInstruction.GroupLabel = newLabel;
			groupInstruction.WasGroupLabelChanged = true;
		};
		editableKeyLabel.OnBeginingEditLabelEvent += delegate
		{
			this.OnKeyBeginingOrEndingLabelEditingEvent?.Invoke(obj: true);
		};
		editableKeyLabel.OnEndingEditLabelEvent += delegate
		{
			this.OnKeyBeginingOrEndingLabelEditingEvent?.Invoke(obj: false);
		};
	}

	public void Initialize(GroupInstruction instruction)
	{
		InternalInitialize(instruction);
	}

	protected override void InternalInitialize(Instruction instruction)
	{
		base.InternalInitialize(instruction);
		groupInstruction = instruction as GroupInstruction;
		editableKeyLabel.SetText(groupInstruction.GroupLabel);
		groupInstructionDropZone.InstructionsList = groupInstruction.FirstInstructionsList;
	}

	public override Instruction GetInstruction()
	{
		return groupInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnKeyBeginingOrEndingLabelEditingEvent = null;
		groupInstructionDropZone.InstructionsList = null;
		groupInstruction = null;
	}
}
