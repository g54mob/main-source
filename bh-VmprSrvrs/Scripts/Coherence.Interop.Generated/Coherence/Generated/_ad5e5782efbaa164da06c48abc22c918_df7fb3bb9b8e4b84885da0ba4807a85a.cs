using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a);
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

		public _ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_df7fb3bb9b8e4b84885da0ba4807a85a);
		}
	}
}
