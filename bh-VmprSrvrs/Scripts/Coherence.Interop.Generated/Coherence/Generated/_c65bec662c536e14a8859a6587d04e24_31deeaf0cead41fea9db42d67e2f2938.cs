using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938);
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

		public static void Serialize(_c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c65bec662c536e14a8859a6587d04e24_31deeaf0cead41fea9db42d67e2f2938);
		}
	}
}
