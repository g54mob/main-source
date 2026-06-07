using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005);
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

		public static void Serialize(_8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8f67ec7a57d18d7499052510067d2812_abd86b9991b8428dafd88a4c8fc71005);
		}
	}
}
