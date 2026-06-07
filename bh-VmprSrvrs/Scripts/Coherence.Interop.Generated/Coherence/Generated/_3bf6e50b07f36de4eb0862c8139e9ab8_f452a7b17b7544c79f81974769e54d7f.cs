using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f FromInterop(IntPtr data, int dataSize)
		{
			return default(_3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f);
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

		public _3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3bf6e50b07f36de4eb0862c8139e9ab8_f452a7b17b7544c79f81974769e54d7f);
		}
	}
}
