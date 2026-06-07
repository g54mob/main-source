using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0);
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

		public _bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_4a4d09b5843f4bd7bbc6b935887fc2d0);
		}
	}
}
