using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00);
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

		public _b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_2d547b5e2dec48bea36f8462950bcd00);
		}
	}
}
