using System;

namespace FluentAssertions.Equivalency.Tracing
{
	public interface ITraceWriter
	{
		void AddSingle(string trace);

		IDisposable AddBlock(string trace);

		new string ToString();
	}
}
