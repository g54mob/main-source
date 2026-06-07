using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95);
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

		public _f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f5ea2098ba025134fbd33a39c72295c3_033eceacf92a40cb81adec14ee98eb95);
		}
	}
}
