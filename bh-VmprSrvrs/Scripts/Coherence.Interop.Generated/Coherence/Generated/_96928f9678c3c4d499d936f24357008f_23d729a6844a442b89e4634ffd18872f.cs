using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f FromInterop(IntPtr data, int dataSize)
		{
			return default(_96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f);
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

		public _96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_96928f9678c3c4d499d936f24357008f_23d729a6844a442b89e4634ffd18872f);
		}
	}
}
