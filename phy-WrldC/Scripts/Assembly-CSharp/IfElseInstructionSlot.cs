using UnityEngine;

public abstract class IfElseInstructionSlot : MultiDropZonesInstructionSlot
{
	private GameObject ifPanel;

	private GameObject elsePanel;

	private InstructionDropZone ifInstructionDropZone;

	private InstructionDropZone elseInstructionDropZone;

	public Transform IfTransform => ifPanel.transform;

	public Transform ElseTransform => elsePanel.transform;

	protected override void Awake()
	{
		base.Awake();
		ifPanel = base.transform.FindChildRecursively("IfPanel").gameObject;
		elsePanel = base.transform.FindChildRecursively("ElsePanel").gameObject;
		ifInstructionDropZone = ifPanel.GetComponent<InstructionDropZone>();
		ifInstructionDropZone.IsRootLevel = false;
		elseInstructionDropZone = elsePanel.GetComponent<InstructionDropZone>();
		elseInstructionDropZone.IsRootLevel = false;
	}

	protected override void InternalInitialize(Instruction instruction)
	{
		base.InternalInitialize(instruction);
		ifInstructionDropZone.InstructionsList = instruction.FirstInstructionsList;
		elseInstructionDropZone.InstructionsList = instruction.SecondInstructionsList;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		ifInstructionDropZone.InstructionsList = null;
		elseInstructionDropZone.InstructionsList = null;
	}
}
