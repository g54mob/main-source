using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float x;

			[FieldOffset(4)]
			public float y;

			[FieldOffset(8)]
			public float delay;
		}

		public float x;

		public float y;

		public float delay;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365 FromInterop(IntPtr data, int dataSize)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365);
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

		public _398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365(Entity entity, float x, float y, float delay)
		{
			this.x = 0f;
			this.y = 0f;
			this.delay = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_2004d0a08f65487ab5bf2e91cca89365);
		}
	}
}
