using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145);
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

		public _0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0872fdc53ff04e8479039324cb1f0008_26dc979f12cf4e0fa55704600c8d3145);
		}
	}
}
