using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136);
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

		public static void Serialize(_f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f4cbd8975d45a78499a5e352ed7242ae_0e0c1b4863e044a5af8b70a58c86e136);
		}
	}
}
