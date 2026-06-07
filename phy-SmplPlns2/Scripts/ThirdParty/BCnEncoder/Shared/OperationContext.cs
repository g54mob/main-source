using System;
using System.Threading;

namespace BCnEncoder.Shared
{
	public class OperationContext
	{
		public bool IsParallel { get; set; }

		public int TaskCount { get; set; } = Environment.ProcessorCount;

		public CancellationToken CancellationToken { get; set; }

		public OperationProgress Progress { get; set; }
	}
}
