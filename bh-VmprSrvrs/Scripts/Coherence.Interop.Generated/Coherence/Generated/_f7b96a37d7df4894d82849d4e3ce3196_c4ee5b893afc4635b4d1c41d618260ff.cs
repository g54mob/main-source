using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff FromInterop(IntPtr data, int dataSize)
		{
			return default(_f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff);
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

		public static void Serialize(_f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f7b96a37d7df4894d82849d4e3ce3196_c4ee5b893afc4635b4d1c41d618260ff);
		}
	}
}
