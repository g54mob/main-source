using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda FromInterop(IntPtr data, int dataSize)
		{
			return default(_9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda);
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

		public static void Serialize(_9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9cabef5699d3b48459e4b8de19593a11_c5a6f04dfc5a44e0bd7baa01688f9bda);
		}
	}
}
