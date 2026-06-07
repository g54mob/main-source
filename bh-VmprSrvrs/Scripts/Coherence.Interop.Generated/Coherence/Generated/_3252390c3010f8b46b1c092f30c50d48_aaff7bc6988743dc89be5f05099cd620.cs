using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620);
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

		public _3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3252390c3010f8b46b1c092f30c50d48_aaff7bc6988743dc89be5f05099cd620);
		}
	}
}
