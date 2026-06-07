using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c FromInterop(IntPtr data, int dataSize)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c);
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

		public _e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_eb578d3cbfdb4d34900ede4847d2ba8c);
		}
	}
}
