using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0);
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

		public static void Serialize(_4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4a18ef90fc76b674d9e83d3efeb63df8_63404b3da7ea422cb25f78eebcee2ef0);
		}
	}
}
