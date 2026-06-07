using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1);
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

		public _87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_906e6d531be842b99a2f9f0b40a157f1);
		}
	}
}
