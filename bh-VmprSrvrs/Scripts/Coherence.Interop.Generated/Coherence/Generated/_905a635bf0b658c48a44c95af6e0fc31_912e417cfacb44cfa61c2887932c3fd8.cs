using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8);
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

		public _905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_905a635bf0b658c48a44c95af6e0fc31_912e417cfacb44cfa61c2887932c3fd8);
		}
	}
}
