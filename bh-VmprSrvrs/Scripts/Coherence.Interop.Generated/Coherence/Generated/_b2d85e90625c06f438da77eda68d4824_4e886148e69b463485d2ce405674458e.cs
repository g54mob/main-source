using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e FromInterop(IntPtr data, int dataSize)
		{
			return default(_b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e);
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

		public static void Serialize(_b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b2d85e90625c06f438da77eda68d4824_4e886148e69b463485d2ce405674458e);
		}
	}
}
