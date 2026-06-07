using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce FromInterop(IntPtr data, int dataSize)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce);
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

		public static void Serialize(_e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e896f05866b72d44a9d8a14ae0889cc5_6bc8b748778c48adaf31a5fcbacf47ce);
		}
	}
}
