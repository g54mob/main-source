using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208 FromInterop(IntPtr data, int dataSize)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208);
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

		public _36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_36b24034ec1a7e64c8dc9a33bafd6360_3db5df6db22a4b9b8bc3c68550fa3208);
		}
	}
}
