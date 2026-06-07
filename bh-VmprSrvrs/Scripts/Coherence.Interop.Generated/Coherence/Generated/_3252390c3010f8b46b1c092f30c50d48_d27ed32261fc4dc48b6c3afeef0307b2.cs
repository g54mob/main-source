using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2);
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

		public static void Serialize(_3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3252390c3010f8b46b1c092f30c50d48_d27ed32261fc4dc48b6c3afeef0307b2);
		}
	}
}
