using System;

namespace ProtoBuf.Serializers
{
	[Flags]
	public enum SerializerFeatures
	{
		WireTypeVarint = 0x10,
		WireTypeFixed64 = 0x11,
		WireTypeString = 0x12,
		WireTypeStartGroup = 0x13,
		WireTypeFixed32 = 0x15,
		WireTypeSignedVarint = 0x18,
		WireTypeSpecified = 0x10,
		CategoryRepeated = 0,
		CategoryScalar = 0x20,
		CategoryMessage = 0x40,
		CategoryMessageWrappedAtRoot = 0x60,
		OptionPackedDisabled = 0x80,
		OptionClearCollection = 0x100,
		OptionFailOnDuplicateKey = 0x200,
		OptionSkipRecursionCheck = 0x400
	}
}
