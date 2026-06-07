using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a FromInterop(IntPtr data, int dataSize)
		{
			return default(_f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a);
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

		public _f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f5ea2098ba025134fbd33a39c72295c3_aca8934fb8a846bd910f62d06d3b219a);
		}
	}
}
