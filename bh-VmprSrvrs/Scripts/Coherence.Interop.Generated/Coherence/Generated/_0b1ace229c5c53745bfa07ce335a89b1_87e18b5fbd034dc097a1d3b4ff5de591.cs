using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591);
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

		public _0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0b1ace229c5c53745bfa07ce335a89b1_87e18b5fbd034dc097a1d3b4ff5de591);
		}
	}
}
