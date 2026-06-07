using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d FromInterop(IntPtr data, int dataSize)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d);
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

		public _957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_f4b135ebacbd4372a6d5f2a97f26e56d);
		}
	}
}
