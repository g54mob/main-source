using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public int tentacleIndex;

			[FieldOffset(4)]
			public ByteArray spriteName;

			[FieldOffset(20)]
			public ByteArray textureName;

			[FieldOffset(36)]
			public byte isFiring;

			[FieldOffset(37)]
			public byte stopFiring;
		}

		public int tentacleIndex;

		public string spriteName;

		public string textureName;

		public bool isFiring;

		public bool stopFiring;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4);
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

		public _58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4(Entity entity, int tentacleIndex, string spriteName, string textureName, bool isFiring, bool stopFiring)
		{
			this.tentacleIndex = 0;
			this.spriteName = null;
			this.textureName = null;
			this.isFiring = false;
			this.stopFiring = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_58bf7607b8b0aec4597e8088feeda1e5_7369275c0c0f4ce0b4c9b60e0f4bded4);
		}
	}
}
