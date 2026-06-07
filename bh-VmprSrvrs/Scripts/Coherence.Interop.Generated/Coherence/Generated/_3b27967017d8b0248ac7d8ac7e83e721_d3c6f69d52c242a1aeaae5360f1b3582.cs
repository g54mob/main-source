using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582);
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

		public static void Serialize(_3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3b27967017d8b0248ac7d8ac7e83e721_d3c6f69d52c242a1aeaae5360f1b3582);
		}
	}
}
