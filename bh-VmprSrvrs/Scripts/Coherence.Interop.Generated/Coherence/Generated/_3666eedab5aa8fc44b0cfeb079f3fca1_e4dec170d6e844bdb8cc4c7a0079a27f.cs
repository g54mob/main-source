using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f FromInterop(IntPtr data, int dataSize)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f);
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

		public _3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_e4dec170d6e844bdb8cc4c7a0079a27f);
		}
	}
}
