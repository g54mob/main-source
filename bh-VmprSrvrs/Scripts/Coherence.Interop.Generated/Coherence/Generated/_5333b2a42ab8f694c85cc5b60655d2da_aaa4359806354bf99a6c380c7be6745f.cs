using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f FromInterop(IntPtr data, int dataSize)
		{
			return default(_5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f);
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

		public _5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5333b2a42ab8f694c85cc5b60655d2da_aaa4359806354bf99a6c380c7be6745f);
		}
	}
}
