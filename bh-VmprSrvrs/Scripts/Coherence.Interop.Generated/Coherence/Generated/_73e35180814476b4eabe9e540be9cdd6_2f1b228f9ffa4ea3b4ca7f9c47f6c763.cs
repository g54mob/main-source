using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763 FromInterop(IntPtr data, int dataSize)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763);
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

		public static void Serialize(_73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_2f1b228f9ffa4ea3b4ca7f9c47f6c763);
		}
	}
}
