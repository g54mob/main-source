using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3);
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

		public _2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_982f2016de4f4285ad7afee1ca4e42e3);
		}
	}
}
