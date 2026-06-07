using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float randomValue;
		}

		public float randomValue;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b);
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

		public _a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b(Entity entity, float randomValue)
		{
			this.randomValue = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2ba1be4e76d1384392b473fe6743bbe_8d2bdad93304437f9f5d95bad30b156b);
		}
	}
}
