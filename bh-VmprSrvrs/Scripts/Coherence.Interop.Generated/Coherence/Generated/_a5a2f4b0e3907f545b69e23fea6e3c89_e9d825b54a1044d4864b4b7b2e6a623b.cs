using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b FromInterop(IntPtr data, int dataSize)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b);
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

		public _a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_e9d825b54a1044d4864b4b7b2e6a623b);
		}
	}
}
