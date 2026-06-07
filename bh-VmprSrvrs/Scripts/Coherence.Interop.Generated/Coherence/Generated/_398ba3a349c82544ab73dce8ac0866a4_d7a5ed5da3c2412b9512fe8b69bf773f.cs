using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f FromInterop(IntPtr data, int dataSize)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f);
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

		public static void Serialize(_398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_d7a5ed5da3c2412b9512fe8b69bf773f);
		}
	}
}
