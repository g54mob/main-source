using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56 FromInterop(IntPtr data, int dataSize)
		{
			return default(_33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56);
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

		public static void Serialize(_33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_33e4b18c0f36756458a803dbb0078c33_9030c340e14740878e66716c6324fb56);
		}
	}
}
