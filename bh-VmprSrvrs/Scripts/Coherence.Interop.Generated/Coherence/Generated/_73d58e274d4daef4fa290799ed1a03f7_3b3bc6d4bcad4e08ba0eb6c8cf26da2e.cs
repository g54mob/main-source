using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e FromInterop(IntPtr data, int dataSize)
		{
			return default(_73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e);
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

		public static void Serialize(_73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73d58e274d4daef4fa290799ed1a03f7_3b3bc6d4bcad4e08ba0eb6c8cf26da2e);
		}
	}
}
