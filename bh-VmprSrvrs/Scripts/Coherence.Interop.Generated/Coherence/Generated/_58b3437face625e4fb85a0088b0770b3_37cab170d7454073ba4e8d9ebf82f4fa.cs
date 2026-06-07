using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa FromInterop(IntPtr data, int dataSize)
		{
			return default(_58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa);
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

		public static void Serialize(_58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_58b3437face625e4fb85a0088b0770b3_37cab170d7454073ba4e8d9ebf82f4fa);
		}
	}
}
