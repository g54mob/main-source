using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077);
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

		public _7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7da04e07cab36834bb9c2cbe01890c4e_574f9efc295741ee96b4ee8850c26077);
		}
	}
}
