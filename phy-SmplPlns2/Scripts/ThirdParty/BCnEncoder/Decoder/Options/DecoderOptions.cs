using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder.Options
{
	public class DecoderOptions
	{
		public bool IsParallel { get; set; }

		public int TaskCount { get; set; } = Environment.ProcessorCount;

		public IProgress<ProgressElement> Progress { get; set; }
	}
}
