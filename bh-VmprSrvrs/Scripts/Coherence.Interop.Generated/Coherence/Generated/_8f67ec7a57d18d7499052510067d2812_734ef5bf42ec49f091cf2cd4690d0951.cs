using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951);
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

		public _8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8f67ec7a57d18d7499052510067d2812_734ef5bf42ec49f091cf2cd4690d0951);
		}
	}
}
