using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99 FromInterop(IntPtr data, int dataSize)
		{
			return default(_69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99);
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

		public static void Serialize(_69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_69a58b728281d074fb1046ae11b924a4_53735809bd194182b3aa061763794a99);
		}
	}
}
