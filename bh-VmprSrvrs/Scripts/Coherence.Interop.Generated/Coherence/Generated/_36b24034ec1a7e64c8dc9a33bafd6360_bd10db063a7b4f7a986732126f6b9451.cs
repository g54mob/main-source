using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451 FromInterop(IntPtr data, int dataSize)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451);
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

		public _36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_bd10db063a7b4f7a986732126f6b9451);
		}
	}
}
