using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63 FromInterop(IntPtr data, int dataSize)
		{
			return default(_02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63);
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

		public _02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_02f4603b68bd05a4eac4f889c63b8d92_a584dde2ed264299b949a2078fa2ef63);
		}
	}
}
