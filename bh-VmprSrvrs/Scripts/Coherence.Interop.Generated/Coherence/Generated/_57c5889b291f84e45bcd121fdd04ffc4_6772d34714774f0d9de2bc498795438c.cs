using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c FromInterop(IntPtr data, int dataSize)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c);
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

		public _57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_6772d34714774f0d9de2bc498795438c);
		}
	}
}
