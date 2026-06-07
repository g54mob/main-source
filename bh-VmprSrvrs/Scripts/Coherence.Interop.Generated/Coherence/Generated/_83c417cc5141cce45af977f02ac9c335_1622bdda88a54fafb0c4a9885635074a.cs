using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a FromInterop(IntPtr data, int dataSize)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a);
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

		public static void Serialize(_83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_1622bdda88a54fafb0c4a9885635074a);
		}
	}
}
