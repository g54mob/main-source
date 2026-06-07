using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c FromInterop(IntPtr data, int dataSize)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c);
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

		public _c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_1fcd564dfaa948d2b68207fab4632d2c);
		}
	}
}
