using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60);
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

		public static void Serialize(_ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ee1b1e31b3031ba44a3b2c6d948a324d_875af5d819fc43478e5a38a654bc6c60);
		}
	}
}
