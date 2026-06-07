using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636);
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

		public _c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_9f55e5b96e764f41b1a020f815ac7636);
		}
	}
}
