using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_BreakLoop : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_Instruction _parentLoopInstruction;

		private I_BE2_Instruction[] _parentConditionInstructions;

		protected override void OnButtonStop()
		{
			_parentLoopInstruction = BE2_BlockUtils.GetParentInstructionOfType(this, BlockTypeEnum.loop);
			_parentConditionInstructions = BE2_BlockUtils.GetParentInstructionOfTypeAll(this, BlockTypeEnum.condition).ToArray();
		}

		public override void OnStackActive()
		{
			_parentLoopInstruction = BE2_BlockUtils.GetParentInstructionOfType(this, BlockTypeEnum.loop);
			_parentConditionInstructions = BE2_BlockUtils.GetParentInstructionOfTypeAll(this, BlockTypeEnum.condition).ToArray();
		}

		public new void Function()
		{
			if (_parentLoopInstruction == null)
			{
				OnStackActive();
			}
			if (_parentLoopInstruction != null)
			{
				I_BE2_Instruction[] parentConditionInstructions = _parentConditionInstructions;
				for (int i = 0; i < parentConditionInstructions.Length; i++)
				{
					parentConditionInstructions[i].InstructionBase.OnStackActive();
				}
				_parentLoopInstruction.InstructionBase.ExecuteNextInstruction();
			}
			else
			{
				ExecuteNextInstruction();
			}
		}
	}
}
