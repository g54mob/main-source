using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958);
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

		public _6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6cc9b126243967c42a13e9ca0e361dfd_86a6853c8a5741d88dcc512bd414b958);
		}
	}
}
