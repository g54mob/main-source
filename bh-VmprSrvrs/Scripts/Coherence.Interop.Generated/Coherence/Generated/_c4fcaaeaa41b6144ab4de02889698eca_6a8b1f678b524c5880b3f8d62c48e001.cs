using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public float value;
		}

		public long startingSimFrame;

		public int weaponType;

		public float value;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001);
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

		public _c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_6a8b1f678b524c5880b3f8d62c48e001);
		}
	}
}
