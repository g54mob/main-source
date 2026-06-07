using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity gRing;

			[FieldOffset(4)]
			public Entity sRing;

			[FieldOffset(8)]
			public Entity lMeta;

			[FieldOffset(12)]
			public Entity rMeta;

			[FieldOffset(16)]
			public Entity player;
		}

		public Entity gRing;

		public Entity sRing;

		public Entity lMeta;

		public Entity rMeta;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df);
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

		public _2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df(Entity entity, Entity gRing, Entity sRing, Entity lMeta, Entity rMeta, Entity player)
		{
			this.gRing = default(Entity);
			this.sRing = default(Entity);
			this.lMeta = default(Entity);
			this.rMeta = default(Entity);
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_a54abab429a94a5b8ec009b33a2057df);
		}
	}
}
