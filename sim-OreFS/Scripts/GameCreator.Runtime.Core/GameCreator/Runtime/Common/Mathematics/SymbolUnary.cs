namespace GameCreator.Runtime.Common.Mathematics
{
	internal class SymbolUnary : ISymbol
	{
		private readonly ISymbol m_RHS;

		private readonly Parser.UnaryOperation m_Operation;

		public SymbolUnary(ISymbol rhs, Parser.UnaryOperation operation)
		{
			m_RHS = rhs;
			m_Operation = operation;
		}

		public float Evaluate()
		{
			float a = m_RHS.Evaluate();
			return m_Operation(a);
		}
	}
}
