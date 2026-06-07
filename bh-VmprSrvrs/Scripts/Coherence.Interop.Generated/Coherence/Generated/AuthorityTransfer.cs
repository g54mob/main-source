using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct AuthorityTransfer : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint newAuthority;

			[FieldOffset(4)]
			public byte accepted;

			[FieldOffset(5)]
			public int authorityType;
		}

		public uint newAuthority;

		public bool accepted;

		public int authorityType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static AuthorityTransfer FromInterop(IntPtr data, int dataSize)
		{
			return default(AuthorityTransfer);
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

		public AuthorityTransfer(Entity entity, uint newAuthority, bool accepted, int authorityType)
		{
			this.newAuthority = 0u;
			this.accepted = false;
			this.authorityType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(AuthorityTransfer commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static AuthorityTransfer Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(AuthorityTransfer);
		}
	}
}
