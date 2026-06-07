using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b FromInterop(IntPtr data, int dataSize)
		{
			return default(_07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b);
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

		public _07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_07c07874ac1476141b72bca779dea101_b921c7061ad146c4941a35c86ad7606b);
		}
	}
}
