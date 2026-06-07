using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee FromInterop(IntPtr data, int dataSize)
		{
			return default(_344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee);
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

		public static void Serialize(_344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_344d002495933fb4f9c73b1849121f16_f4c70f7e9efb405da7bbf91d037125ee);
		}
	}
}
