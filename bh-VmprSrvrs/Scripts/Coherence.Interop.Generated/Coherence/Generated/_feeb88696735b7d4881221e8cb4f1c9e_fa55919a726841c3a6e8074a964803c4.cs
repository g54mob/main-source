using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4);
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

		public static void Serialize(_feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_feeb88696735b7d4881221e8cb4f1c9e_fa55919a726841c3a6e8074a964803c4);
		}
	}
}
