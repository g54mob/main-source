using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b FromInterop(IntPtr data, int dataSize)
		{
			return default(_65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b);
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

		public _65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_65618a9761bc0af44853f3d7d64d8002_5a4a47bb37c94822a8e31d5aa172ac7b);
		}
	}
}
