using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f FromInterop(IntPtr data, int dataSize)
		{
			return default(_c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f);
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

		public static void Serialize(_c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c3c80d0ca1f1bfe4ea48bb2f3c812116_ce88574154e844f2b50a9582bde96d7f);
		}
	}
}
