using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53 FromInterop(IntPtr data, int dataSize)
		{
			return default(_504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53);
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

		public static void Serialize(_504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_504314d895b6db048a2f956fc4bf3cce_896de3f9bc0e4e5992150f7475afeb53);
		}
	}
}
