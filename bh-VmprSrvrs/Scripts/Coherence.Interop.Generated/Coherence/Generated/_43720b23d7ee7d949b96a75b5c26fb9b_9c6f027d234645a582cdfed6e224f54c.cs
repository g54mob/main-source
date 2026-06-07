using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c FromInterop(IntPtr data, int dataSize)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c);
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

		public static void Serialize(_43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_9c6f027d234645a582cdfed6e224f54c);
		}
	}
}
