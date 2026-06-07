using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Vector2 target;

			[FieldOffset(8)]
			public float startAngleOffset;
		}

		public Vector2 target;

		public float startAngleOffset;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179);
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

		public _b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179(Entity entity, Vector2 target, float startAngleOffset)
		{
			this.target = default(Vector2);
			this.startAngleOffset = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b69aa349718557648aaeeb4157595687_74e9864e2d784348a8ea752fd8658179);
		}
	}
}
