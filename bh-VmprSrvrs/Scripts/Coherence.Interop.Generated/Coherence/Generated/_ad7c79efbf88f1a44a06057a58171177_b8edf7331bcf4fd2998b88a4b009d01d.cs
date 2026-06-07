using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d);
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

		public static void Serialize(_ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad7c79efbf88f1a44a06057a58171177_b8edf7331bcf4fd2998b88a4b009d01d);
		}
	}
}
