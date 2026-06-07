using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c FromInterop(IntPtr data, int dataSize)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c);
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

		public _87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_6a17f1e866a544aebc69e92a90d2a75c);
		}
	}
}
