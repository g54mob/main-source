using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b FromInterop(IntPtr data, int dataSize)
		{
			return default(_9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b);
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

		public static void Serialize(_9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9b23354a400048a489ffb9db6b9d5b96_cb625513ed184c589a854ca36f53e47b);
		}
	}
}
