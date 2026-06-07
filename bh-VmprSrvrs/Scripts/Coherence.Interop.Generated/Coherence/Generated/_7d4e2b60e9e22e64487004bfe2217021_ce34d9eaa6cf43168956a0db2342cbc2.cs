using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2);
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

		public _7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7d4e2b60e9e22e64487004bfe2217021_ce34d9eaa6cf43168956a0db2342cbc2);
		}
	}
}
