using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int groupIndex;

			[FieldOffset(4)]
			public int groupSize;

			[FieldOffset(8)]
			public float circlingAngle;

			[FieldOffset(12)]
			public float attackDelay;

			[FieldOffset(16)]
			public Entity parentBoss;
		}

		public int groupIndex;

		public int groupSize;

		public float circlingAngle;

		public float attackDelay;

		public Entity parentBoss;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294);
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

		public _3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294(Entity entity, int groupIndex, int groupSize, float circlingAngle, float attackDelay, Entity parentBoss)
		{
			this.groupIndex = 0;
			this.groupSize = 0;
			this.circlingAngle = 0f;
			this.attackDelay = 0f;
			this.parentBoss = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3b27967017d8b0248ac7d8ac7e83e721_0dd52434e9af432cb2b2ef9f8f14e294);
		}
	}
}
