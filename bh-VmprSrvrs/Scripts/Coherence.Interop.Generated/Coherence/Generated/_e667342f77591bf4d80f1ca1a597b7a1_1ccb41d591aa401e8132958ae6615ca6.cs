using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6);
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

		public static void Serialize(_e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e667342f77591bf4d80f1ca1a597b7a1_1ccb41d591aa401e8132958ae6615ca6);
		}
	}
}
