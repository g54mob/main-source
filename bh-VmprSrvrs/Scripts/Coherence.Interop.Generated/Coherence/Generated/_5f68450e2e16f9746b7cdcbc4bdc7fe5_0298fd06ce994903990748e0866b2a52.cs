using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52);
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

		public _5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5f68450e2e16f9746b7cdcbc4bdc7fe5_0298fd06ce994903990748e0866b2a52);
		}
	}
}
