using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178);
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

		public static void Serialize(_c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c7ebef2d63252f54a8c38b1176c3d54c_ebd3ee563dfe43f0bd11933ff11e1178);
		}
	}
}
