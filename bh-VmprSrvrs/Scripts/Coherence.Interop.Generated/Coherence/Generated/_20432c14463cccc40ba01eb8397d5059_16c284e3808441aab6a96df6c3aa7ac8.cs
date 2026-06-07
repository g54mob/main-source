using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8);
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

		public _20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20432c14463cccc40ba01eb8397d5059_16c284e3808441aab6a96df6c3aa7ac8);
		}
	}
}
