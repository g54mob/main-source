using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a);
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

		public static void Serialize(_5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_ba059fc792a84bcc88318eb98fc95d5a);
		}
	}
}
