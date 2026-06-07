using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5);
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

		public static void Serialize(_ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad66d4cdd4f444e4d8cbb008b237af51_5c5c33f78e7d4b6095a42e80829641a5);
		}
	}
}
