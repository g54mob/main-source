using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d FromInterop(IntPtr data, int dataSize)
		{
			return default(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d);
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

		public static void Serialize(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_833f6bdfadb9f3a4ea2dbf59c18f1c2e_d573d356bccc42cba7b248d54b1f004d);
		}
	}
}
