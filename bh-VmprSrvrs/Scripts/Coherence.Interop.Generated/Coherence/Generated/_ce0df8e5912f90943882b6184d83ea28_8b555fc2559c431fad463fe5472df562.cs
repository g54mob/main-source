using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562);
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

		public static void Serialize(_ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ce0df8e5912f90943882b6184d83ea28_8b555fc2559c431fad463fe5472df562);
		}
	}
}
