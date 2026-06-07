using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity openingPlayer;

			[FieldOffset(12)]
			public Entity winningPlayer;

			[FieldOffset(16)]
			public ByteArray serializedPrizePairs;

			[FieldOffset(32)]
			public ByteArray serializedWeaponPrizes;

			[FieldOffset(48)]
			public int coins;

			[FieldOffset(52)]
			public byte quickTreasureAnim;

			[FieldOffset(53)]
			public ByteArray serializedTreasure;
		}

		public long startingSimFrame;

		public Entity openingPlayer;

		public Entity winningPlayer;

		public byte[] serializedPrizePairs;

		public byte[] serializedWeaponPrizes;

		public int coins;

		public bool quickTreasureAnim;

		public byte[] serializedTreasure;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11);
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

		public _7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11(Entity entity, long startingSimFrame, Entity openingPlayer, Entity winningPlayer, byte[] serializedPrizePairs, byte[] serializedWeaponPrizes, int coins, bool quickTreasureAnim, byte[] serializedTreasure)
		{
			this.startingSimFrame = 0L;
			this.openingPlayer = default(Entity);
			this.winningPlayer = default(Entity);
			this.serializedPrizePairs = null;
			this.serializedWeaponPrizes = null;
			this.coins = 0;
			this.quickTreasureAnim = false;
			this.serializedTreasure = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_86977c9971314cc4995b5390a9507d11);
		}
	}
}
