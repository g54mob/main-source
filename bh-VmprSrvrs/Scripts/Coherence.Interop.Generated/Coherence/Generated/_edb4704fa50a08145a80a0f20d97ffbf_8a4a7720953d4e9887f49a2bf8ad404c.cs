using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c FromInterop(IntPtr data, int dataSize)
		{
			return default(_edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c);
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

		public _edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_edb4704fa50a08145a80a0f20d97ffbf_8a4a7720953d4e9887f49a2bf8ad404c);
		}
	}
}
