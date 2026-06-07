using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0);
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

		public static void Serialize(_52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_52438fd9541f3e845a671c68cf15312d_7527b5f49a724b2f810749cbac3f62f0);
		}
	}
}
