using System;
using System.ComponentModel;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetupSequentialAction
	{
		ISetupSequentialAction Pass();

		ISetupSequentialAction Throws<TException>() where TException : Exception, new();

		ISetupSequentialAction Throws(Exception exception);

		ISetupSequentialAction Throws<TException>(Func<TException> exceptionFunction) where TException : Exception;
	}
}
