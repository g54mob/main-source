using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9);
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

		public static void Serialize(_af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af6505b3805b9c5449b68712394f0392_7c96677859e34631888737afb27fb1d9);
		}
	}
}
