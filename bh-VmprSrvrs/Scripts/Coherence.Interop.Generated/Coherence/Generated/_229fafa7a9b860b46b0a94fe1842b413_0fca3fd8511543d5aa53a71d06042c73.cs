using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73 FromInterop(IntPtr data, int dataSize)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73);
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

		public _229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_0fca3fd8511543d5aa53a71d06042c73);
		}
	}
}
