using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f FromInterop(IntPtr data, int dataSize)
		{
			return default(_cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f);
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

		public static void Serialize(_cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cd4879b07d15d29488f33871029780e7_a268320d5e9c484487ceb5b8baa09b1f);
		}
	}
}
