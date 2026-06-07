using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte instantRevival;
		}

		public long startingSimFrame;

		public bool instantRevival;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654);
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

		public _a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a388dbef6434bb5469207c030841de4f_6cc5b4e85f0d488fa2c4a488691c1654);
		}
	}
}
