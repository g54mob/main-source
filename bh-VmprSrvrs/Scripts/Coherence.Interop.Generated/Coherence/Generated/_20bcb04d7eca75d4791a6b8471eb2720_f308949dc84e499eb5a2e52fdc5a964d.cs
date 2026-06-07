using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d FromInterop(IntPtr data, int dataSize)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d);
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

		public _20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_f308949dc84e499eb5a2e52fdc5a964d);
		}
	}
}
