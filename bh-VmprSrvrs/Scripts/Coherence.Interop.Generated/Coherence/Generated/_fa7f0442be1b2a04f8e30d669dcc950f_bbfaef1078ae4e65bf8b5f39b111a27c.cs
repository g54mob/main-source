using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c FromInterop(IntPtr data, int dataSize)
		{
			return default(_fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c);
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

		public static void Serialize(_fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fa7f0442be1b2a04f8e30d669dcc950f_bbfaef1078ae4e65bf8b5f39b111a27c);
		}
	}
}
