using System.Collections.Generic;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_ReferenceFunctionBlock : BE2_InstructionBase, I_BE2_Instruction
	{
		public BE2_Ins_FunctionBlock functionInstruction;

		private List<I_BE2_Instruction> _instructionsToReset;

		public BE2_Ins_ReferenceFunctionBlock(BE2_Ins_FunctionBlock functionInstruction)
		{
			this.functionInstruction = functionInstruction;
		}

		public void Initialize(BE2_Ins_FunctionBlock functionInstruction)
		{
			this.functionInstruction = functionInstruction;
		}

		public override void OnPrepareToPlay()
		{
			_instructionsToReset = new List<I_BE2_Instruction>();
			bool flag = false;
			I_BE2_Instruction[] instructionsArray = base.BlocksStack.InstructionsArray;
			foreach (I_BE2_Instruction i_BE2_Instruction in instructionsArray)
			{
				if (flag)
				{
					_instructionsToReset.Add(i_BE2_Instruction);
				}
				if (i_BE2_Instruction == functionInstruction)
				{
					flag = true;
				}
				if (i_BE2_Instruction == this)
				{
					break;
				}
			}
		}

		public new void Function()
		{
			foreach (I_BE2_Instruction item in _instructionsToReset)
			{
				item.Reset();
			}
			for (int i = 0; i < functionInstruction.mirrorFunction.localValues.Count; i++)
			{
				functionInstruction.localValues[i] = base.Section0Inputs[i].StringValue;
			}
			functionInstruction.ExecuteSection(0);
		}
	}
}
