using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62);
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

		public _9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9732cef7d5345fb44854a30653f5f576_69d7f8a146394c6491b2f098d5b2ac62);
		}
	}
}
