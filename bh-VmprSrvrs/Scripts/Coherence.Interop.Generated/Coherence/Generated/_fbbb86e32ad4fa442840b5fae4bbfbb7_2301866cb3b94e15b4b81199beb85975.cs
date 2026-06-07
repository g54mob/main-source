using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975);
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

		public static void Serialize(_fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fbbb86e32ad4fa442840b5fae4bbfbb7_2301866cb3b94e15b4b81199beb85975);
		}
	}
}
