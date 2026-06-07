using UnityEngine;

namespace DV.Util
{
	public static class ErrorLoggerAccumulatorExtensions
	{
		public static ErrorLoggerAccumulator GetErrorLoggerAccumulator(this MonoBehaviour mb)
		{
			return new ErrorLoggerAccumulator(mb.GetType().Name, mb);
		}
	}
}
