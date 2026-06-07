using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d FromInterop(IntPtr data, int dataSize)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d);
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

		public _30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_2cb32d4597f041cd906f68df0019c10d);
		}
	}
}
