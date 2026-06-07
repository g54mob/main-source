using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e FromInterop(IntPtr data, int dataSize)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e);
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

		public _f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_8e523f9cef2e4c0c95d28e5203b65d8e);
		}
	}
}
