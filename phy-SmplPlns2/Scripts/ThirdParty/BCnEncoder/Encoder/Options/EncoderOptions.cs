using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Options
{
	public class EncoderOptions
	{
		public bool IsParallel { get; set; } = true;

		public int TaskCount { get; set; } = Environment.ProcessorCount;

		public IProgress<ProgressElement> Progress { get; set; }
	}
}
