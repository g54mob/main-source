using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d FromInterop(IntPtr data, int dataSize)
		{
			return default(_af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d);
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

		public static void Serialize(_af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af37317ba36dc2e49a38df6db1a24aff_8f607f38dd28493894e4b9eb0107149d);
		}
	}
}
