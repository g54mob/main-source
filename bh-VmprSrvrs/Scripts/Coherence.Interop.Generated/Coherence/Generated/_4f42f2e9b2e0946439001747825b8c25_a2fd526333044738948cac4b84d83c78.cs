using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public HashSet<Entity> GetEntityRefs()
		{
			return null;
		}

		public void NullEntityRefs(Entity entity)
		{
		}

		public static void Serialize(_4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4f42f2e9b2e0946439001747825b8c25_a2fd526333044738948cac4b84d83c78);
		}
	}
}
