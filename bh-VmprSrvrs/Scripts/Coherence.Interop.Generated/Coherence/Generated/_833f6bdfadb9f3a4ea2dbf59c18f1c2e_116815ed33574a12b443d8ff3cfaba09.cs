using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09 FromInterop(IntPtr data, int dataSize)
		{
			return default(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09);
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

		public _833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_116815ed33574a12b443d8ff3cfaba09);
		}
	}
}
