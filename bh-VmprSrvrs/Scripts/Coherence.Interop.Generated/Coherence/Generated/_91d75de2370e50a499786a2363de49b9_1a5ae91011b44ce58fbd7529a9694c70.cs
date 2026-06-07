using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70 FromInterop(IntPtr data, int dataSize)
		{
			return default(_91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70);
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

		public static void Serialize(_91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_91d75de2370e50a499786a2363de49b9_1a5ae91011b44ce58fbd7529a9694c70);
		}
	}
}
