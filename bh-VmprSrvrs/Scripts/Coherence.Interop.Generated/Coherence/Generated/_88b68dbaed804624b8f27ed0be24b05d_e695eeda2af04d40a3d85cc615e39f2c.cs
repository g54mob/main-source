using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c FromInterop(IntPtr data, int dataSize)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c);
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

		public static void Serialize(_88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_e695eeda2af04d40a3d85cc615e39f2c);
		}
	}
}
