using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85);
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

		public static void Serialize(_b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_11ca1c9c07254b8e8cc7db02af9fbc85);
		}
	}
}
