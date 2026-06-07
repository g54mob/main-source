using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad FromInterop(IntPtr data, int dataSize)
		{
			return default(_2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad);
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

		public static void Serialize(_2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2ac70e36146e3d04582a2f11047c9b73_6435f71f7257420f86a45e32986f6cad);
		}
	}
}
