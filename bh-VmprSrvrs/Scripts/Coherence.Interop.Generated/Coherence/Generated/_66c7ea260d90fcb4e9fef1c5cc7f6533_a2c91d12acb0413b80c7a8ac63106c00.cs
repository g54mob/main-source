using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity requestingPlayer;
		}

		public long startingSimFrame;

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00 FromInterop(IntPtr data, int dataSize)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00);
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

		public _66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_a2c91d12acb0413b80c7a8ac63106c00);
		}
	}
}
