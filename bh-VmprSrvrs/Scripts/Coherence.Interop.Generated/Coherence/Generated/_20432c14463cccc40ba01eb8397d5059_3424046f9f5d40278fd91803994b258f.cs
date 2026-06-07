using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte instantRevival;
		}

		public long startingSimFrame;

		public bool instantRevival;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f FromInterop(IntPtr data, int dataSize)
		{
			return default(_20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f);
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

		public _20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20432c14463cccc40ba01eb8397d5059_3424046f9f5d40278fd91803994b258f);
		}
	}
}
