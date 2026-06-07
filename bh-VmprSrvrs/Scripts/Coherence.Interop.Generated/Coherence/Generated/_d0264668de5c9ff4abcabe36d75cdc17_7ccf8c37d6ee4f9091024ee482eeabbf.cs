using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf FromInterop(IntPtr data, int dataSize)
		{
			return default(_d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf);
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

		public static void Serialize(_d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d0264668de5c9ff4abcabe36d75cdc17_7ccf8c37d6ee4f9091024ee482eeabbf);
		}
	}
}
