using Unity.Entities;
using Unity.Entities.Serialization;

namespace Pug.ECS.Serialization.DOTS100
{
	internal static class DotsSerializationHelpers
	{
		public static StringTableWriterHandle CreateStringTableNode(this DotsSerializationWriter writer, Hash128 id)
		{
			return new StringTableWriterHandle(writer.CreateNode<Unity.Entities.Serialization.DotsSerialization.StringTableNode>(id));
		}

		public static StringTableReaderHandle OpenStringTableNode(this DotsSerializationReader reader, DotsSerializationReader.NodeHandle stringTableNode)
		{
			return new StringTableReaderHandle(stringTableNode);
		}
	}
}
