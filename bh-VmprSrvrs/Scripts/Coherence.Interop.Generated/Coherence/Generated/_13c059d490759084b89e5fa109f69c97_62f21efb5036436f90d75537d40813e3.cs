using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3);
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

		public static void Serialize(_13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_13c059d490759084b89e5fa109f69c97_62f21efb5036436f90d75537d40813e3);
		}
	}
}
