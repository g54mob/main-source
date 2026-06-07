using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998);
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

		public _b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b3a055bc4a1008e4daaea01316b22210_8051a51ef09c4fefb78ed23f7bc94998);
		}
	}
}
