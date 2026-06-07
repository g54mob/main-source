using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e FromInterop(IntPtr data, int dataSize)
		{
			return default(_e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e);
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

		public _e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e12f536fde7e5724e8c48096e0125fa5_7e6fd786a8e04f8c9f054c4d55092f6e);
		}
	}
}
