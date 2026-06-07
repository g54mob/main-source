using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef FromInterop(IntPtr data, int dataSize)
		{
			return default(_78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef);
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

		public static void Serialize(_78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_78efd33b5fb46114c89a47714eeaea17_f4ae6ca39b324a6bb3424d6d70dcffef);
		}
	}
}
