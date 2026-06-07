using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95);
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

		public static void Serialize(_a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a5eaccd284614574a98c680e57736a01_fcb2f30822fd4fd5a582b5c38801ca95);
		}
	}
}
