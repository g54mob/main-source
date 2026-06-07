using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d FromInterop(IntPtr data, int dataSize)
		{
			return default(_114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d);
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

		public _114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_114f9383c31fb044997cca6287778919_58012b009ad944feb4cbd1518f47453d);
		}
	}
}
