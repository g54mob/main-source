using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee FromInterop(IntPtr data, int dataSize)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee);
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

		public _fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_e8ae3946c84c4f7bbac92e2a986b62ee);
		}
	}
}
