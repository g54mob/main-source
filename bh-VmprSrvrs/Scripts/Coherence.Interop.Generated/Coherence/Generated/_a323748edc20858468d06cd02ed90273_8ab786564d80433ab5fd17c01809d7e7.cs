using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7);
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

		public _a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a323748edc20858468d06cd02ed90273_8ab786564d80433ab5fd17c01809d7e7);
		}
	}
}
