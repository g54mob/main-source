using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long startingSimFrame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599);
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

		public _ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ffd05246d30c66048a844398cd3323bd_9517f6ccea1d43c2a8e060a35da19599);
		}
	}
}
