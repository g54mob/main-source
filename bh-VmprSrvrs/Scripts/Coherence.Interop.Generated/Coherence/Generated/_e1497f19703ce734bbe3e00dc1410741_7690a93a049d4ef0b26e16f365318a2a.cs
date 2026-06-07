using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a FromInterop(IntPtr data, int dataSize)
		{
			return default(_e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a);
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

		public static void Serialize(_e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e1497f19703ce734bbe3e00dc1410741_7690a93a049d4ef0b26e16f365318a2a);
		}
	}
}
