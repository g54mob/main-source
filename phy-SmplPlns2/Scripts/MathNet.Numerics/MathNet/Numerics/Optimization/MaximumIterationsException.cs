namespace MathNet.Numerics.Optimization
{
	public class MaximumIterationsException : OptimizationException
	{
		public MaximumIterationsException(string message)
			: base(message)
		{
		}
	}
}
