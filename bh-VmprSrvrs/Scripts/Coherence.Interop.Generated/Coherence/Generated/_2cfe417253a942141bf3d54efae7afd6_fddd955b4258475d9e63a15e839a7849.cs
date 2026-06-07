using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity pausingPlayer;
		}

		public Entity pausingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849);
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

		public _2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849(Entity entity, Entity pausingPlayer)
		{
			this.pausingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_fddd955b4258475d9e63a15e839a7849);
		}
	}
}
