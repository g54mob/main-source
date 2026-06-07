using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab FromInterop(IntPtr data, int dataSize)
		{
			return default(_07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab);
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

		public static void Serialize(_07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_07c07874ac1476141b72bca779dea101_deea6673e4784f1e896841f1c10013ab);
		}
	}
}
