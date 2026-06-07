using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b FromInterop(IntPtr data, int dataSize)
		{
			return default(_6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b);
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

		public _6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6ef7c0baad4dee54584188b4e3f62f97_ad1c07d5d4734448aaba9c774196a12b);
		}
	}
}
