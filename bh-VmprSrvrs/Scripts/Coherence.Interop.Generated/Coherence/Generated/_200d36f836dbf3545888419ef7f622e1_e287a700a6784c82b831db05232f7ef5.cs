using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5);
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

		public _200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_200d36f836dbf3545888419ef7f622e1_e287a700a6784c82b831db05232f7ef5);
		}
	}
}
