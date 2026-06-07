using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef FromInterop(IntPtr data, int dataSize)
		{
			return default(_885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef);
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

		public static void Serialize(_885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_885006f2aca335e4cb9483009498af66_f1c5a6e1e45f45e5bfe1d48257a37bef);
		}
	}
}
