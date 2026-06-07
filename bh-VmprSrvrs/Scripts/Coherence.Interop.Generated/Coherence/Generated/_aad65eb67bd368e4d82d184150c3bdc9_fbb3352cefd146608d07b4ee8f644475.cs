using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475 FromInterop(IntPtr data, int dataSize)
		{
			return default(_aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475);
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

		public static void Serialize(_aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_aad65eb67bd368e4d82d184150c3bdc9_fbb3352cefd146608d07b4ee8f644475);
		}
	}
}
