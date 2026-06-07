using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707 FromInterop(IntPtr data, int dataSize)
		{
			return default(_93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707);
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

		public static void Serialize(_93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93146e3daa128b749b312aadee0d3900_a0a09c657e6e4d26b52bcc38d9602707);
		}
	}
}
