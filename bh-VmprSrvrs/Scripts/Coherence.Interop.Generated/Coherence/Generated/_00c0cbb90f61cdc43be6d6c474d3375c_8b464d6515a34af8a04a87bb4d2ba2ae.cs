using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae FromInterop(IntPtr data, int dataSize)
		{
			return default(_00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae);
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

		public static void Serialize(_00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_00c0cbb90f61cdc43be6d6c474d3375c_8b464d6515a34af8a04a87bb4d2ba2ae);
		}
	}
}
