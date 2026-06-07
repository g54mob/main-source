using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity boss;

			[FieldOffset(4)]
			public Vector2 direction;
		}

		public Entity boss;

		public Vector2 direction;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938 FromInterop(IntPtr data, int dataSize)
		{
			return default(_220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938);
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

		public _220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938(Entity entity, Entity boss, Vector2 direction)
		{
			this.boss = default(Entity);
			this.direction = default(Vector2);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_220d0e54abafe5c4e98eb765d5d2aabd_5a81b0e1d6c64828a71faaf627062938);
		}
	}
}
