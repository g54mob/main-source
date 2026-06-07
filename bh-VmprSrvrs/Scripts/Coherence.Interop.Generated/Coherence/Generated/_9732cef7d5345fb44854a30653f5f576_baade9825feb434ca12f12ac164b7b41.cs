using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41);
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

		public static void Serialize(_9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_baade9825feb434ca12f12ac164b7b41);
		}
	}
}
