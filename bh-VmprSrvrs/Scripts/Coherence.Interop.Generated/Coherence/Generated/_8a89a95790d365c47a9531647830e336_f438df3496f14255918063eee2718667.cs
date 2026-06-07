using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity openingPlayer;

			[FieldOffset(12)]
			public ByteArray serializedWeapons;

			[FieldOffset(28)]
			public ByteArray serializedItems;
		}

		public long startingSimFrame;

		public Entity openingPlayer;

		public byte[] serializedWeapons;

		public byte[] serializedItems;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667);
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

		public _8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667(Entity entity, long startingSimFrame, Entity openingPlayer, byte[] serializedWeapons, byte[] serializedItems)
		{
			this.startingSimFrame = 0L;
			this.openingPlayer = default(Entity);
			this.serializedWeapons = null;
			this.serializedItems = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8a89a95790d365c47a9531647830e336_f438df3496f14255918063eee2718667);
		}
	}
}
