using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b FromInterop(IntPtr data, int dataSize)
		{
			return default(_d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b);
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

		public _d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d6fc9483b3f1f6541b4122c5b5318fff_73fe988920f742f882fafc17a2a5c34b);
		}
	}
}
