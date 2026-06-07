using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f FromInterop(IntPtr data, int dataSize)
		{
			return default(_c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f);
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

		public static void Serialize(_c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c66f51c22d170b14185adbfe477f7029_713b739087694484a5ce8b365930ef0f);
		}
	}
}
