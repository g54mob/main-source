using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a FromInterop(IntPtr data, int dataSize)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a);
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

		public _23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_01a1d69e3d0546178ad5b1382270bf3a);
		}
	}
}
