using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c FromInterop(IntPtr data, int dataSize)
		{
			return default(_ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c);
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

		public static void Serialize(_ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ffd05246d30c66048a844398cd3323bd_538521e732f04ea5a4f55cfde8d5b98c);
		}
	}
}
