using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d FromInterop(IntPtr data, int dataSize)
		{
			return default(_dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d);
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

		public static void Serialize(_dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_dce3c45c77e3fa5448190d013d3553a9_4b0a8bf61c43482d9d4be2b65c9ae18d);
		}
	}
}
