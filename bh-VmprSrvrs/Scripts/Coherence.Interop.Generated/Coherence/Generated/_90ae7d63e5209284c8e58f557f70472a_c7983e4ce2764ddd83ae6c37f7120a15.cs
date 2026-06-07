using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15 FromInterop(IntPtr data, int dataSize)
		{
			return default(_90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15);
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

		public static void Serialize(_90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_90ae7d63e5209284c8e58f557f70472a_c7983e4ce2764ddd83ae6c37f7120a15);
		}
	}
}
