using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f FromInterop(IntPtr data, int dataSize)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f);
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

		public static void Serialize(_57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_7e8f8f3ec4874d77846e521dd11b665f);
		}
	}
}
