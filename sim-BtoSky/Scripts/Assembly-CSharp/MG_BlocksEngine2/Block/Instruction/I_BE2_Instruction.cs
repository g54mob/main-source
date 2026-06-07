namespace MG_BlocksEngine2.Block.Instruction
{
	public interface I_BE2_Instruction
	{
		I_BE2_InstructionBase InstructionBase { get; }

		bool ExecuteInUpdate { get; }

		string Operation();

		void Function();

		void Reset();
	}
}
