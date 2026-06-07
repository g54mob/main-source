using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62 FromInterop(IntPtr data, int dataSize)
		{
			return default(_84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62);
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

		public static void Serialize(_84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_84196e96321527a4dbad6b98d42ee58f_23f0b6a6a8fc4a919e4d37faeb054a62);
		}
	}
}
