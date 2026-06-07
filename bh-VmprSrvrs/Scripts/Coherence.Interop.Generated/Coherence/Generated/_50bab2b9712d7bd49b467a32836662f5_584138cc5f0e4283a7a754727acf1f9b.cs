using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;
		}

		public long startingSimFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b FromInterop(IntPtr data, int dataSize)
		{
			return default(_50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b);
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

		public _50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_50bab2b9712d7bd49b467a32836662f5_584138cc5f0e4283a7a754727acf1f9b);
		}
	}
}
