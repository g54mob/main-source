using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d FromInterop(IntPtr data, int dataSize)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d);
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

		public _7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_171c1dd1561f4f1abe83f2c373713a8d);
		}
	}
}
