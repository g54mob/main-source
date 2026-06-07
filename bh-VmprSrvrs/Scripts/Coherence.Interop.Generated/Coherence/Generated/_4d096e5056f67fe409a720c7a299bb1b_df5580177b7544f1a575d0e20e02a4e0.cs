using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0);
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

		public static void Serialize(_4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4d096e5056f67fe409a720c7a299bb1b_df5580177b7544f1a575d0e20e02a4e0);
		}
	}
}
