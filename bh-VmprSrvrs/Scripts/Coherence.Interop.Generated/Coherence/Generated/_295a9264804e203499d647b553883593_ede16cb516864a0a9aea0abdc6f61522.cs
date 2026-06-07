using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522 FromInterop(IntPtr data, int dataSize)
		{
			return default(_295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522);
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

		public static void Serialize(_295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_295a9264804e203499d647b553883593_ede16cb516864a0a9aea0abdc6f61522);
		}
	}
}
