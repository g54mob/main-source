using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713 FromInterop(IntPtr data, int dataSize)
		{
			return default(_73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713);
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

		public static void Serialize(_73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73b814dc845c89941be1a604a3c13b05_36004cefb10940f88069b60cf2b88713);
		}
	}
}
