using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float x;

			[FieldOffset(4)]
			public float y;
		}

		public float x;

		public float y;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b FromInterop(IntPtr data, int dataSize)
		{
			return default(_bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b);
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

		public _bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b(Entity entity, float x, float y)
		{
			this.x = 0f;
			this.y = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bc95cb09d06d2a04489da20687b88115_93c3f29f2fdf44d49aa8807a5189250b);
		}
	}
}
