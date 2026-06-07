using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int rnd;
		}

		public long startingSimFrame;

		public int rnd;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17 FromInterop(IntPtr data, int dataSize)
		{
			return default(_32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17);
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

		public _32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17(Entity entity, long startingSimFrame, int rnd)
		{
			this.startingSimFrame = 0L;
			this.rnd = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_32077016b3d740f438be7293b01c02ac_6b40ce9205ae45ac98c2b4126090df17);
		}
	}
}
