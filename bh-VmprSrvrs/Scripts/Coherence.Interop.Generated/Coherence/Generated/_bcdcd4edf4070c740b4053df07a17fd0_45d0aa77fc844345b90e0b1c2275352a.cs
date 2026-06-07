using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a FromInterop(IntPtr data, int dataSize)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a);
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

		public _bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_45d0aa77fc844345b90e0b1c2275352a);
		}
	}
}
