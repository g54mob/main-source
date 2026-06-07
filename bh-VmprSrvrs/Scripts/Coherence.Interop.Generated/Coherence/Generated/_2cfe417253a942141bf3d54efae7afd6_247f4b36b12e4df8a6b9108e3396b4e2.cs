using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Vector2 startPosition;

			[FieldOffset(8)]
			public Vector2 endPosition;

			[FieldOffset(16)]
			public int itemType;

			[FieldOffset(20)]
			public int weaponType;
		}

		public Vector2 startPosition;

		public Vector2 endPosition;

		public int itemType;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
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

		public _2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2(Entity entity, Vector2 startPosition, Vector2 endPosition, int itemType, int weaponType)
		{
			this.startPosition = default(Vector2);
			this.endPosition = default(Vector2);
			this.itemType = 0;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_247f4b36b12e4df8a6b9108e3396b4e2);
		}
	}
}
