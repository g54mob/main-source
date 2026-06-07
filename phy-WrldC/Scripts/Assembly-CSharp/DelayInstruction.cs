using System;
using System.Collections.Generic;

[Serializable]
public class DelayInstruction : Instruction
{
	public int Time { get; set; }

	public DelayInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Delay;
		Time = 1000;
	}

	public override IEnumerable<int> Execute()
	{
		yield return Time;
	}
}
