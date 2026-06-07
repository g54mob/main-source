using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e FromInterop(IntPtr data, int dataSize)
		{
			return default(_3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e);
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

		public _3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3c697731337d91d44840227ca0707343_ca7a34d81f654324beef4415305f4c8e);
		}
	}
}
