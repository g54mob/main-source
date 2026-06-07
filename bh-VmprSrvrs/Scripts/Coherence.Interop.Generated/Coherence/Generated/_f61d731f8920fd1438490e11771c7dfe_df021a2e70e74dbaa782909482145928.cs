using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928);
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

		public static void Serialize(_f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f61d731f8920fd1438490e11771c7dfe_df021a2e70e74dbaa782909482145928);
		}
	}
}
