using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975 FromInterop(IntPtr data, int dataSize)
		{
			return default(_edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975);
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

		public static void Serialize(_edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_edbd757050de22342b33115a0af3fa78_b8bdf9ab1a814d6f9307f281f62ca975);
		}
	}
}
