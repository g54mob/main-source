using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a);
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

		public static void Serialize(_7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_9e760065e8c74a8bac52e41ce382928a);
		}
	}
}
