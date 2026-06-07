using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece FromInterop(IntPtr data, int dataSize)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece);
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

		public static void Serialize(_e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_d583ee0c467f4cf6a17be8325dc8cece);
		}
	}
}
