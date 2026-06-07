using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5);
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

		public _93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_17fc78d41a7e410e83f4dd1c4edfbcb5);
		}
	}
}
