using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public ByteArray hostPickupCountChunk;

			[FieldOffset(16)]
			public int expectedChunks;
		}

		public byte[] hostPickupCountChunk;

		public int expectedChunks;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369);
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

		public _f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369(Entity entity, byte[] hostPickupCountChunk, int expectedChunks)
		{
			this.hostPickupCountChunk = null;
			this.expectedChunks = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_4098aca73afa4076a44d9a9edc8c6369);
		}
	}
}
