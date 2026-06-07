using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19);
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

		public static void Serialize(_7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7764e078a4b461f4f9a8b27880fcf7a1_491339f7c3ba4f76baee2e63ca7a9d19);
		}
	}
}
