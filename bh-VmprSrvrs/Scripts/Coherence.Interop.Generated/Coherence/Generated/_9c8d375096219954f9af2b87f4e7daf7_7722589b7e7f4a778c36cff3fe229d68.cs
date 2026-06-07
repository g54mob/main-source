using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68);
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

		public static void Serialize(_9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9c8d375096219954f9af2b87f4e7daf7_7722589b7e7f4a778c36cff3fe229d68);
		}
	}
}
