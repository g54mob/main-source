using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb);
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

		public static void Serialize(_a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2c9116f3af6dc64dab56b96cdecca53_3fac473a154c44f69103d15df026d9eb);
		}
	}
}
