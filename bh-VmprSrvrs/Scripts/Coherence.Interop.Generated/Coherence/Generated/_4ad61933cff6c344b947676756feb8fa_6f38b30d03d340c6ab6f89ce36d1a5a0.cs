using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0);
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

		public _4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4ad61933cff6c344b947676756feb8fa_6f38b30d03d340c6ab6f89ce36d1a5a0);
		}
	}
}
