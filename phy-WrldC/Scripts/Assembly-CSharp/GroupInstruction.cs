using System.Collections.Generic;

public class GroupInstruction : Instruction
{
	public string GroupLabel { get; set; }

	public bool WasGroupLabelChanged { get; set; }

	public GroupInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Group;
		GroupLabel = LanguagesManager.Instance.GetText("label.text.logic.group.label", "label.text.logic.group.label");
		WasGroupLabelChanged = false;
	}

	public override IEnumerable<int> Execute()
	{
		foreach (int item in ExecuteAllFirstInstructions())
		{
			yield return item;
		}
	}
}
