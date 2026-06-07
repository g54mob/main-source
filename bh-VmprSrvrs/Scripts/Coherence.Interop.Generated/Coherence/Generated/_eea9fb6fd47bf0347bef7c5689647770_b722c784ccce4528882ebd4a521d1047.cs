using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047 FromInterop(IntPtr data, int dataSize)
		{
			return default(_eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047);
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

		public static void Serialize(_eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_eea9fb6fd47bf0347bef7c5689647770_b722c784ccce4528882ebd4a521d1047);
		}
	}
}
