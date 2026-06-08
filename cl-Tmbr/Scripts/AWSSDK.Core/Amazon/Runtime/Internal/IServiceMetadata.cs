using System.Collections.Generic;

namespace Amazon.Runtime.Internal
{
	public interface IServiceMetadata
	{
		string ServiceId { get; }

		IDictionary<string, string> OperationNameMapping { get; }
	}
}
