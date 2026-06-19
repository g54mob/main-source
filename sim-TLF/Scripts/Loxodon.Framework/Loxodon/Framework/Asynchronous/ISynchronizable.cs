using System;

namespace Loxodon.Framework.Asynchronous
{
	public interface ISynchronizable
	{
		bool WaitForDone();

		object WaitForResult(int millisecondsTimeout = 0);

		object WaitForResult(TimeSpan timeout);
	}
	public interface ISynchronizable<TResult> : ISynchronizable
	{
		new TResult WaitForResult(int millisecondsTimeout = 0);

		new TResult WaitForResult(TimeSpan timeout);
	}
}
