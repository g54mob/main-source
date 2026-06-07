using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c FromInterop(IntPtr data, int dataSize)
		{
			return default(_51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c);
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

		public _51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_51689b3267e6c0d459907e8aeca19cdd_34c49a2510624327b411e4b93106559c);
		}
	}
}
