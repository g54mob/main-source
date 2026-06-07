using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9);
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

		public _af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af326762b67921c488d7b329c88cce47_b8e99d69a5f74056b078a6555d6da4e9);
		}
	}
}
