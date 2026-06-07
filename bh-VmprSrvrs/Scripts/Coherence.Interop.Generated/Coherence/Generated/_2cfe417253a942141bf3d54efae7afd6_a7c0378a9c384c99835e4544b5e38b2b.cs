using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float duration;

			[FieldOffset(4)]
			public int chosenEventTarget;

			[FieldOffset(8)]
			public Vector2 targetLocation;

			[FieldOffset(16)]
			public ByteArray newsFeedText;

			[FieldOffset(32)]
			public byte isPickleRush;
		}

		public float duration;

		public int chosenEventTarget;

		public Vector2 targetLocation;

		public string newsFeedText;

		public bool isPickleRush;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b);
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

		public _2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b(Entity entity, float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeedText, bool isPickleRush)
		{
			this.duration = 0f;
			this.chosenEventTarget = 0;
			this.targetLocation = default(Vector2);
			this.newsFeedText = null;
			this.isPickleRush = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_a7c0378a9c384c99835e4544b5e38b2b);
		}
	}
}
