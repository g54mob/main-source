using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c FromInterop(IntPtr data, int dataSize)
		{
			return default(_a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c);
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

		public static void Serialize(_a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a86dbf590d04e0649bcc69d936d773b1_a20f62cb3fc3407f9b9b05fa2a34f78c);
		}
	}
}
