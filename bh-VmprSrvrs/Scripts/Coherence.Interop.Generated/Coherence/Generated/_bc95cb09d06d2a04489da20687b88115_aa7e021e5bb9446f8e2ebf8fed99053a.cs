using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a FromInterop(IntPtr data, int dataSize)
		{
			return default(_bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a);
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

		public static void Serialize(_bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bc95cb09d06d2a04489da20687b88115_aa7e021e5bb9446f8e2ebf8fed99053a);
		}
	}
}
