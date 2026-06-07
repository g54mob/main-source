using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9);
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

		public static void Serialize(_63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_63b75bfcdf0aabe4d955e21fb4a8a741_8608480cebbd4719811f78d019ef58f9);
		}
	}
}
