using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8);
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

		public static void Serialize(_2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_80a3487f81d94cb4a958a793f5d101d8);
		}
	}
}
