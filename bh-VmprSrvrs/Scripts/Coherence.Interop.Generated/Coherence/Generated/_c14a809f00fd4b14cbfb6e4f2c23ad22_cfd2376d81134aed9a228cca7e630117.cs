using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117);
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

		public _c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_cfd2376d81134aed9a228cca7e630117);
		}
	}
}
