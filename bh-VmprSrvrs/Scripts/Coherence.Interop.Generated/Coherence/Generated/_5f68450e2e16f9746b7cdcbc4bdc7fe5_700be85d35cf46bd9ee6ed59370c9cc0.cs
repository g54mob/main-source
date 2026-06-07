using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0);
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

		public _5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_700be85d35cf46bd9ee6ed59370c9cc0);
		}
	}
}
