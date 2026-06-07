using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047 FromInterop(IntPtr data, int dataSize)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047);
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

		public _52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_3055acbb3013488e9d6c63029ecb4047);
		}
	}
}
