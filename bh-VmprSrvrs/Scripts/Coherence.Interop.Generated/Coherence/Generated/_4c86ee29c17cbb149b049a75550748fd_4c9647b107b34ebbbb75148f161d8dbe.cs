using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe FromInterop(IntPtr data, int dataSize)
		{
			return default(_4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe);
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

		public static void Serialize(_4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4c86ee29c17cbb149b049a75550748fd_4c9647b107b34ebbbb75148f161d8dbe);
		}
	}
}
