using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.WellKnownTypes
{
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	[ProtoContract(Name = ".google.protobuf.Empty", Serializer = typeof(PrimaryTypeProvider), Origin = "google/protobuf/empty.proto")]
	public readonly struct Empty
	{
	}
}
