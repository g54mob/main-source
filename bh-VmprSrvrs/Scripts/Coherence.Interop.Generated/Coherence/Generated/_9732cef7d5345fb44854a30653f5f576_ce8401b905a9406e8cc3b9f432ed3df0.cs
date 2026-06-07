using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0);
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

		public _9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_ce8401b905a9406e8cc3b9f432ed3df0);
		}
	}
}
