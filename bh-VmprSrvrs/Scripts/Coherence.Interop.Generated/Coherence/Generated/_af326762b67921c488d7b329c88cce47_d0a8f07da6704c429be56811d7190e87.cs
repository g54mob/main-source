using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87 FromInterop(IntPtr data, int dataSize)
		{
			return default(_af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87);
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

		public _af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af326762b67921c488d7b329c88cce47_d0a8f07da6704c429be56811d7190e87);
		}
	}
}
