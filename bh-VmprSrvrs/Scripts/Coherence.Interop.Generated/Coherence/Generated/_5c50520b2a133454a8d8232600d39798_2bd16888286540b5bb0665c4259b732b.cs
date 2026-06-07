using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b);
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

		public static void Serialize(_5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c50520b2a133454a8d8232600d39798_2bd16888286540b5bb0665c4259b732b);
		}
	}
}
