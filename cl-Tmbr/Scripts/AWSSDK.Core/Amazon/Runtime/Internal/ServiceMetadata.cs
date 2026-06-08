using System.Collections.Generic;

namespace Amazon.Runtime.Internal
{
	internal class ServiceMetadata : IServiceMetadata
	{
		public string ServiceId { get; }

		public IDictionary<string, string> OperationNameMapping { get; } = new Dictionary<string, string>();
	}
}
