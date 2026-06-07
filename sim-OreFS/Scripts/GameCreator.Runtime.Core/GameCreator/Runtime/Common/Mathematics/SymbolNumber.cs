namespace GameCreator.Runtime.Common.Mathematics
{
	internal class SymbolNumber : ISymbol
	{
		private readonly float m_Number;

		public SymbolNumber(float number)
		{
			m_Number = number;
		}

		public float Evaluate()
		{
			return m_Number;
		}
	}
}
