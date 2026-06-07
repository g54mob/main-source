using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f FromInterop(IntPtr data, int dataSize)
		{
			return default(_728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f);
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

		public _728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_728cd6037975de34a9c410d6903798fd_0f95d8dfa23840c681e904b2dc1ba09f);
		}
	}
}
