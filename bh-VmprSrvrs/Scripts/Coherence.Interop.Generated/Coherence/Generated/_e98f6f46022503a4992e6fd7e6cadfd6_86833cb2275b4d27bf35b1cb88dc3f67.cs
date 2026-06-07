using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67);
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

		public _e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e98f6f46022503a4992e6fd7e6cadfd6_86833cb2275b4d27bf35b1cb88dc3f67);
		}
	}
}
