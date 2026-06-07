using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3);
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

		public static void Serialize(_c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c08a8593fe6eb824fbe30d4fe2bfc958_f714af32940d4bdb934856969c2616a3);
		}
	}
}
