using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float xOffset;

			[FieldOffset(4)]
			public byte follow;

			[FieldOffset(5)]
			public float duration;
		}

		public float xOffset;

		public bool follow;

		public float duration;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5);
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

		public _50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5(Entity entity, float xOffset, bool follow, float duration)
		{
			this.xOffset = 0f;
			this.follow = false;
			this.duration = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_50bab2b9712d7bd49b467a32836662f5_812043d85fb844aa9d1ddbe514493ce5);
		}
	}
}
