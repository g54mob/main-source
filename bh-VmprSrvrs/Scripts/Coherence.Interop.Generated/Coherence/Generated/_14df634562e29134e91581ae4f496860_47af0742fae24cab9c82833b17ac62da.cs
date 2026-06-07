using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da FromInterop(IntPtr data, int dataSize)
		{
			return default(_14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da);
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

		public _14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_14df634562e29134e91581ae4f496860_47af0742fae24cab9c82833b17ac62da);
		}
	}
}
