using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a FromInterop(IntPtr data, int dataSize)
		{
			return default(_d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a);
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

		public _d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d4f305a2aee3ecd449a3412d3f0c9ad9_1c71ef2679ee42f68dcb6a2bc2d1166a);
		}
	}
}
