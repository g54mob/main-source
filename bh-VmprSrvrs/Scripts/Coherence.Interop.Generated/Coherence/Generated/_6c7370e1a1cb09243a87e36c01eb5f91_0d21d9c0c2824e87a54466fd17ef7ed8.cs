using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8);
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

		public _6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_0d21d9c0c2824e87a54466fd17ef7ed8);
		}
	}
}
