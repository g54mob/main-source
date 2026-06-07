using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;
		}

		public long startingSimFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e FromInterop(IntPtr data, int dataSize)
		{
			return default(_4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e);
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

		public _4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4d19d6a76ead5464e85fc9182c2b9614_c639956aeb48408f86cb5d62d247952e);
		}
	}
}
