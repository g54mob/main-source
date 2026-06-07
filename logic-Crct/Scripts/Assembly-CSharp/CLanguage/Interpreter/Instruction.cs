namespace CLanguage.Interpreter
{
	public class Instruction
	{
		public OpCode Op;

		public Value X;

		public CLangLabel? Label;

		public Instruction(OpCode op, Value x)
		{
		}

		public Instruction(OpCode op, CLangLabel label)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
