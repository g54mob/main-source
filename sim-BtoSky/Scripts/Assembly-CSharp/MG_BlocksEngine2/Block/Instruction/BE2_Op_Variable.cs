using MG_BlocksEngine2.Attribute;
using MG_BlocksEngine2.Environment;

namespace MG_BlocksEngine2.Block.Instruction
{
	[SerializeAsVariable(typeof(BE2_VariablesManager))]
	public class BE2_Op_Variable : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_VariablesManager _variablesManager;

		protected override void OnStart()
		{
			_variablesManager = BE2_VariablesManager.instance;
		}

		public new string Operation()
		{
			return _variablesManager.GetVariableStringValue(base.Section0Inputs[0].StringValue);
		}
	}
}
