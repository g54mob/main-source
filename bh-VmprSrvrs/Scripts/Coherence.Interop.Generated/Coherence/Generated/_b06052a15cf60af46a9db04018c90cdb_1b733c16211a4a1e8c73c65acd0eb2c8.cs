using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8);
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

		public _b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b06052a15cf60af46a9db04018c90cdb_1b733c16211a4a1e8c73c65acd0eb2c8);
		}
	}
}
