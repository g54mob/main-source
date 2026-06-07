using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730);
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

		public static void Serialize(_9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9bd75945dd32d304aa9124e8a1764764_c115b4c7f46045658ebe739ec1828730);
		}
	}
}
