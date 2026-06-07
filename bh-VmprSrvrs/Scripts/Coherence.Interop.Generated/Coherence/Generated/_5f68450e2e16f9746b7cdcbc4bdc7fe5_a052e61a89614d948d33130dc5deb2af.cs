using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af FromInterop(IntPtr data, int dataSize)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af);
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

		public static void Serialize(_5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_a052e61a89614d948d33130dc5deb2af);
		}
	}
}
