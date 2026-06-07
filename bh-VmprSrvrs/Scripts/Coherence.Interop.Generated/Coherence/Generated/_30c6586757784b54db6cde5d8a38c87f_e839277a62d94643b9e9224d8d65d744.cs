using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744 FromInterop(IntPtr data, int dataSize)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744);
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

		public _30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_e839277a62d94643b9e9224d8d65d744);
		}
	}
}
