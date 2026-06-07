using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class NonConvergenceException : Exception
	{
		public NonConvergenceException()
			: base("An algorithm failed to converge.")
		{
		}

		public NonConvergenceException(string message)
			: base(message)
		{
		}

		public NonConvergenceException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
