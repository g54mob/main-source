using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a FromInterop(IntPtr data, int dataSize)
		{
			return default(_ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a);
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

		public static void Serialize(_ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ac94286428b6bb341b78167f99ef7ffa_19f47b7f780e4c7a8205633517dcbe0a);
		}
	}
}
