using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be);
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

		public _a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2c9116f3af6dc64dab56b96cdecca53_8e5379be8d0e4182ac5cec62c13de8be);
		}
	}
}
