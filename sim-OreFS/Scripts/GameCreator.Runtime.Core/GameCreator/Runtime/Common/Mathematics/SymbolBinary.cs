namespace GameCreator.Runtime.Common.Mathematics
{
	internal class SymbolBinary : ISymbol
	{
		private readonly ISymbol m_LHS;

		private readonly ISymbol m_RHS;

		private readonly Parser.BinaryOperation m_Operation;

		public SymbolBinary(ISymbol lhs, ISymbol rhs, Parser.BinaryOperation operation)
		{
			m_LHS = lhs;
			m_RHS = rhs;
			m_Operation = operation;
		}

		public float Evaluate()
		{
			float a = m_LHS.Evaluate();
			float b = m_RHS.Evaluate();
			return m_Operation(a, b);
		}
	}
}
