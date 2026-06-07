using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class NumericalBreakdownException : NonConvergenceException
	{
		public NumericalBreakdownException()
			: base("Algorithm experience a numerical break down.")
		{
		}

		public NumericalBreakdownException(string message)
			: base(message)
		{
		}

		public NumericalBreakdownException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
