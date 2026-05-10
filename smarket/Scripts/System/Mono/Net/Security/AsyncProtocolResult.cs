using System.Runtime.ExceptionServices;

namespace Mono.Net.Security
{
	internal class AsyncProtocolResult
	{
		public int UserResult { get; }

		public ExceptionDispatchInfo Error { get; }

		public AsyncProtocolResult(int result)
		{
		}

		public AsyncProtocolResult(ExceptionDispatchInfo error)
		{
		}
	}
}
