using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191);
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

		public _ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_5e71357d7521440f9c89c05a240b6191);
		}
	}
}
