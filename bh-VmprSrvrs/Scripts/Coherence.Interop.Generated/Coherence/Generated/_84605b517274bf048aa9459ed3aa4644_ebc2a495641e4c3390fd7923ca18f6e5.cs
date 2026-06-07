using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5);
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

		public static void Serialize(_84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_84605b517274bf048aa9459ed3aa4644_ebc2a495641e4c3390fd7923ca18f6e5);
		}
	}
}
