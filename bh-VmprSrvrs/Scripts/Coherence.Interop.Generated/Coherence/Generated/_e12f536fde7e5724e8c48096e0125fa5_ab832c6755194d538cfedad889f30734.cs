using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734);
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

		public static void Serialize(_e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e12f536fde7e5724e8c48096e0125fa5_ab832c6755194d538cfedad889f30734);
		}
	}
}
