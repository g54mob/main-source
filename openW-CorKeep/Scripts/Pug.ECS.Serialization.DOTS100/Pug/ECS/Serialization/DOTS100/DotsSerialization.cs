using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;

namespace Pug.ECS.Serialization.DOTS100
{
	internal static class DotsSerialization
	{
		internal static readonly byte[] HeaderMagic = new byte[8] { 68, 79, 84, 83, 66, 73, 78, 33 };

		internal const ulong RootNodeHash = 0uL;

		public static DotsSerializationWriter CreateWriter(BinaryWriter writer, Hash128 fileId, FixedString64Bytes fileType)
		{
			return new DotsSerializationWriter(writer, fileId, fileType);
		}

		public static DotsSerializationReader CreateReader(BinaryReader reader)
		{
			return new DotsSerializationReader(reader);
		}

		public static DotsSerializationReader CreateReader(ref Unity.Entities.Serialization.DotsSerialization.BlobHeader header)
		{
			return new DotsSerializationReader(ref header);
		}
	}
}
