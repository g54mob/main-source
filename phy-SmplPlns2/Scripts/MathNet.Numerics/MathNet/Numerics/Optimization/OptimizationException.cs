using System;

namespace MathNet.Numerics.Optimization
{
	public class OptimizationException : Exception
	{
		public OptimizationException(string message)
			: base(message)
		{
		}

		public OptimizationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
