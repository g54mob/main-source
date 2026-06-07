using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5);
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

		public _b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b91cc011715c64a418dc18abc982a37a_2a60819541404e5faf8a2693cb49f2d5);
		}
	}
}
