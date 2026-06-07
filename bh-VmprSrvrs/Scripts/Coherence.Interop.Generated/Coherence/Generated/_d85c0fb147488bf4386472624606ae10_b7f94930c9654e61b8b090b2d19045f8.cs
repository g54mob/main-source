using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8);
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

		public _d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d85c0fb147488bf4386472624606ae10_b7f94930c9654e61b8b090b2d19045f8);
		}
	}
}
