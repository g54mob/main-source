using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5);
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

		public static void Serialize(_c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c9a9d977fdad5454babc00ddaab63396_59346ec7cec9426d95da7892f0dc3df5);
		}
	}
}
