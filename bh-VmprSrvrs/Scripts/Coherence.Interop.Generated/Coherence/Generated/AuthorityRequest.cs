using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct AuthorityRequest : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint requester;

			[FieldOffset(4)]
			public int authorityType;
		}

		public uint requester;

		public int authorityType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static AuthorityRequest FromInterop(IntPtr data, int dataSize)
		{
			return default(AuthorityRequest);
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

		public AuthorityRequest(Entity entity, uint requester, int authorityType)
		{
			this.requester = 0u;
			this.authorityType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(AuthorityRequest commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static AuthorityRequest Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(AuthorityRequest);
		}
	}
}
