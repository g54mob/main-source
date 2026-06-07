using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33 FromInterop(IntPtr data, int dataSize)
		{
			return default(_248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33);
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

		public static void Serialize(_248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_248072836afe8c443b7a96b40d98ec63_dcfc9cff697b4fd780cebcbfeb8d0d33);
		}
	}
}
