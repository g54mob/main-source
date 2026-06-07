using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8);
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

		public _46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_46452e97f07a1c9479cb3124d27561ef_d8623b0a4e494c6199bab040195b56d8);
		}
	}
}
