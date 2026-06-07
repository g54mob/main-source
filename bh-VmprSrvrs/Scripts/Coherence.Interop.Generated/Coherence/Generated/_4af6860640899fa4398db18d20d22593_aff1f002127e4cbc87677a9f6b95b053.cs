using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053);
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

		public _4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4af6860640899fa4398db18d20d22593_aff1f002127e4cbc87677a9f6b95b053);
		}
	}
}
