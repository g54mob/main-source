using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long startingSimFrame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac FromInterop(IntPtr data, int dataSize)
		{
			return default(_90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac);
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

		public _90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_90bad6f3af15ab342805cd8a335ea1d0_83a8228e2a2f44ee8a3d2cb9d5e4c8ac);
		}
	}
}
