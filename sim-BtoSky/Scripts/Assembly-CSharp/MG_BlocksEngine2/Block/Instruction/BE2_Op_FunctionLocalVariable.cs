using TMPro;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_FunctionLocalVariable : BE2_InstructionBase, I_BE2_Instruction
	{
		public BE2_Ins_DefineFunction defineInstruction;

		public BE2_Block blockToObserve;

		private TMP_Text _text;

		public string varName = "";

		protected override void OnAwake()
		{
			_text = GetComponentInChildren<TMP_Text>();
			if ((bool)_text)
			{
				varName = _text.text;
			}
		}

		public new string Operation()
		{
			if ((bool)defineInstruction)
			{
				int localVariableIndex = defineInstruction.GetLocalVariableIndex(varName);
				return (blockToObserve.Instruction as BE2_Ins_FunctionBlock).localValues[localVariableIndex];
			}
			return "";
		}
	}
}
