using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c FromInterop(IntPtr data, int dataSize)
		{
			return default(_e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c);
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

		public static void Serialize(_e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e62ed9cb975690c448d3c0ba8eb14e73_fadb8f5fbf4c44a0a4167375afb0fc3c);
		}
	}
}
