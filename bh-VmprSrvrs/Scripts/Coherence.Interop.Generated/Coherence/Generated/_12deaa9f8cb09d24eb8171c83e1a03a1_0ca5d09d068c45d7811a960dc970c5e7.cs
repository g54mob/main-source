using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7);
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

		public static void Serialize(_12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_12deaa9f8cb09d24eb8171c83e1a03a1_0ca5d09d068c45d7811a960dc970c5e7);
		}
	}
}
