using System;

namespace MathNet.Numerics.Optimization
{
	public class InnerOptimizationException : OptimizationException
	{
		public InnerOptimizationException(string message)
			: base(message)
		{
		}

		public InnerOptimizationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
