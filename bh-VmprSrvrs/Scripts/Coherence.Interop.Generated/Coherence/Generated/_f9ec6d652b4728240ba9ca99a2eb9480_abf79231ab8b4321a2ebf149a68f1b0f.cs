using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public ByteArray serializedEnemyTypes;

			[FieldOffset(24)]
			public int voteTarget;
		}

		public long startingSimFrame;

		public byte[] serializedEnemyTypes;

		public int voteTarget;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f FromInterop(IntPtr data, int dataSize)
		{
			return default(_f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f);
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

		public _f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f9ec6d652b4728240ba9ca99a2eb9480_abf79231ab8b4321a2ebf149a68f1b0f);
		}
	}
}
