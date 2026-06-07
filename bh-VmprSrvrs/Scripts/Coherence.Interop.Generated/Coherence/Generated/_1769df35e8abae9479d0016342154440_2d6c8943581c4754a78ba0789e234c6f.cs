using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f FromInterop(IntPtr data, int dataSize)
		{
			return default(_1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f);
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

		public _1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1769df35e8abae9479d0016342154440_2d6c8943581c4754a78ba0789e234c6f);
		}
	}
}
