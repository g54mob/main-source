using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d);
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

		public _7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_e48d4c6df2d34c26a54abede3f16ac1d);
		}
	}
}
