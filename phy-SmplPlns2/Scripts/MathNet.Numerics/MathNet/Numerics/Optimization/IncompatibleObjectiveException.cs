namespace MathNet.Numerics.Optimization
{
	public class IncompatibleObjectiveException : OptimizationException
	{
		public IncompatibleObjectiveException(string message)
			: base(message)
		{
		}
	}
}
