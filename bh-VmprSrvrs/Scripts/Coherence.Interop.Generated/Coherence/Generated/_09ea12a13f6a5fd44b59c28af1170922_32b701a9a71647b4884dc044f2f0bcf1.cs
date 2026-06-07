using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1);
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

		public _09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_09ea12a13f6a5fd44b59c28af1170922_32b701a9a71647b4884dc044f2f0bcf1);
		}
	}
}
