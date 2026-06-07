using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716);
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

		public _ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ba1c8b17e52bed441b02a3c7489360d2_e0559a866d6e4a8a8df754b74c462716);
		}
	}
}
