using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d FromInterop(IntPtr data, int dataSize)
		{
			return default(_a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d);
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

		public static void Serialize(_a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a01d9cc6bba6e9a498898c00bc67d730_7d2717eb61a24d5880ae140e83e7047d);
		}
	}
}
