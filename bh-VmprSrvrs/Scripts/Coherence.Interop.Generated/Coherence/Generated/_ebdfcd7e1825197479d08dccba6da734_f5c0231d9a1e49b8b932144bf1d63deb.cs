using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb FromInterop(IntPtr data, int dataSize)
		{
			return default(_ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb);
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

		public static void Serialize(_ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ebdfcd7e1825197479d08dccba6da734_f5c0231d9a1e49b8b932144bf1d63deb);
		}
	}
}
