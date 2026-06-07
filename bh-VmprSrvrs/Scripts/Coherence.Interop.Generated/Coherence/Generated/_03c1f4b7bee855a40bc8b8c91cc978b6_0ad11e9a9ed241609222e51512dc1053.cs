using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053 FromInterop(IntPtr data, int dataSize)
		{
			return default(_03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053);
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

		public static void Serialize(_03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_03c1f4b7bee855a40bc8b8c91cc978b6_0ad11e9a9ed241609222e51512dc1053);
		}
	}
}
