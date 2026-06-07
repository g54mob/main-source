using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public float value;
		}

		public long startingSimFrame;

		public int weaponType;

		public float value;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42 FromInterop(IntPtr data, int dataSize)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42);
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

		public _23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_b8f1ccfb883342329a8df96d90a57c42);
		}
	}
}
