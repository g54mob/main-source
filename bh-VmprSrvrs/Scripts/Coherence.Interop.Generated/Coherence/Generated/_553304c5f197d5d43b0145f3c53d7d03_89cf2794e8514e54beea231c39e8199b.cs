using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b FromInterop(IntPtr data, int dataSize)
		{
			return default(_553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b);
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

		public _553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_553304c5f197d5d43b0145f3c53d7d03_89cf2794e8514e54beea231c39e8199b);
		}
	}
}
