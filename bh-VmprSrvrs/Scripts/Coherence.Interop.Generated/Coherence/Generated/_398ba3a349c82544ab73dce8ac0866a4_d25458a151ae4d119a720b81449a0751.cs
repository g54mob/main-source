using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751 FromInterop(IntPtr data, int dataSize)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751);
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

		public _398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_d25458a151ae4d119a720b81449a0751);
		}
	}
}
