using System;
using System.Runtime.ExceptionServices;

namespace UniRx.InternalUtil
{
	internal static class ExceptionExtensions
	{
		public static void Throw(this Exception exception)
		{
			ExceptionDispatchInfo.Capture(exception).Throw();
			throw exception;
		}
	}
}
