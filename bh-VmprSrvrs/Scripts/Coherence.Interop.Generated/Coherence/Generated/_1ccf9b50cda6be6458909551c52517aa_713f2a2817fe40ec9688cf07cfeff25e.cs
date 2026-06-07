using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e);
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

		public static void Serialize(_1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ccf9b50cda6be6458909551c52517aa_713f2a2817fe40ec9688cf07cfeff25e);
		}
	}
}
