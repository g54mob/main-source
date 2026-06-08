using System;
using System.ComponentModel;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetupSequentialResult<TResult>
	{
		ISetupSequentialResult<TResult> Returns(TResult value);

		ISetupSequentialResult<TResult> Returns(Func<TResult> valueFunction);

		ISetupSequentialResult<TResult> Throws(Exception exception);

		ISetupSequentialResult<TResult> Throws<TException>() where TException : Exception, new();

		ISetupSequentialResult<TResult> Throws<TException>(Func<TException> exceptionFunction) where TException : Exception;

		ISetupSequentialResult<TResult> CallBase();
	}
}
