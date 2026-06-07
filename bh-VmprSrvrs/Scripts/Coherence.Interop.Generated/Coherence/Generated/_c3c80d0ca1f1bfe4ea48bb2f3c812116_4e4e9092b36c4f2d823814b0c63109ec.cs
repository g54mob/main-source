using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec FromInterop(IntPtr data, int dataSize)
		{
			return default(_c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec);
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

		public _c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c3c80d0ca1f1bfe4ea48bb2f3c812116_4e4e9092b36c4f2d823814b0c63109ec);
		}
	}
}
