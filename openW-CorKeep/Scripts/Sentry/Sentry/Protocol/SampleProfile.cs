using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	internal sealed class SampleProfile : ISentryJsonSerializable
	{
		public class Sample : ISentryJsonSerializable
		{
			public ulong Timestamp;

			public int ThreadId;

			public int StackId;

			public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
			{
				writer.WriteStartObject();
				writer.WriteNumber("elapsed_since_start_ns", Timestamp);
				writer.WriteNumber("thread_id", ThreadId);
				writer.WriteNumber("stack_id", StackId);
				writer.WriteEndObject();
			}
		}

		internal GrowableArray<Sample> Samples = new GrowableArray<Sample>(10000);

		internal GrowableArray<SentryStackFrame> Frames = new GrowableArray<SentryStackFrame>(100);

		internal GrowableArray<GrowableArray<int>> Stacks = new GrowableArray<GrowableArray<int>>(100);

		internal List<SentryThread> Threads = new List<SentryThread>(10);

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStartObject("thread_metadata");
			for (int i = 0; i < Threads.Count; i++)
			{
				writer.WriteSerializable(i.ToString(), Threads[i], logger);
			}
			writer.WriteEndObject();
			writer.WriteArray("stacks", Stacks, logger);
			writer.WriteArray("frames", Frames, logger);
			writer.WriteArray("samples", Samples, logger);
			writer.WriteEndObject();
		}
	}
}
