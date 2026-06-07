using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e);
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

		public _5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c2a35bf4e95e134bb7cfe966ccbc525_b05ab84d50c74f1daedf51b02548244e);
		}
	}
}
