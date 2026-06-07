using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6);
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

		public _a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a36f0e13e6d64be4baaf6a40902866f7_6e4f7050d56b4f939078b7d74df61de6);
		}
	}
}
