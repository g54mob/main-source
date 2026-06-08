using System;

namespace NSubstitute.Core
{
	internal class EmptyDisposable : IDisposable
	{
		public static IDisposable Instance { get; } = new EmptyDisposable();

		public void Dispose()
		{
		}
	}
}
