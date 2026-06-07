using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb FromInterop(IntPtr data, int dataSize)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb);
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

		public _fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_b4c1a1fea97e4e8e94ca0fb52c8639bb);
		}
	}
}
