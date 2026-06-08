using System;
using ProtoBuf.WellKnownTypes;

namespace ProtoBuf.Meta
{
	public sealed class ServiceMethod
	{
		public string Name { get; set; }

		public Type InputType { get; set; } = typeof(Empty);

		public Type OutputType { get; set; } = typeof(Empty);

		public bool ServerStreaming { get; set; }

		public bool ClientStreaming { get; set; }
	}
}
