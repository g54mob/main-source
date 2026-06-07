using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;
		}

		public long startingSimFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d FromInterop(IntPtr data, int dataSize)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d);
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

		public _ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ffcb595f3781e1b4bbf128d57f1cd754_b52ea18f558b475d9ca1dd96297b002d);
		}
	}
}
