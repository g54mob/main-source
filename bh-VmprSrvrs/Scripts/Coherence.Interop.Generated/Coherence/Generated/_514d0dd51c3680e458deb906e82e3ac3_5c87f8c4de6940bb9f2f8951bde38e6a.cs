using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a FromInterop(IntPtr data, int dataSize)
		{
			return default(_514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a);
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

		public static void Serialize(_514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_514d0dd51c3680e458deb906e82e3ac3_5c87f8c4de6940bb9f2f8951bde38e6a);
		}
	}
}
