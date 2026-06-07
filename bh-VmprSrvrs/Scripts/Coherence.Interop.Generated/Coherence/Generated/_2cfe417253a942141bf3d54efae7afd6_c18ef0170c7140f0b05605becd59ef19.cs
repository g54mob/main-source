using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte discard;
		}

		public long startingSimFrame;

		public bool discard;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19);
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

		public _2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19(Entity entity, long startingSimFrame, bool discard)
		{
			this.startingSimFrame = 0L;
			this.discard = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_c18ef0170c7140f0b05605becd59ef19);
		}
	}
}
