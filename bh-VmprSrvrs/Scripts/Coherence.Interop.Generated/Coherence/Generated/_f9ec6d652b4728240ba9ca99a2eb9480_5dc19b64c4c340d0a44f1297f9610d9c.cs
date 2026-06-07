using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c FromInterop(IntPtr data, int dataSize)
		{
			return default(_f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c);
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

		public _f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f9ec6d652b4728240ba9ca99a2eb9480_5dc19b64c4c340d0a44f1297f9610d9c);
		}
	}
}
