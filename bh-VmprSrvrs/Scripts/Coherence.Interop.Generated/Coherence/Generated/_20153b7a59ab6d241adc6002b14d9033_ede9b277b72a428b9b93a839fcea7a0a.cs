using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a FromInterop(IntPtr data, int dataSize)
		{
			return default(_20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a);
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

		public static void Serialize(_20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20153b7a59ab6d241adc6002b14d9033_ede9b277b72a428b9b93a839fcea7a0a);
		}
	}
}
