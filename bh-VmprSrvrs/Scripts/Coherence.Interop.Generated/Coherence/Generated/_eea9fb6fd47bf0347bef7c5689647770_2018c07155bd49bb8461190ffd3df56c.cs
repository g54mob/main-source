using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c FromInterop(IntPtr data, int dataSize)
		{
			return default(_eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c);
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

		public _eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_eea9fb6fd47bf0347bef7c5689647770_2018c07155bd49bb8461190ffd3df56c);
		}
	}
}
