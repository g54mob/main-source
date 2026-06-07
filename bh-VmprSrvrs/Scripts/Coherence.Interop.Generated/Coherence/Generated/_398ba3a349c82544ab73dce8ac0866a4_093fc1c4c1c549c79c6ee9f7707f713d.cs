using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d FromInterop(IntPtr data, int dataSize)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d);
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

		public _398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_398ba3a349c82544ab73dce8ac0866a4_093fc1c4c1c549c79c6ee9f7707f713d);
		}
	}
}
