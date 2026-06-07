using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27);
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

		public static void Serialize(_4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4201c659f38294943adf4fd75ad8fff8_a06c834700c640a0891bd1e81ce3ce27);
		}
	}
}
