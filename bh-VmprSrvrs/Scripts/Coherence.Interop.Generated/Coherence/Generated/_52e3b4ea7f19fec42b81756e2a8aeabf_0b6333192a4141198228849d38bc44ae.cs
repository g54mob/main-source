using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae FromInterop(IntPtr data, int dataSize)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae);
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

		public static void Serialize(_52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_52e3b4ea7f19fec42b81756e2a8aeabf_0b6333192a4141198228849d38bc44ae);
		}
	}
}
