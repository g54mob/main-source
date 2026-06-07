using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc FromInterop(IntPtr data, int dataSize)
		{
			return default(_f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc);
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

		public static void Serialize(_f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f2e9e11e344028640b9f5ed6f71c9b8a_c0fdbbc9aa284f829ce616b4c28811fc);
		}
	}
}
