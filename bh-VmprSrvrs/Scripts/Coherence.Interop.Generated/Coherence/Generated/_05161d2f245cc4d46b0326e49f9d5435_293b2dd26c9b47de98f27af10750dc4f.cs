using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f FromInterop(IntPtr data, int dataSize)
		{
			return default(_05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f);
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

		public static void Serialize(_05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_05161d2f245cc4d46b0326e49f9d5435_293b2dd26c9b47de98f27af10750dc4f);
		}
	}
}
