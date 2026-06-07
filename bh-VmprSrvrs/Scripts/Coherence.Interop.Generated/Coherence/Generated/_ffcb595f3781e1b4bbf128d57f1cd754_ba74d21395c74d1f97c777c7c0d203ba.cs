using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba FromInterop(IntPtr data, int dataSize)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba);
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

		public _ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_ba74d21395c74d1f97c777c7c0d203ba);
		}
	}
}
