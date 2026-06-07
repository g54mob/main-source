using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22);
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

		public static void Serialize(_ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ea0b5d709666b184698de4af947a8def_9213fa495f6d43daa5056cafe42e7b22);
		}
	}
}
