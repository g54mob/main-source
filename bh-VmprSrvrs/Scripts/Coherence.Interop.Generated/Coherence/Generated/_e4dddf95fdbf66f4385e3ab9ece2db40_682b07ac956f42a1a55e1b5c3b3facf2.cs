using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2);
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

		public static void Serialize(_e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e4dddf95fdbf66f4385e3ab9ece2db40_682b07ac956f42a1a55e1b5c3b3facf2);
		}
	}
}
