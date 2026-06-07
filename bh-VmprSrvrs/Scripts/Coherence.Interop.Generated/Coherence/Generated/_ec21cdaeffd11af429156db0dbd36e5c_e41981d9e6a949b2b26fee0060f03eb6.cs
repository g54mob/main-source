using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6);
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

		public static void Serialize(_ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ec21cdaeffd11af429156db0dbd36e5c_e41981d9e6a949b2b26fee0060f03eb6);
		}
	}
}
