using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8);
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

		public static void Serialize(_200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_200d36f836dbf3545888419ef7f622e1_36159b3b3c7646a2b6cb168fb29974d8);
		}
	}
}
