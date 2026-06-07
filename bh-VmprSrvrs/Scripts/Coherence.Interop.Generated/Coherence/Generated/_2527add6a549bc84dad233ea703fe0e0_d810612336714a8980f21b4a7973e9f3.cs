using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3);
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

		public static void Serialize(_2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2527add6a549bc84dad233ea703fe0e0_d810612336714a8980f21b4a7973e9f3);
		}
	}
}
