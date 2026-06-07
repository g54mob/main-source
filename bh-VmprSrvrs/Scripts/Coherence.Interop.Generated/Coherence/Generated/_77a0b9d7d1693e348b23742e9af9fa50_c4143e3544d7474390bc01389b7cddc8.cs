using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8);
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

		public static void Serialize(_77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_77a0b9d7d1693e348b23742e9af9fa50_c4143e3544d7474390bc01389b7cddc8);
		}
	}
}
