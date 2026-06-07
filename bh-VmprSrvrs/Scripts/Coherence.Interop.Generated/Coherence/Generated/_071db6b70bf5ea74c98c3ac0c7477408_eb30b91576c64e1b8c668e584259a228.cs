using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228 FromInterop(IntPtr data, int dataSize)
		{
			return default(_071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228);
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

		public static void Serialize(_071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_071db6b70bf5ea74c98c3ac0c7477408_eb30b91576c64e1b8c668e584259a228);
		}
	}
}
