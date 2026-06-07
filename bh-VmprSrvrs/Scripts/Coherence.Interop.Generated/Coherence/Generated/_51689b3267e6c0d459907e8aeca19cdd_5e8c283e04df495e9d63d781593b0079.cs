using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079 FromInterop(IntPtr data, int dataSize)
		{
			return default(_51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079);
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

		public static void Serialize(_51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_51689b3267e6c0d459907e8aeca19cdd_5e8c283e04df495e9d63d781593b0079);
		}
	}
}
