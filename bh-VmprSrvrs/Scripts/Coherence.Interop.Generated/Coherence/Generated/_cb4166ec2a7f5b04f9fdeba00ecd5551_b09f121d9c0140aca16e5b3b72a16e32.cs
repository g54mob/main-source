using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32 FromInterop(IntPtr data, int dataSize)
		{
			return default(_cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32);
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

		public static void Serialize(_cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cb4166ec2a7f5b04f9fdeba00ecd5551_b09f121d9c0140aca16e5b3b72a16e32);
		}
	}
}
