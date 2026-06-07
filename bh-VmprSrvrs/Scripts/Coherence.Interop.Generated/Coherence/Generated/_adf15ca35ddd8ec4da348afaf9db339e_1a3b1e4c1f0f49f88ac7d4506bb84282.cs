using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282 FromInterop(IntPtr data, int dataSize)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282);
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

		public static void Serialize(_adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_adf15ca35ddd8ec4da348afaf9db339e_1a3b1e4c1f0f49f88ac7d4506bb84282);
		}
	}
}
