using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public ByteArray serializedEnemyTypes;

			[FieldOffset(24)]
			public int voteTarget;
		}

		public long startingSimFrame;

		public byte[] serializedEnemyTypes;

		public int voteTarget;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83);
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

		public _e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83(Entity entity, long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
			this.startingSimFrame = 0L;
			this.serializedEnemyTypes = null;
			this.voteTarget = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e1497f19703ce734bbe3e00dc1410741_667bd1c62fb14ea8a832d796d5db6c83);
		}
	}
}
