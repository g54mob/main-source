using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f FromInterop(IntPtr data, int dataSize)
		{
			return default(_121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f);
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

		public static void Serialize(_121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_121d073f2831f1e4bb90e6e4015de963_8c5253cfcf904c8f957c7c6044a9801f);
		}
	}
}
