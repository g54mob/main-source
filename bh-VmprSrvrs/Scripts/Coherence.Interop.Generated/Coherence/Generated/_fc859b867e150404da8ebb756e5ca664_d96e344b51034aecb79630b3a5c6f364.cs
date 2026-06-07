using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Vector2 velocity;
		}

		public Vector2 velocity;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364);
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

		public _fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364(Entity entity, Vector2 velocity)
		{
			this.velocity = default(Vector2);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_d96e344b51034aecb79630b3a5c6f364);
		}
	}
}
