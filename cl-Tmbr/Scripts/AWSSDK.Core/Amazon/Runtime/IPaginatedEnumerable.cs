using System.Collections.Generic;

namespace Amazon.Runtime
{
	public interface IPaginatedEnumerable<TResult> : IAsyncEnumerable<TResult>
	{
	}
}
