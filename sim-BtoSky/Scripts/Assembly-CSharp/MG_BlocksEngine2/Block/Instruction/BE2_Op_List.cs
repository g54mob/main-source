using MG_BlocksEngine2.Attribute;
using MG_BlocksEngine2.Environment;

namespace MG_BlocksEngine2.Block.Instruction
{
	[SerializeAsVariable(typeof(BE2_VariablesListManager))]
	public class BE2_Op_List : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_VariablesListManager _variablesManager;

		protected override void OnStart()
		{
			_variablesManager = BE2_VariablesListManager.instance;
		}

		public new string Operation()
		{
			return _variablesManager.GetListStringValue(base.Section0Inputs[0].StringValue, 0);
		}
	}
}
