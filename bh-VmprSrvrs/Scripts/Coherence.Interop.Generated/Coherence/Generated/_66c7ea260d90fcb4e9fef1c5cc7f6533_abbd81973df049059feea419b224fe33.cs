using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public ByteArray serializedMerchantData;
		}

		public byte[] serializedMerchantData;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33 FromInterop(IntPtr data, int dataSize)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33);
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

		public _66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33(Entity entity, byte[] serializedMerchantData)
		{
			this.serializedMerchantData = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_abbd81973df049059feea419b224fe33);
		}
	}
}
