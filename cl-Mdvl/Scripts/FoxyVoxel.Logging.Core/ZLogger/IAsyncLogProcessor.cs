using System;

namespace ZLogger
{
	public interface IAsyncLogProcessor : IAsyncDisposable
	{
		void Post(IZLoggerEntry log);
	}
}
