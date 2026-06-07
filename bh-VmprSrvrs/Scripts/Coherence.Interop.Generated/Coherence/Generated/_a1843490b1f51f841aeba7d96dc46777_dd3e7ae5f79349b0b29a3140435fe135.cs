using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135);
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

		public static void Serialize(_a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a1843490b1f51f841aeba7d96dc46777_dd3e7ae5f79349b0b29a3140435fe135);
		}
	}
}
