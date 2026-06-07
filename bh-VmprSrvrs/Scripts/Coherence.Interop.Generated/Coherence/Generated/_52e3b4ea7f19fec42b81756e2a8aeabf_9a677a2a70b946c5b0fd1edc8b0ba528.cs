using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528 FromInterop(IntPtr data, int dataSize)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528);
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

		public _52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_9a677a2a70b946c5b0fd1edc8b0ba528);
		}
	}
}
