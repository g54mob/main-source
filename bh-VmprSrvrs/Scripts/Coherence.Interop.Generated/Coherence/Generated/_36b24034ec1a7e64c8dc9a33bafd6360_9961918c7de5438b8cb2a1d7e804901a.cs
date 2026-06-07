using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a FromInterop(IntPtr data, int dataSize)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a);
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

		public _36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_9961918c7de5438b8cb2a1d7e804901a);
		}
	}
}
