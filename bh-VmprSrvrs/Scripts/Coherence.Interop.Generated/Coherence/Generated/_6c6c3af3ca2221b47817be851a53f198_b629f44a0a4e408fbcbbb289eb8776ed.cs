using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed);
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

		public _6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c6c3af3ca2221b47817be851a53f198_b629f44a0a4e408fbcbbb289eb8776ed);
		}
	}
}
