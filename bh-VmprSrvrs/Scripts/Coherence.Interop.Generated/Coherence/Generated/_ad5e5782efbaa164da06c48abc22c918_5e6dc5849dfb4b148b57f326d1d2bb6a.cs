using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a);
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

		public static void Serialize(_ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_5e6dc5849dfb4b148b57f326d1d2bb6a);
		}
	}
}
