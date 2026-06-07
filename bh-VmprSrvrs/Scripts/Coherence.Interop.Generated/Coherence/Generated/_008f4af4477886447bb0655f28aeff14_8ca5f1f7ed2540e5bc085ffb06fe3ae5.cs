using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5);
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

		public _008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_008f4af4477886447bb0655f28aeff14_8ca5f1f7ed2540e5bc085ffb06fe3ae5);
		}
	}
}
