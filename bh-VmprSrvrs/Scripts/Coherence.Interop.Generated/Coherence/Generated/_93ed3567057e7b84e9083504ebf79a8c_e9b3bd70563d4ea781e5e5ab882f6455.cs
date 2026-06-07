using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455 FromInterop(IntPtr data, int dataSize)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455);
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

		public static void Serialize(_93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_e9b3bd70563d4ea781e5e5ab882f6455);
		}
	}
}
