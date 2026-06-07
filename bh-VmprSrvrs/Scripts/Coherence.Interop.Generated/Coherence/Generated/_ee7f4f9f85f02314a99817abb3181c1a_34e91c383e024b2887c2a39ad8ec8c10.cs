using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10);
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

		public _ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_34e91c383e024b2887c2a39ad8ec8c10);
		}
	}
}
