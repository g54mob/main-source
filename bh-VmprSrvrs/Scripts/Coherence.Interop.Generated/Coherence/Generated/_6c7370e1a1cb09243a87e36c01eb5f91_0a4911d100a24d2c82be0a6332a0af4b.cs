using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b);
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

		public static void Serialize(_6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_0a4911d100a24d2c82be0a6332a0af4b);
		}
	}
}
