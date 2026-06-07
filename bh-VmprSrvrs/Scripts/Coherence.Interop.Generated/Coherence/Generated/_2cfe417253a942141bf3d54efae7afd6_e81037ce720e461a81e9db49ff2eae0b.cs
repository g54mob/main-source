using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte shouldSwapToLevelUpUi;

			[FieldOffset(9)]
			public byte adjustXpFactors;

			[FieldOffset(10)]
			public Entity activeCharacter;

			[FieldOffset(14)]
			public ByteArray chosenWeapons;

			[FieldOffset(30)]
			public ByteArray chosenItems;

			[FieldOffset(46)]
			public byte hasAmuletTargets;

			[FieldOffset(47)]
			public ByteArray limitBreaks;
		}

		public long startingSimFrame;

		public bool shouldSwapToLevelUpUi;

		public bool adjustXpFactors;

		public Entity activeCharacter;

		public byte[] chosenWeapons;

		public byte[] chosenItems;

		public bool hasAmuletTargets;

		public byte[] limitBreaks;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b);
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

		public _2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b(Entity entity, long startingSimFrame, bool shouldSwapToLevelUpUi, bool adjustXpFactors, Entity activeCharacter, byte[] chosenWeapons, byte[] chosenItems, bool hasAmuletTargets, byte[] limitBreaks)
		{
			this.startingSimFrame = 0L;
			this.shouldSwapToLevelUpUi = false;
			this.adjustXpFactors = false;
			this.activeCharacter = default(Entity);
			this.chosenWeapons = null;
			this.chosenItems = null;
			this.hasAmuletTargets = false;
			this.limitBreaks = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_e81037ce720e461a81e9db49ff2eae0b);
		}
	}
}
