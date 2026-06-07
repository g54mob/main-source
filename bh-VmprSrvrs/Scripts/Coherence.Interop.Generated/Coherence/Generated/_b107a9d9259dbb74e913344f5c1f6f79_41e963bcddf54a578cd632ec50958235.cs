using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235);
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

		public static void Serialize(_b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_41e963bcddf54a578cd632ec50958235);
		}
	}
}
