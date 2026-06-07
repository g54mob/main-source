using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20 FromInterop(IntPtr data, int dataSize)
		{
			return default(_344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20);
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

		public _344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_344d002495933fb4f9c73b1849121f16_4ab934e442874551a71d499049af5f20);
		}
	}
}
