using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123 FromInterop(IntPtr data, int dataSize)
		{
			return default(_13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123);
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

		public _13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_13c059d490759084b89e5fa109f69c97_5d873bb02aa5452880f6e1d399e80123);
		}
	}
}
