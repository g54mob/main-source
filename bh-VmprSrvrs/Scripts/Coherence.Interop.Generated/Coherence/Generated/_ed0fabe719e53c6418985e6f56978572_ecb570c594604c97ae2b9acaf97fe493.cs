using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493);
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

		public static void Serialize(_ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ed0fabe719e53c6418985e6f56978572_ecb570c594604c97ae2b9acaf97fe493);
		}
	}
}
