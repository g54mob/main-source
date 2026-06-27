using System;

namespace Castle.Core.Logging
{
	public interface IContextStack
	{
		int Count { get; }

		void Clear();

		string Pop();

		IDisposable Push(string message);
	}
}
