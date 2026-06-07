using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905);
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

		public static void Serialize(_7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7415a3957d9a5624b86fba36b08dbae6_03a6eb3622284b3abc5542635f1d7905);
		}
	}
}
